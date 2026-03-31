using ClosedXML.Excel;
using ExcelRepeatData.Model;

namespace ExcelRepeatData.Utils
{
    internal static class ExcelWriter
    {
        /// <summary>
        /// 將 ExcelResponse 列表輸出為新的 xlsx，回傳實際儲存路徑。
        /// 若 outputDirectory 為 null，會使用 Config.ExcelPath 或目前工作目錄。
        /// </summary>
        internal static string WriteResponses(FormConfig config, IEnumerable<ExcelResponse> responses)
        {
            ArgumentNullException.ThrowIfNull(responses);
            var list = responses.ToList();
            if (list.Count == 0) return string.Empty;

            var dir = string.IsNullOrWhiteSpace(config.OutputPath)
                ? string.IsNullOrWhiteSpace(config.ExcelPath) ? Environment.CurrentDirectory : config.ExcelPath
                : config.OutputPath;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            var name = string.IsNullOrEmpty(config.OutputFile) ? $"duplicates_{FormConfig.strVersion}.xlsx" : config.OutputFile;
            var filePath = Path.Combine(dir, name);

            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Duplicates");

            // Header
            var firstResponse = list[0];
            ws.Cell(1, 1).Value = nameof(firstResponse.Source);
            ws.Cell(1, 2).Value = nameof(firstResponse.Sheet);
            ws.Cell(1, 3).Value = nameof(firstResponse.Value);
            ws.Range(1, 1, 1, 3).Style.Font.Bold = true;

            // Data
            for (int i = 0; i < list.Count; i++)
            {
                var r = list[i];
                var row = i + 2;
                ws.Cell(row, 1).Value = r.Source ?? string.Empty;
                ws.Cell(row, 2).Value = r.Sheet ?? string.Empty;
                ws.Cell(row, 3).Value = r.Value ?? string.Empty;
            }

            ws.RangeUsed()!.SetAutoFilter();
            ws.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
            return filePath;
        }
    }
}
