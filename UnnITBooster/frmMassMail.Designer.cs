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
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.cmbTableNames = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdReload = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.cmdSetModule = new System.Windows.Forms.Button();
			this.cmbSelectedModule = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtEmailBody = new ExtendedTextBox.ExtTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtEmailPreview = new System.Windows.Forms.TextBox();
			this.txtEmailCC = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkEmailDryRun = new System.Windows.Forms.CheckBox();
			this.cmbEmailSubject = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbEmailTransformationRule = new System.Windows.Forms.ComboBox();
			this.lblSelectedEmail = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage4.SuspendLayout();
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
			this.cmdSelectFile.Location = new System.Drawing.Point(850, 6);
			this.cmdSelectFile.Name = "cmdSelectFile";
			this.cmdSelectFile.Size = new System.Drawing.Size(41, 26);
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
			this.txtExcelFileName.Location = new System.Drawing.Point(96, 6);
			this.txtExcelFileName.Name = "txtExcelFileName";
			this.txtExcelFileName.Size = new System.Drawing.Size(748, 26);
			this.txtExcelFileName.TabIndex = 9;
			this.txtExcelFileName.TabStop = false;
			this.txtExcelFileName.WordWrap = false;
			this.txtExcelFileName.TextChanged += new System.EventHandler(this.txtExcelFileName_TextChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tabControl2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1026, 134);
			this.panel1.TabIndex = 11;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Location = new System.Drawing.Point(6, 9);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(1009, 113);
			this.tabControl2.TabIndex = 16;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.txtExcelFileName);
			this.tabPage1.Controls.Add(this.cmbTableNames);
			this.tabPage1.Controls.Add(this.cmdSelectFile);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.cmdReload);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1001, 80);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Database";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 20);
			this.label5.TabIndex = 11;
			this.label5.Text = "Database:";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(850, 35);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(145, 27);
			this.button2.TabIndex = 15;
			this.button2.TabStop = false;
			this.button2.Text = "Load table";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// cmbTableNames
			// 
			this.cmbTableNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTableNames.FormattingEnabled = true;
			this.cmbTableNames.Location = new System.Drawing.Point(96, 34);
			this.cmbTableNames.Margin = new System.Windows.Forms.Padding(2);
			this.cmbTableNames.Name = "cmbTableNames";
			this.cmbTableNames.Size = new System.Drawing.Size(748, 28);
			this.cmbTableNames.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 20);
			this.label3.TabIndex = 13;
			this.label3.Text = "Table:";
			// 
			// cmdReload
			// 
			this.cmdReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdReload.Location = new System.Drawing.Point(897, 6);
			this.cmdReload.Name = "cmdReload";
			this.cmdReload.Size = new System.Drawing.Size(98, 26);
			this.cmdReload.TabIndex = 12;
			this.cmdReload.TabStop = false;
			this.cmdReload.Text = "Refresh";
			this.cmdReload.UseVisualStyleBackColor = true;
			this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.cmdSetModule);
			this.tabPage4.Controls.Add(this.cmbSelectedModule);
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Location = new System.Drawing.Point(4, 29);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(1001, 80);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Student repo";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// cmdSetModule
			// 
			this.cmdSetModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSetModule.Location = new System.Drawing.Point(761, 6);
			this.cmdSetModule.Name = "cmdSetModule";
			this.cmdSetModule.Size = new System.Drawing.Size(145, 27);
			this.cmdSetModule.TabIndex = 17;
			this.cmdSetModule.TabStop = false;
			this.cmdSetModule.Text = "Set";
			this.cmdSetModule.UseVisualStyleBackColor = true;
			this.cmdSetModule.Click += new System.EventHandler(this.cmdSetModule_Click);
			// 
			// cmbSelectedModule
			// 
			this.cmbSelectedModule.FormattingEnabled = true;
			this.cmbSelectedModule.Location = new System.Drawing.Point(103, 5);
			this.cmbSelectedModule.Margin = new System.Windows.Forms.Padding(2);
			this.cmbSelectedModule.Name = "cmbSelectedModule";
			this.cmbSelectedModule.Size = new System.Drawing.Size(653, 28);
			this.cmbSelectedModule.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 20);
			this.label4.TabIndex = 15;
			this.label4.Text = "Module";
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
			this.tabControl1.Location = new System.Drawing.Point(0, 134);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1026, 633);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainer3);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1018, 600);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Emailing";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(3, 3);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.label6);
			this.splitContainer3.Panel1.Controls.Add(this.cmbEmailTransformationRule);
			this.splitContainer3.Panel1.Controls.Add(this.label1);
			this.splitContainer3.Panel1.Controls.Add(this.cmbEmailField);
			this.splitContainer3.Panel1.Controls.Add(this.cmdSelectAll);
			this.splitContainer3.Panel1.Controls.Add(this.lstEmailSendSelection);
			this.splitContainer3.Panel1.Controls.Add(this.cmdEmailRefreshStudents);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.splitContainer1);
			this.splitContainer3.Panel2.Controls.Add(this.txtEmailCC);
			this.splitContainer3.Panel2.Controls.Add(this.label2);
			this.splitContainer3.Panel2.Controls.Add(this.chkEmailDryRun);
			this.splitContainer3.Panel2.Controls.Add(this.cmbEmailSubject);
			this.splitContainer3.Panel2.Controls.Add(this.label10);
			this.splitContainer3.Panel2.Controls.Add(this.button3);
			this.splitContainer3.Size = new System.Drawing.Size(1012, 594);
			this.splitContainer3.SplitterDistance = 319;
			this.splitContainer3.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 527);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Email field:";
			// 
			// cmbEmailField
			// 
			this.cmbEmailField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbEmailField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmailField.FormattingEnabled = true;
			this.cmbEmailField.Location = new System.Drawing.Point(133, 524);
			this.cmbEmailField.Margin = new System.Windows.Forms.Padding(2);
			this.cmbEmailField.Name = "cmbEmailField";
			this.cmbEmailField.Size = new System.Drawing.Size(174, 28);
			this.cmbEmailField.TabIndex = 5;
			// 
			// cmdSelectAll
			// 
			this.cmdSelectAll.Location = new System.Drawing.Point(142, 3);
			this.cmdSelectAll.Name = "cmdSelectAll";
			this.cmdSelectAll.Size = new System.Drawing.Size(117, 32);
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
			this.lstEmailSendSelection.HideSelection = false;
			this.lstEmailSendSelection.Location = new System.Drawing.Point(3, 41);
			this.lstEmailSendSelection.Name = "lstEmailSendSelection";
			this.lstEmailSendSelection.Size = new System.Drawing.Size(314, 478);
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
			this.cmdEmailRefreshStudents.Location = new System.Drawing.Point(3, 3);
			this.cmdEmailRefreshStudents.Name = "cmdEmailRefreshStudents";
			this.cmdEmailRefreshStudents.Size = new System.Drawing.Size(135, 32);
			this.cmdEmailRefreshStudents.TabIndex = 2;
			this.cmdEmailRefreshStudents.Text = "Refresh";
			this.cmdEmailRefreshStudents.UseVisualStyleBackColor = true;
			this.cmdEmailRefreshStudents.Click += new System.EventHandler(this.cmdEmailRefreshStudents_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(6, 96);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lblSelectedEmail);
			this.splitContainer1.Panel1.Controls.Add(this.txtEmailBody);
			this.splitContainer1.Panel1.Controls.Add(this.button1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtEmailPreview);
			this.splitContainer1.Size = new System.Drawing.Size(679, 493);
			this.splitContainer1.SplitterDistance = 243;
			this.splitContainer1.SplitterWidth = 2;
			this.splitContainer1.TabIndex = 11;
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
			this.txtEmailBody.Location = new System.Drawing.Point(3, 4);
			this.txtEmailBody.Margin = new System.Windows.Forms.Padding(6);
			this.txtEmailBody.MaxLength = 0;
			this.txtEmailBody.Name = "txtEmailBody";
			this.txtEmailBody.OriginalText = "";
			this.txtEmailBody.Size = new System.Drawing.Size(670, 199);
			this.txtEmailBody.SpellCheck = true;
			this.txtEmailBody.TabIndex = 6;
			this.txtEmailBody.TabStop = false;
			this.txtEmailBody.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			this.txtEmailBody.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			this.txtEmailBody.Wrapping = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(538, 210);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(135, 30);
			this.button1.TabIndex = 10;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// txtEmailPreview
			// 
			this.txtEmailPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEmailPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmailPreview.Location = new System.Drawing.Point(0, 0);
			this.txtEmailPreview.Multiline = true;
			this.txtEmailPreview.Name = "txtEmailPreview";
			this.txtEmailPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEmailPreview.Size = new System.Drawing.Size(679, 248);
			this.txtEmailPreview.TabIndex = 7;
			this.txtEmailPreview.TabStop = false;
			// 
			// txtEmailCC
			// 
			this.txtEmailCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmailCC.Location = new System.Drawing.Point(74, 69);
			this.txtEmailCC.Name = "txtEmailCC";
			this.txtEmailCC.Size = new System.Drawing.Size(607, 26);
			this.txtEmailCC.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "cc";
			// 
			// chkEmailDryRun
			// 
			this.chkEmailDryRun.AutoSize = true;
			this.chkEmailDryRun.Checked = true;
			this.chkEmailDryRun.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEmailDryRun.Location = new System.Drawing.Point(74, 11);
			this.chkEmailDryRun.Name = "chkEmailDryRun";
			this.chkEmailDryRun.Size = new System.Drawing.Size(86, 24);
			this.chkEmailDryRun.TabIndex = 4;
			this.chkEmailDryRun.Text = "Dry Run";
			this.chkEmailDryRun.UseVisualStyleBackColor = true;
			// 
			// cmbEmailSubject
			// 
			this.cmbEmailSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbEmailSubject.Location = new System.Drawing.Point(74, 41);
			this.cmbEmailSubject.Name = "cmbEmailSubject";
			this.cmbEmailSubject.Size = new System.Drawing.Size(607, 28);
			this.cmbEmailSubject.TabIndex = 3;
			this.cmbEmailSubject.SelectedValueChanged += new System.EventHandler(this.cmbEmailSubject_SelectedValueChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 45);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 20);
			this.label10.TabIndex = 2;
			this.label10.Text = "Subject";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(544, 6);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(135, 29);
			this.button3.TabIndex = 0;
			this.button3.Text = "Send";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 29);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage3.Size = new System.Drawing.Size(1018, 600);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Tools";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 559);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(124, 20);
			this.label6.TabIndex = 8;
			this.label6.Text = "Email transform:";
			// 
			// cmbEmailTransformationRule
			// 
			this.cmbEmailTransformationRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbEmailTransformationRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmailTransformationRule.FormattingEnabled = true;
			this.cmbEmailTransformationRule.Location = new System.Drawing.Point(133, 556);
			this.cmbEmailTransformationRule.Margin = new System.Windows.Forms.Padding(2);
			this.cmbEmailTransformationRule.Name = "cmbEmailTransformationRule";
			this.cmbEmailTransformationRule.Size = new System.Drawing.Size(174, 28);
			this.cmbEmailTransformationRule.TabIndex = 7;
			// 
			// lblSelectedEmail
			// 
			this.lblSelectedEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSelectedEmail.AutoSize = true;
			this.lblSelectedEmail.Location = new System.Drawing.Point(2, 215);
			this.lblSelectedEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblSelectedEmail.Name = "lblSelectedEmail";
			this.lblSelectedEmail.Size = new System.Drawing.Size(128, 20);
			this.lblSelectedEmail.TabIndex = 11;
			this.lblSelectedEmail.Text = "<selected email>";
			// 
			// frmMassMail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1026, 767);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frmMassMail";
			this.Text = "Mass mailing";
			this.panel1.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel1.PerformLayout();
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbEmailSubject;
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
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cmbSelectedModule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdSetModule;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbEmailTransformationRule;
		private System.Windows.Forms.Label lblSelectedEmail;
	}
}

