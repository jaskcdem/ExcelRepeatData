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
            WriteError();
        }
        const string uploadStart = "selecting excel...";
        const string defaultInfo = "Use ';' to separate multiple keywords.";
        const string NoDataMessage = "Please upload an excel file first.";
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
                                CompareColumns = [.. txt_compare.Text.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s))],
                                ExceptSheets = [.. txt_except.Text.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s))],
                                LogFile = !string.IsNullOrWhiteSpace(txt_log.Text) ? txt_log.Text : src ?? Environment.CurrentDirectory,
                                ExcelPath = src,
                                OutputPath = !string.IsNullOrWhiteSpace(txt_out.Text) ? txt_out.Text : src ?? Environment.CurrentDirectory,
                            };
                            ExcelReader.Read(Config, openFile.FileNames);
                            if (!string.IsNullOrWhiteSpace(txt_file.Text)) Config.OutputFile = txt_file.Text.Trim();
                            lbl_uploadStatus.Text = "Upload success.";
                        }
                        else lbl_uploadStatus.Text = uploadStart;
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        WriteError(ex);
                        lbl_uploadStatus.Text = uploadStart;
                    }
                    break;
                case "btn_log":
                    try
                    {
                        SelectFolder(txt_log);
                    }
                    catch (Exception ex) { WriteError(ex); }
                    break;
                case "btn_out":
                    try
                    {
                        SelectFolder(txt_out);
                    }
                    catch (Exception ex) { WriteError(ex); }
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
                    foreach (string keyword in keys)
                    {
                        if (Config.IsExist(keyword)) txt_exist.AppendText(keyword + Environment.NewLine);
                        else txt_notExist.AppendText(keyword + Environment.NewLine);
                    }
                    break;
                case "btn_clear":
                    txt_exist.Text = txt_notExist.Text = txt_search.Text = string.Empty;
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
        private void WriteError(Exception? e = null)
        {
            if (e != null)
            {
                lbl_message.Text = e.ToString();
                lbl_message.ForeColor = Color.Red;
            }
            else
            {
                lbl_message.Text = string.Empty;
                lbl_message.ForeColor = Color.DarkGray;
            }
        }
    }
}
