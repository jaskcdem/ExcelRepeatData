using ExcelRepeatData.Model;
using ExcelRepeatData.Utils;

namespace ExcelRepeatData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_compare.Text = defaultColumns;
            txt_except.Text = defaultSheet;
            lbl_info.Text = defaultInfo;
            lbl_message.Text = Guild;
        }
        const string uploadStart = "selecting excel...";
        const string defaultInfo = "Use ';' to separate multiple keywords.";
        const string NoDataMessage = "Please upload an excel file first.";
        const string Guild = @"Before uploading, please make sure:
1. The excel file is closed.
2. The column names to compare are correct and exist in the excel file.
3. The sheet names to exclude are correct and exist in the excel file (if any).
4. The log and output paths are valid (if specified).
5. The output file name is valid (with extension, if specified).
If you encounter any issues, please check the above points and try again.
";
        const string NoDataTitle = "No Data";
        const string defaultColumns = "¦WºÙ";
        const string defaultSheet = "ª¬ºAªí";
        FormConfig? Config { get; set; }

        private void btn_click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn?.Name)
            {
                case "btn_upload":
                    try
                    {
                        #region Uploading
                        using OpenFileDialog openFile = new();
                        lbl_uploadStatus.Text = "Uploading...";
                        openFile.Filter = "Excel Files|*.xlsx;*.xls";
                        openFile.Multiselect = true;
                        if (openFile.ShowDialog() == DialogResult.OK)
                        {
                            lbl_uploadStatus.Text = "Start import...";
                            string? src = Path.GetDirectoryName(openFile.FileNames[0]);
                            Config = new FormConfig
                            {
                                CompareColumns = GetCompareColumns(),
                                ExceptSheets = GetExceptSheets(),
                                LogFile = GetLogPath(src),
                                ExcelPath = src,
                                OutputPath = GetOutputPath(src),
                            };
                            ExcelReader.Read(Config, openFile.FileNames);
                            if (!string.IsNullOrWhiteSpace(txt_file.Text)) Config.OutputFile = txt_file.Text.Trim();
                            lbl_uploadStatus.Text = "Upload success.";
                        }
                        else lbl_uploadStatus.Text = uploadStart;
                        #endregion
                    }
                    catch (Exception)
                    {
                        lbl_uploadStatus.Text = uploadStart;
                        throw;
                    }
                    break;
                case "btn_log":
                    SelectFolder(txt_log);
                    break;
                case "btn_out":
                    SelectFolder(txt_out);
                    break;
                case "btn_export":
                    if (Config == null) { Alert(NoDataMessage, NoDataTitle); return; }
                    ExcelWriter.WriteResponses(Config, Config.GetRepeatResponses());
                    Alert("Export completed.", "Success", MessageBoxIcon.Information);
                    break;
                case "btn_exportAll":
                    if (Config == null) { Alert(NoDataMessage, NoDataTitle); return; }
                    ExcelWriter.WriteResponses(Config, Config.GetAllResponses());
                    Alert("Export completed.", "Success", MessageBoxIcon.Information);
                    break;
                case "btn_search":
                    if (Config == null) { Alert(NoDataMessage, NoDataTitle); return; }
                    txt_exist.Text = txt_notExist.Text = string.Empty;
                    var keys = txt_search.Text.Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s));
                    string spliter = keys.Count() <= 6 ? Environment.NewLine : "¡B";
                    foreach (string keyword in keys)
                    {
                        if (Config.IsExist(keyword)) txt_exist.AppendText(keyword + spliter);
                        else txt_notExist.AppendText(keyword + spliter);
                    }
                    break;
                case "btn_clear":
                    txt_exist.Text = txt_notExist.Text = txt_search.Text = string.Empty;
                    break;
                case "btn_reflash":
                    if (Config == null) { Alert(NoDataMessage, NoDataTitle); return; }
                    Config.CompareColumns = GetCompareColumns();
                    Config.ExceptSheets = GetExceptSheets();
                    Config.LogFile = GetLogPath(Config.ExcelPath);
                    Config.OutputPath = GetOutputPath(Config.ExcelPath);
                    if (!string.IsNullOrWhiteSpace(txt_file.Text)) Config.OutputFile = txt_file.Text.Trim();
                    Alert("Refresh completed.", "Success", MessageBoxIcon.Information);
                    break;
            }
        }

        private static void Alert(string? text, string? title, MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, icon);
        }
        private static void SelectFolder(TextBox target)
        {
            using var dialog = new FolderBrowserDialog();
            dialog.Description = "Select a folder";
            dialog.UseDescriptionForTitle = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                target.Text = dialog.SelectedPath;
            }
        }
        private string[] GetCompareColumns() => [.. txt_compare.Text.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s))];
        private string[] GetExceptSheets() => [.. txt_except.Text.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s))];
        private string GetLogPath(string? src) => !string.IsNullOrWhiteSpace(txt_log.Text) ? txt_log.Text : src ?? Environment.CurrentDirectory;
        private string GetOutputPath(string? src) => !string.IsNullOrWhiteSpace(txt_out.Text) ? txt_out.Text : src ?? Environment.CurrentDirectory;
    }
}
