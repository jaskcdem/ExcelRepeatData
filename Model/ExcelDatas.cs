namespace ExcelRepeatData.Model
{
    internal class ExcelDatas
    {
        /// <summary>Source File</summary>
        public string? Source { get; init; }
        /// <summary>Source Sheet</summary>
        public string? Sheet { get; init; }

        /// <summary>Key = header，Value = data</summary>
        public Dictionary<string, string?> Fields { get; init; } = [];

        public string? Get(string columnName) => Fields.TryGetValue(columnName, out var v) ? v : null;
    }
    internal class ExcelResponse
    {
        internal ExcelResponse(ExcelDatas info, string val)
        {
            Source = info.Source;
            Sheet = info.Sheet;
            Value = val;
        }

        /// <summary>Source File</summary>
        internal string? Source { get; init; }
        /// <summary>Source Sheet</summary>
        internal string? Sheet { get; init; }
        /// <summary>Fields data</summary>
        internal string Value { get; init; } = "";
    }
}
