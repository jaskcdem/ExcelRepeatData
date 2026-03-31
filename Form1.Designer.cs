namespace ExcelRepeatData
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tab_import = new TabPage();
            pl_setting = new Panel();
            btn_exportAll = new Button();
            btn_export = new Button();
            txt_out = new TextBox();
            btn_out = new Button();
            txt_log = new TextBox();
            btn_log = new Button();
            txt_file = new TextBox();
            txt_except = new TextBox();
            txt_compare = new TextBox();
            lbl_file = new Label();
            lbl_log = new Label();
            lbl_out = new Label();
            lbl_except = new Label();
            lbl_compare = new Label();
            pl_upload = new Panel();
            lbl_message = new Label();
            lbl_upload = new Label();
            lbl_uploadStatus = new Label();
            btn_upload = new Button();
            tab_search = new TabPage();
            txt_notExist = new TextBox();
            lbl_notExist = new Label();
            txt_exist = new TextBox();
            lbl_exist = new Label();
            lbl_info = new Label();
            btn_clear = new Button();
            btn_search = new Button();
            txt_search = new TextBox();
            lbl_search = new Label();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tabControl1.SuspendLayout();
            tab_import.SuspendLayout();
            pl_setting.SuspendLayout();
            pl_upload.SuspendLayout();
            tab_search.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tab_import);
            tabControl1.Controls.Add(tab_search);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1708, 1210);
            tabControl1.TabIndex = 0;
            // 
            // tab_import
            // 
            tab_import.Controls.Add(pl_setting);
            tab_import.Controls.Add(pl_upload);
            tab_import.Location = new Point(8, 46);
            tab_import.Name = "tab_import";
            tab_import.Padding = new Padding(3);
            tab_import.Size = new Size(1692, 1156);
            tab_import.TabIndex = 0;
            tab_import.Text = "Import";
            tab_import.UseVisualStyleBackColor = true;
            // 
            // pl_setting
            // 
            pl_setting.Controls.Add(btn_exportAll);
            pl_setting.Controls.Add(btn_export);
            pl_setting.Controls.Add(txt_out);
            pl_setting.Controls.Add(btn_out);
            pl_setting.Controls.Add(txt_log);
            pl_setting.Controls.Add(btn_log);
            pl_setting.Controls.Add(txt_file);
            pl_setting.Controls.Add(txt_except);
            pl_setting.Controls.Add(txt_compare);
            pl_setting.Controls.Add(lbl_file);
            pl_setting.Controls.Add(lbl_log);
            pl_setting.Controls.Add(lbl_out);
            pl_setting.Controls.Add(lbl_except);
            pl_setting.Controls.Add(lbl_compare);
            pl_setting.Location = new Point(21, 247);
            pl_setting.Name = "pl_setting";
            pl_setting.Size = new Size(1649, 892);
            pl_setting.TabIndex = 4;
            // 
            // btn_exportAll
            // 
            btn_exportAll.Font = new Font("Segoe UI", 10F);
            btn_exportAll.Location = new Point(1274, 642);
            btn_exportAll.Name = "btn_exportAll";
            btn_exportAll.Size = new Size(344, 46);
            btn_exportAll.TabIndex = 13;
            btn_exportAll.Text = "Export All";
            btn_exportAll.UseVisualStyleBackColor = true;
            btn_exportAll.Click += btn_click;
            // 
            // btn_export
            // 
            btn_export.Font = new Font("Segoe UI", 10F);
            btn_export.Location = new Point(1274, 562);
            btn_export.Name = "btn_export";
            btn_export.Size = new Size(344, 46);
            btn_export.TabIndex = 12;
            btn_export.Text = "Export only repeat";
            btn_export.UseVisualStyleBackColor = true;
            btn_export.Click += btn_click;
            // 
            // txt_out
            // 
            txt_out.Enabled = false;
            txt_out.Location = new Point(576, 344);
            txt_out.Name = "txt_out";
            txt_out.Size = new Size(1048, 39);
            txt_out.TabIndex = 9;
            // 
            // btn_out
            // 
            btn_out.Font = new Font("Segoe UI", 10F);
            btn_out.Location = new Point(316, 336);
            btn_out.Name = "btn_out";
            btn_out.Size = new Size(231, 46);
            btn_out.TabIndex = 8;
            btn_out.Text = "select folder...";
            btn_out.UseVisualStyleBackColor = true;
            btn_out.Click += btn_click;
            // 
            // txt_log
            // 
            txt_log.Enabled = false;
            txt_log.Location = new Point(576, 247);
            txt_log.Name = "txt_log";
            txt_log.Size = new Size(1048, 39);
            txt_log.TabIndex = 6;
            // 
            // btn_log
            // 
            btn_log.Font = new Font("Segoe UI", 10F);
            btn_log.Location = new Point(316, 239);
            btn_log.Name = "btn_log";
            btn_log.Size = new Size(231, 46);
            btn_log.TabIndex = 5;
            btn_log.Text = "select folder...";
            btn_log.UseVisualStyleBackColor = true;
            btn_log.Click += btn_click;
            // 
            // txt_file
            // 
            txt_file.Location = new Point(316, 441);
            txt_file.Name = "txt_file";
            txt_file.Size = new Size(1308, 39);
            txt_file.TabIndex = 11;
            // 
            // txt_except
            // 
            txt_except.Location = new Point(316, 142);
            txt_except.Name = "txt_except";
            txt_except.Size = new Size(1308, 39);
            txt_except.TabIndex = 3;
            // 
            // txt_compare
            // 
            txt_compare.Location = new Point(316, 42);
            txt_compare.Name = "txt_compare";
            txt_compare.Size = new Size(1308, 39);
            txt_compare.TabIndex = 1;
            // 
            // lbl_file
            // 
            lbl_file.AutoSize = true;
            lbl_file.Font = new Font("Segoe UI", 12F);
            lbl_file.Location = new Point(27, 434);
            lbl_file.Name = "lbl_file";
            lbl_file.Size = new Size(273, 45);
            lbl_file.TabIndex = 10;
            lbl_file.Text = "Output File Name";
            // 
            // lbl_log
            // 
            lbl_log.AutoSize = true;
            lbl_log.Font = new Font("Segoe UI", 12F);
            lbl_log.Location = new Point(156, 240);
            lbl_log.Name = "lbl_log";
            lbl_log.Size = new Size(144, 45);
            lbl_log.TabIndex = 4;
            lbl_log.Text = "Log Path";
            // 
            // lbl_out
            // 
            lbl_out.AutoSize = true;
            lbl_out.Font = new Font("Segoe UI", 12F);
            lbl_out.Location = new Point(108, 337);
            lbl_out.Name = "lbl_out";
            lbl_out.Size = new Size(192, 45);
            lbl_out.TabIndex = 7;
            lbl_out.Text = "Output Path";
            // 
            // lbl_except
            // 
            lbl_except.AutoSize = true;
            lbl_except.Font = new Font("Segoe UI", 12F);
            lbl_except.Location = new Point(84, 135);
            lbl_except.Name = "lbl_except";
            lbl_except.Size = new Size(216, 45);
            lbl_except.TabIndex = 2;
            lbl_except.Text = "Except Sheets";
            // 
            // lbl_compare
            // 
            lbl_compare.AutoSize = true;
            lbl_compare.Font = new Font("Segoe UI", 12F);
            lbl_compare.Location = new Point(16, 36);
            lbl_compare.Name = "lbl_compare";
            lbl_compare.Size = new Size(284, 45);
            lbl_compare.TabIndex = 0;
            lbl_compare.Text = "Compare Columns";
            // 
            // pl_upload
            // 
            pl_upload.Controls.Add(lbl_message);
            pl_upload.Controls.Add(lbl_upload);
            pl_upload.Controls.Add(lbl_uploadStatus);
            pl_upload.Controls.Add(btn_upload);
            pl_upload.Location = new Point(21, 27);
            pl_upload.Name = "pl_upload";
            pl_upload.Size = new Size(1649, 200);
            pl_upload.TabIndex = 3;
            // 
            // lbl_message
            // 
            lbl_message.AutoSize = true;
            lbl_message.ForeColor = SystemColors.ControlDark;
            lbl_message.Location = new Point(27, 80);
            lbl_message.Name = "lbl_message";
            lbl_message.Size = new Size(122, 32);
            lbl_message.TabIndex = 3;
            lbl_message.Text = "message...";
            // 
            // lbl_upload
            // 
            lbl_upload.AutoSize = true;
            lbl_upload.Font = new Font("Segoe UI", 12F);
            lbl_upload.Location = new Point(16, 13);
            lbl_upload.Name = "lbl_upload";
            lbl_upload.Size = new Size(217, 45);
            lbl_upload.TabIndex = 0;
            lbl_upload.Text = "Upload Excels";
            // 
            // lbl_uploadStatus
            // 
            lbl_uploadStatus.AutoSize = true;
            lbl_uploadStatus.Font = new Font("Segoe UI", 9F);
            lbl_uploadStatus.ForeColor = SystemColors.ControlDark;
            lbl_uploadStatus.Location = new Point(576, 23);
            lbl_uploadStatus.Name = "lbl_uploadStatus";
            lbl_uploadStatus.Size = new Size(185, 32);
            lbl_uploadStatus.TabIndex = 2;
            lbl_uploadStatus.Text = "selecting excel...";
            // 
            // btn_upload
            // 
            btn_upload.Font = new Font("Segoe UI", 10F);
            btn_upload.Location = new Point(272, 14);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new Size(275, 46);
            btn_upload.TabIndex = 1;
            btn_upload.Text = "select files...";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_click;
            // 
            // tab_search
            // 
            tab_search.Controls.Add(txt_notExist);
            tab_search.Controls.Add(lbl_notExist);
            tab_search.Controls.Add(txt_exist);
            tab_search.Controls.Add(lbl_exist);
            tab_search.Controls.Add(lbl_info);
            tab_search.Controls.Add(btn_clear);
            tab_search.Controls.Add(btn_search);
            tab_search.Controls.Add(txt_search);
            tab_search.Controls.Add(lbl_search);
            tab_search.Location = new Point(8, 46);
            tab_search.Name = "tab_search";
            tab_search.Padding = new Padding(3);
            tab_search.Size = new Size(1692, 1156);
            tab_search.TabIndex = 1;
            tab_search.Text = "Search";
            tab_search.UseVisualStyleBackColor = true;
            // 
            // txt_notExist
            // 
            txt_notExist.Enabled = false;
            txt_notExist.Location = new Point(192, 725);
            txt_notExist.Multiline = true;
            txt_notExist.Name = "txt_notExist";
            txt_notExist.Size = new Size(1470, 259);
            txt_notExist.TabIndex = 8;
            // 
            // lbl_notExist
            // 
            lbl_notExist.AutoSize = true;
            lbl_notExist.Font = new Font("Segoe UI", 12F);
            lbl_notExist.Location = new Point(14, 734);
            lbl_notExist.Name = "lbl_notExist";
            lbl_notExist.Size = new Size(161, 45);
            lbl_notExist.TabIndex = 7;
            lbl_notExist.Text = "Not Exists";
            // 
            // txt_exist
            // 
            txt_exist.Enabled = false;
            txt_exist.Location = new Point(192, 416);
            txt_exist.Multiline = true;
            txt_exist.Name = "txt_exist";
            txt_exist.Size = new Size(1470, 259);
            txt_exist.TabIndex = 6;
            // 
            // lbl_exist
            // 
            lbl_exist.AutoSize = true;
            lbl_exist.Font = new Font("Segoe UI", 12F);
            lbl_exist.Location = new Point(77, 416);
            lbl_exist.Name = "lbl_exist";
            lbl_exist.Size = new Size(98, 45);
            lbl_exist.TabIndex = 5;
            lbl_exist.Text = "Exists";
            // 
            // lbl_info
            // 
            lbl_info.AutoSize = true;
            lbl_info.ForeColor = SystemColors.ControlDark;
            lbl_info.Location = new Point(201, 302);
            lbl_info.Name = "lbl_info";
            lbl_info.Size = new Size(44, 32);
            lbl_info.TabIndex = 4;
            lbl_info.Text = "......";
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(1512, 288);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(150, 46);
            btn_clear.TabIndex = 3;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_click;
            // 
            // btn_search
            // 
            btn_search.Location = new Point(1336, 288);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(150, 46);
            btn_search.TabIndex = 2;
            btn_search.Text = "Search";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_click;
            // 
            // txt_search
            // 
            txt_search.Location = new Point(192, 43);
            txt_search.Multiline = true;
            txt_search.Name = "txt_search";
            txt_search.Size = new Size(1470, 214);
            txt_search.TabIndex = 1;
            // 
            // lbl_search
            // 
            lbl_search.AutoSize = true;
            lbl_search.Font = new Font("Segoe UI", 12F);
            lbl_search.Location = new Point(32, 36);
            lbl_search.Name = "lbl_search";
            lbl_search.Size = new Size(143, 45);
            lbl_search.TabIndex = 0;
            lbl_search.Text = "Keyword";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1732, 1246);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Excel Repeat Data";
            tabControl1.ResumeLayout(false);
            tab_import.ResumeLayout(false);
            pl_setting.ResumeLayout(false);
            pl_setting.PerformLayout();
            pl_upload.ResumeLayout(false);
            pl_upload.PerformLayout();
            tab_search.ResumeLayout(false);
            tab_search.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tab_import;
        private TabPage tab_search;
        private Label lbl_upload;
        private Button btn_upload;
        private OpenFileDialog openFileDialog1;
        private Panel pl_upload;
        private Label lbl_uploadStatus;
        private Panel pl_setting;
        private Label lbl_compare;
        private Label lbl_file;
        private Label lbl_log;
        private Label lbl_out;
        private Label lbl_except;
        private TextBox txt_compare;
        private TextBox txt_file;
        private TextBox txt_except;
        private Button btn_log;
        private TextBox txt_out;
        private Button btn_out;
        private TextBox txt_log;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label lbl_message;
        private Button btn_exportAll;
        private Button btn_export;
        private TextBox txt_search;
        private Label lbl_search;
        private Button btn_search;
        private Button btn_clear;
        private Label lbl_info;
        private TextBox txt_notExist;
        private Label lbl_notExist;
        private TextBox txt_exist;
        private Label lbl_exist;
    }
}
