namespace ExcelRepeatData.Model
{
    internal class FormConfig()
    {
        internal required string LogFile { get; set; }
        /// <summary>Columns name to compare</summary>
        internal required string[] CompareColumns { get; set; }
        /// <summary>Sheets not to compare</summary>
        internal required string[] ExceptSheets { get; set; }
        /// <summary>Import excel path</summary>
        internal string? ExcelPath { get; set; }
        /// <summary>Result output path</summary>
        internal string? OutputPath { get; set; }
        /// <summary>Result output  file</summary>
        internal string? OutputFile { get; set; }

        internal List<ExcelDatas> DataTable { get; set; } = [];
        internal List<ExcelResponse> SearchDT { get; private set; } = [];

        internal static readonly string strVersion = DateTime.Now.ToString("yyyyMMdd-HHmmss");
        internal List<ExcelResponse> GetRepeatResponses()
        {
            var results = new List<ExcelResponse>();
            foreach (string col in CompareColumns)
            {
                var group = DataTable.GroupBy(d => d.Get(col));
                var query = group.Where(g => !string.IsNullOrWhiteSpace(g.Key) && g.Count() > 1)
                    .SelectMany(g => g.Select(gg => new ExcelResponse(gg, g.Key ?? string.Empty)));
                results.AddRange(query);
            }
            return results;
        }
        internal List<ExcelResponse> GetAllResponses(bool addHeader = true)
        {
            var results = new List<ExcelResponse>();
            foreach (string col in CompareColumns)
            {
                var query = DataTable.Where(x => x.Fields.ContainsKey(col));
                if (!query.Any()) continue;
                if (addHeader) results.Add(new ExcelResponse(query.First(), $"--{col}--"));
                results.AddRange(query.Select(x => new ExcelResponse(x, x.Get(col) ?? string.Empty)));
                results.RemoveAll(x => string.IsNullOrWhiteSpace(x.Value));
            }
            return results;
        }
        internal bool IsExist(string keyword)
        {
            if (SearchDT.Count <= 0) SearchDT = GetAllResponses(false);
            return SearchDT.Any(r => r.Value.Equals(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
