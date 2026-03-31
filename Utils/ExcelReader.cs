using ClosedXML.Excel;
using ExcelRepeatData.Model;
using System.Collections.Concurrent;

namespace ExcelRepeatData.Utils
{
    internal static class ExcelReader
    {
        internal static List<ExcelDatas> Read(FormConfig config, params string[] excelPaths)
        {
            if (excelPaths.Length == 0) return [];

            var results = new List<ExcelDatas>();
            foreach (string filePath in excelPaths!)
            {
                string excel = Path.GetFileName(filePath);
                results.AddRange(ReadXlsx(config, filePath, sourceInfo: excel, sheetName: "*"));
            }
            config.DataTable = results;
            return results;
        }

        /// <summary>
        /// 讀取 xlsx，根據 header 名稱擷取指定欄位，回傳 List&lt;ExcelDatas&gt;。
        /// 若<paramref name="sheetName"/>為 null 或 "*" 則讀取所有工作表。
        /// 支援多 sheet 並行處理（sheet 之間），並接受 CancellationToken。
        /// </summary>
        static List<ExcelDatas> ReadXlsx(FormConfig config, string filePath, string? sourceInfo = null,
            string? sheetName = null, int headerRow = 1, int dataRow = 3,
            bool processSheetsInParallel = true, CancellationToken cancellationToken = default)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("xlsx file not found.", filePath);
            if (headerRow < 1) throw new ArgumentOutOfRangeException(nameof(headerRow), "headerRow must be >= 1");
            if (dataRow < 2) throw new ArgumentOutOfRangeException(nameof(headerRow), "dataRow must be >= 2");
            if (dataRow <= headerRow) throw new ArgumentException("dataRow must be greater than headerRow.");

            var requestedColumns = config.CompareColumns;
            if (requestedColumns.Length == 0) return [];
            var results = new ConcurrentBag<ExcelDatas>();
            using var workbook = new XLWorkbook(filePath);

            var worksheets = new List<IXLWorksheet>();
            if (string.IsNullOrEmpty(sheetName) || sheetName == "*")
                worksheets.AddRange(workbook.Worksheets);
            else
            {
                var ws = workbook.Worksheets
                    .FirstOrDefault(w => w.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase))
                    ?? throw new ArgumentException($"Worksheet '{sheetName}' not found.", nameof(sheetName));
                worksheets.Add(ws);
            }

            var po = new ParallelOptions
            {
                MaxDegreeOfParallelism = processSheetsInParallel ? Environment.ProcessorCount : 1,
                CancellationToken = cancellationToken
            };
            var exceptSheets = config.ExceptSheets;

            // 處理每個 worksheet（sheet 之間並行）
            Parallel.ForEach(worksheets, po, worksheet =>
            {
                // 若取消，立即返回
                if (po.CancellationToken.IsCancellationRequested) return;
                if (exceptSheets.Contains(worksheet.Name)) return;

                // 取得 header map（headerName => columnIndex）
                var header = worksheet.Row(headerRow);
                var headerMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                foreach (var cell in header.CellsUsed())
                {
                    var text = cell.GetString()?.Trim();
                    if (string.IsNullOrEmpty(text)) continue;
                    headerMap[text] = cell.Address.ColumnNumber;
                }

                // 若沒有 header 或 header 沒有任何一個是我們要的，則跳過整個 sheet
                if (headerMap.Count == 0 || !headerMap.Keys.Any(h => requestedColumns.Contains(h))) return;

                var lastRow = worksheet.LastRowUsed()?.RowNumber() ?? headerRow;
                for (int r = dataRow; r <= lastRow; r++)
                {
                    if (po.CancellationToken.IsCancellationRequested) break;

                    var row = worksheet.Row(r);
                    // 若整列空白則跳過（CellsUsed 可能會少量開銷，但比建立整個值物件便宜）
                    if (!row.CellsUsed().Any()) continue;

                    // 為每列建立一個小字典，並使用 ignore-case
                    var fields = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
                    foreach (var colName in requestedColumns)
                    {
                        if (headerMap.TryGetValue(colName, out var colIdx))
                        {
                            var cell = worksheet.Cell(r, colIdx);
                            if (!cell.IsEmpty()) fields[colName] = cell.GetString();
                        }
                    }

                    var data = new ExcelDatas
                    {
                        Source = sourceInfo,
                        Sheet = worksheet.Name,
                        Fields = fields
                    };

                    results.Add(data);
                }
            });

            return [.. results];
        }
    }
}
