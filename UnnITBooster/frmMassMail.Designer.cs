using ExtendedTextBox;

namespace StudentMarking
{
    partial class frmMassMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdSelectFile = new System.Windows.Forms.Button();
            this.txtExcelFileName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdReload = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmailField = new System.Windows.Forms.ComboBox();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.lstEmailSendSelection = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdEmailRefreshStudents = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEmailCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailBody = new ExtendedTextBox.ExtTextBox();
            this.txtEmailPreview = new System.Windows.Forms.TextBox();
            this.chkEmailDryRun = new System.Windows.Forms.CheckBox();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTableNames = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSelectFile
            // 
            this.cmdSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectFile.Location = new System.Drawing.Point(1316, 3);
            this.cmdSelectFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdSelectFile.Name = "cmdSelectFile";
            this.cmdSelectFile.Size = new System.Drawing.Size(72, 40);
            this.cmdSelectFile.TabIndex = 10;
            this.cmdSelectFile.TabStop = false;
            this.cmdSelectFile.Text = "...";
            this.cmdSelectFile.UseVisualStyleBackColor = true;
            this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
            // 
            // txtExcelFileName
            // 
            this.txtExcelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcelFileName.Location = new System.Drawing.Point(163, 6);
            this.txtExcelFileName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtExcelFileName.Multiline = true;
            this.txtExcelFileName.Name = "txtExcelFileName";
            this.txtExcelFileName.Size = new System.Drawing.Size(1140, 37);
            this.txtExcelFileName.TabIndex = 9;
            this.txtExcelFileName.TabStop = false;
            this.txtExcelFileName.TextChanged += new System.EventHandler(this.txtExcelFileName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cmbTableNames);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmdReload);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmdSelectFile);
            this.panel1.Controls.Add(this.txtExcelFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1495, 111);
            this.panel1.TabIndex = 11;
            // 
            // cmdReload
            // 
            this.cmdReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReload.Location = new System.Drawing.Point(1398, 3);
            this.cmdReload.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdReload.Name = "cmdReload";
            this.cmdReload.Size = new System.Drawing.Size(92, 40);
            this.cmdReload.TabIndex = 12;
            this.cmdReload.TabStop = false;
            this.cmdReload.Text = "Refresh";
            this.cmdReload.UseVisualStyleBackColor = true;
            this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Database:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 111);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1495, 1008);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 41);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Size = new System.Drawing.Size(1487, 963);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Emailing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(6, 6);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.cmbEmailField);
            this.splitContainer3.Panel1.Controls.Add(this.cmdSelectAll);
            this.splitContainer3.Panel1.Controls.Add(this.lstEmailSendSelection);
            this.splitContainer3.Panel1.Controls.Add(this.cmdEmailRefreshStudents);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            this.splitContainer3.Panel2.Controls.Add(this.txtEmailCC);
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Panel2.Controls.Add(this.chkEmailDryRun);
            this.splitContainer3.Panel2.Controls.Add(this.txtEmailSubject);
            this.splitContainer3.Panel2.Controls.Add(this.label10);
            this.splitContainer3.Panel2.Controls.Add(this.button3);
            this.splitContainer3.Size = new System.Drawing.Size(1475, 951);
            this.splitContainer3.SplitterDistance = 466;
            this.splitContainer3.SplitterWidth = 7;
            this.splitContainer3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 901);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email";
            // 
            // cmbEmailField
            // 
            this.cmbEmailField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbEmailField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmailField.FormattingEnabled = true;
            this.cmbEmailField.Location = new System.Drawing.Point(99, 901);
            this.cmbEmailField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbEmailField.Name = "cmbEmailField";
            this.cmbEmailField.Size = new System.Drawing.Size(361, 40);
            this.cmbEmailField.TabIndex = 5;
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Location = new System.Drawing.Point(248, 6);
            this.cmdSelectAll.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(138, 42);
            this.cmdSelectAll.TabIndex = 4;
            this.cmdSelectAll.Text = "All";
            this.cmdSelectAll.UseVisualStyleBackColor = true;
            this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
            // 
            // lstEmailSendSelection
            // 
            this.lstEmailSendSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEmailSendSelection.CheckBoxes = true;
            this.lstEmailSendSelection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstEmailSendSelection.FullRowSelect = true;
            this.lstEmailSendSelection.GridLines = true;
            this.lstEmailSendSelection.Location = new System.Drawing.Point(6, 57);
            this.lstEmailSendSelection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstEmailSendSelection.Name = "lstEmailSendSelection";
            this.lstEmailSendSelection.Size = new System.Drawing.Size(454, 835);
            this.lstEmailSendSelection.TabIndex = 3;
            this.lstEmailSendSelection.UseCompatibleStateImageBehavior = false;
            this.lstEmailSendSelection.View = System.Windows.Forms.View.Details;
            this.lstEmailSendSelection.SelectedIndexChanged += new System.EventHandler(this.lstEmailSendSelection_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "# Marks";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mark";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "InternalID";
            // 
            // cmdEmailRefreshStudents
            // 
            this.cmdEmailRefreshStudents.Location = new System.Drawing.Point(6, 6);
            this.cmdEmailRefreshStudents.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdEmailRefreshStudents.Name = "cmdEmailRefreshStudents";
            this.cmdEmailRefreshStudents.Size = new System.Drawing.Size(236, 42);
            this.cmdEmailRefreshStudents.TabIndex = 2;
            this.cmdEmailRefreshStudents.Text = "Refresh";
            this.cmdEmailRefreshStudents.UseVisualStyleBackColor = true;
            this.cmdEmailRefreshStudents.Click += new System.EventHandler(this.cmdEmailRefreshStudents_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 42);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEmailCC
            // 
            this.txtEmailCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailCC.Location = new System.Drawing.Point(129, 120);
            this.txtEmailCC.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtEmailCC.Name = "txtEmailCC";
            this.txtEmailCC.Size = new System.Drawing.Size(859, 39);
            this.txtEmailCC.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "cc";
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.AcceptsReturn = true;
            this.txtEmailBody.AcceptsTab = true;
            this.txtEmailBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailBody.ChangedColour = System.Drawing.Color.Empty;
            this.txtEmailBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailBody.Location = new System.Drawing.Point(6, 7);
            this.txtEmailBody.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.txtEmailBody.MaxLength = 0;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.OriginalText = "";
            this.txtEmailBody.Size = new System.Drawing.Size(971, 369);
            this.txtEmailBody.SpellCheck = true;
            this.txtEmailBody.TabIndex = 6;
            this.txtEmailBody.TabStop = false;
            this.txtEmailBody.TextCase = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmailBody.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
            this.txtEmailBody.Wrapping = true;
            this.txtEmailBody.TextChanged += new System.EventHandler(this.txtEmailBody_TextChanged);
            // 
            // txtEmailPreview
            // 
            this.txtEmailPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailPreview.Location = new System.Drawing.Point(6, 6);
            this.txtEmailPreview.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtEmailPreview.Multiline = true;
            this.txtEmailPreview.Name = "txtEmailPreview";
            this.txtEmailPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailPreview.Size = new System.Drawing.Size(976, 371);
            this.txtEmailPreview.TabIndex = 7;
            this.txtEmailPreview.TabStop = false;
            this.txtEmailPreview.Text = "Dear {SUB_FirstName}, \r\nThe marking and moderation process for BE1178 has been co" +
    "mpleted a few days ago. \r\nPlease find your feedback after my signature.\r\nBest re" +
    "gards, \r\nClaudio \r\n\r\n{MarkReport}";
            // 
            // chkEmailDryRun
            // 
            this.chkEmailDryRun.AutoSize = true;
            this.chkEmailDryRun.Checked = true;
            this.chkEmailDryRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmailDryRun.Location = new System.Drawing.Point(507, 10);
            this.chkEmailDryRun.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkEmailDryRun.Name = "chkEmailDryRun";
            this.chkEmailDryRun.Size = new System.Drawing.Size(143, 36);
            this.chkEmailDryRun.TabIndex = 4;
            this.chkEmailDryRun.Text = "Dry Run";
            this.chkEmailDryRun.UseVisualStyleBackColor = true;
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailSubject.Location = new System.Drawing.Point(129, 72);
            this.txtEmailSubject.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(859, 39);
            this.txtEmailSubject.TabIndex = 3;
            this.txtEmailSubject.TextChanged += new System.EventHandler(this.txtEmailSubject_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 32);
            this.label10.TabIndex = 2;
            this.label10.Text = "Subject";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(236, 42);
            this.button3.TabIndex = 0;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Size = new System.Drawing.Size(1487, 1011);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tools";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 32);
            this.label3.TabIndex = 13;
            this.label3.Text = "Table:";
            // 
            // cmbTableNames
            // 
            this.cmbTableNames.FormattingEnabled = true;
            this.cmbTableNames.Location = new System.Drawing.Point(163, 54);
            this.cmbTableNames.Name = "cmbTableNames";
            this.cmbTableNames.Size = new System.Drawing.Size(1140, 40);
            this.cmbTableNames.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1316, 49);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 40);
            this.button2.TabIndex = 15;
            this.button2.TabStop = false;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(11, 168);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtEmailBody);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtEmailPreview);
            this.splitContainer1.Size = new System.Drawing.Size(988, 773);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 11;
            // 
            // frmMassMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1495, 1119);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmMassMail";
            this.Text = "Mass mailing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.TextBox txtExcelFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cmdEmailRefreshStudents;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lstEmailSendSelection;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkEmailDryRun;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button cmdReload;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private ExtendedTextBox.ExtTextBox txtEmailBody;
        private System.Windows.Forms.TextBox txtEmailPreview;
        private System.Windows.Forms.ComboBox cmbEmailField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmailCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbTableNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

