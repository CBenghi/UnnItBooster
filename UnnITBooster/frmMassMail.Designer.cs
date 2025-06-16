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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMassMail));
			cmdSelectFile = new System.Windows.Forms.Button();
			txtExcelFileName = new System.Windows.Forms.TextBox();
			panel1 = new System.Windows.Forms.Panel();
			tabControl2 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			label5 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			cmbTableNames = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			cmdReload = new System.Windows.Forms.Button();
			tabPage4 = new System.Windows.Forms.TabPage();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			cmbSelectedModule = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			cmdSetModule = new System.Windows.Forms.Button();
			openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage2 = new System.Windows.Forms.TabPage();
			splitContainer3 = new System.Windows.Forms.SplitContainer();
			lstEmailSendSelection = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			label7 = new System.Windows.Forms.Label();
			cmbIdField = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			cmbEmailTransformationRule = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			cmbEmailField = new System.Windows.Forms.ComboBox();
			cmdSelectAll = new System.Windows.Forms.Button();
			cmdEmailRefreshStudents = new System.Windows.Forms.Button();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			txtEmailBody = new ExtTextBox();
			lblSelectedEmail = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			splitContainer2 = new System.Windows.Forms.SplitContainer();
			txtEmailPreview = new System.Windows.Forms.TextBox();
			StudImage = new System.Windows.Forms.PictureBox();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			cmdSend = new System.Windows.Forms.Button();
			chkEmailDryRun = new System.Windows.Forms.CheckBox();
			cmbEmailSubject = new System.Windows.Forms.ComboBox();
			txtEmailCC = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			lblCC = new System.Windows.Forms.Label();
			tabPage3 = new System.Windows.Forms.TabPage();
			panel1.SuspendLayout();
			tabControl2.SuspendLayout();
			tabPage1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			tabPage4.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
			splitContainer3.Panel1.SuspendLayout();
			splitContainer3.Panel2.SuspendLayout();
			splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)StudImage).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// cmdSelectFile
			// 
			cmdSelectFile.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			cmdSelectFile.Location = new System.Drawing.Point(847, 5);
			cmdSelectFile.Name = "cmdSelectFile";
			cmdSelectFile.Size = new System.Drawing.Size(41, 26);
			cmdSelectFile.TabIndex = 10;
			cmdSelectFile.TabStop = false;
			cmdSelectFile.Text = "...";
			cmdSelectFile.UseVisualStyleBackColor = true;
			cmdSelectFile.Click += cmdSelectFile_Click;
			// 
			// txtExcelFileName
			// 
			txtExcelFileName.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtExcelFileName.Location = new System.Drawing.Point(92, 5);
			txtExcelFileName.Name = "txtExcelFileName";
			txtExcelFileName.Size = new System.Drawing.Size(749, 26);
			txtExcelFileName.TabIndex = 9;
			txtExcelFileName.TabStop = false;
			txtExcelFileName.WordWrap = false;
			txtExcelFileName.TextChanged += txtExcelFileName_TextChanged;
			// 
			// panel1
			// 
			panel1.Controls.Add(tabControl2);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1026, 134);
			panel1.TabIndex = 11;
			// 
			// tabControl2
			// 
			tabControl2.Controls.Add(tabPage1);
			tabControl2.Controls.Add(tabPage4);
			tabControl2.Location = new System.Drawing.Point(6, 9);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabControl2.Size = new System.Drawing.Size(1009, 113);
			tabControl2.TabIndex = 16;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(tableLayoutPanel1);
			tabPage1.Location = new System.Drawing.Point(4, 29);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(1001, 80);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Database";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(label5, 0, 0);
			tableLayoutPanel1.Controls.Add(button2, 2, 1);
			tableLayoutPanel1.Controls.Add(txtExcelFileName, 1, 0);
			tableLayoutPanel1.Controls.Add(cmbTableNames, 1, 1);
			tableLayoutPanel1.Controls.Add(cmdSelectFile, 2, 0);
			tableLayoutPanel1.Controls.Add(label3, 0, 1);
			tableLayoutPanel1.Controls.Add(cmdReload, 3, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new System.Drawing.Size(995, 74);
			tableLayoutPanel1.TabIndex = 17;
			// 
			// label5
			// 
			label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(3, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(83, 20);
			label5.TabIndex = 11;
			label5.Text = "Database:";
			// 
			// button2
			// 
			button2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(button2, 2);
			button2.Location = new System.Drawing.Point(847, 42);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(145, 27);
			button2.TabIndex = 15;
			button2.TabStop = false;
			button2.Text = "Load table";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// cmbTableNames
			// 
			cmbTableNames.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			cmbTableNames.FormattingEnabled = true;
			cmbTableNames.Location = new System.Drawing.Point(91, 41);
			cmbTableNames.Margin = new System.Windows.Forms.Padding(2);
			cmbTableNames.Name = "cmbTableNames";
			cmbTableNames.Size = new System.Drawing.Size(751, 28);
			cmbTableNames.TabIndex = 14;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 45);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(52, 20);
			label3.TabIndex = 13;
			label3.Text = "Table:";
			// 
			// cmdReload
			// 
			cmdReload.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			cmdReload.Location = new System.Drawing.Point(894, 5);
			cmdReload.Name = "cmdReload";
			cmdReload.Size = new System.Drawing.Size(98, 26);
			cmdReload.TabIndex = 12;
			cmdReload.TabStop = false;
			cmdReload.Text = "Refresh";
			cmdReload.UseVisualStyleBackColor = true;
			cmdReload.Click += cmdReload_Click;
			// 
			// tabPage4
			// 
			tabPage4.Controls.Add(tableLayoutPanel2);
			tabPage4.Location = new System.Drawing.Point(4, 24);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new System.Windows.Forms.Padding(3);
			tabPage4.Size = new System.Drawing.Size(1001, 85);
			tabPage4.TabIndex = 1;
			tabPage4.Text = "Student repo";
			tabPage4.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel2.Controls.Add(cmbSelectedModule, 1, 0);
			tableLayoutPanel2.Controls.Add(label4, 0, 0);
			tableLayoutPanel2.Controls.Add(cmdSetModule, 2, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new System.Drawing.Size(995, 79);
			tableLayoutPanel2.TabIndex = 18;
			// 
			// cmbSelectedModule
			// 
			cmbSelectedModule.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			cmbSelectedModule.FormattingEnabled = true;
			cmbSelectedModule.Location = new System.Drawing.Point(69, 25);
			cmbSelectedModule.Margin = new System.Windows.Forms.Padding(2);
			cmbSelectedModule.Name = "cmbSelectedModule";
			cmbSelectedModule.Size = new System.Drawing.Size(773, 28);
			cmbSelectedModule.TabIndex = 16;
			// 
			// label4
			// 
			label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 29);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(61, 20);
			label4.TabIndex = 15;
			label4.Text = "Module";
			// 
			// cmdSetModule
			// 
			cmdSetModule.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cmdSetModule.Location = new System.Drawing.Point(847, 26);
			cmdSetModule.Name = "cmdSetModule";
			cmdSetModule.Size = new System.Drawing.Size(145, 27);
			cmdSetModule.TabIndex = 17;
			cmdSetModule.TabStop = false;
			cmdSetModule.Text = "Set";
			cmdSetModule.UseVisualStyleBackColor = true;
			cmdSetModule.Click += cmdSetModule_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 134);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(1026, 633);
			tabControl1.TabIndex = 12;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(splitContainer3);
			tabPage2.Location = new System.Drawing.Point(4, 29);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(1018, 600);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Emailing";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer3.Location = new System.Drawing.Point(3, 3);
			splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			splitContainer3.Panel1.Controls.Add(lstEmailSendSelection);
			splitContainer3.Panel1.Controls.Add(label7);
			splitContainer3.Panel1.Controls.Add(cmbIdField);
			splitContainer3.Panel1.Controls.Add(label6);
			splitContainer3.Panel1.Controls.Add(cmbEmailTransformationRule);
			splitContainer3.Panel1.Controls.Add(label1);
			splitContainer3.Panel1.Controls.Add(cmbEmailField);
			splitContainer3.Panel1.Controls.Add(cmdSelectAll);
			splitContainer3.Panel1.Controls.Add(cmdEmailRefreshStudents);
			// 
			// splitContainer3.Panel2
			// 
			splitContainer3.Panel2.Controls.Add(splitContainer1);
			splitContainer3.Panel2.Controls.Add(tableLayoutPanel3);
			splitContainer3.Size = new System.Drawing.Size(1012, 594);
			splitContainer3.SplitterDistance = 319;
			splitContainer3.TabIndex = 3;
			// 
			// lstEmailSendSelection
			// 
			lstEmailSendSelection.CheckBoxes = true;
			lstEmailSendSelection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
			lstEmailSendSelection.Dock = System.Windows.Forms.DockStyle.Fill;
			lstEmailSendSelection.FullRowSelect = true;
			lstEmailSendSelection.GridLines = true;
			lstEmailSendSelection.Location = new System.Drawing.Point(0, 64);
			lstEmailSendSelection.Name = "lstEmailSendSelection";
			lstEmailSendSelection.Size = new System.Drawing.Size(319, 386);
			lstEmailSendSelection.TabIndex = 3;
			lstEmailSendSelection.UseCompatibleStateImageBehavior = false;
			lstEmailSendSelection.View = System.Windows.Forms.View.Details;
			lstEmailSendSelection.SelectedIndexChanged += lstEmailSendSelection_SelectedIndexChanged;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Name";
			columnHeader1.Width = 146;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "# Marks";
			columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Mark";
			columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "InternalID";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Dock = System.Windows.Forms.DockStyle.Bottom;
			label7.Location = new System.Drawing.Point(0, 450);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(105, 20);
			label7.TabIndex = 10;
			label7.Text = "ID Foto Field:";
			// 
			// cmbIdField
			// 
			cmbIdField.Dock = System.Windows.Forms.DockStyle.Bottom;
			cmbIdField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbIdField.FormattingEnabled = true;
			cmbIdField.Location = new System.Drawing.Point(0, 470);
			cmbIdField.Margin = new System.Windows.Forms.Padding(2);
			cmbIdField.Name = "cmbIdField";
			cmbIdField.Size = new System.Drawing.Size(319, 28);
			cmbIdField.TabIndex = 9;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Dock = System.Windows.Forms.DockStyle.Bottom;
			label6.Location = new System.Drawing.Point(0, 498);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(124, 20);
			label6.TabIndex = 8;
			label6.Text = "Email transform:";
			// 
			// cmbEmailTransformationRule
			// 
			cmbEmailTransformationRule.Dock = System.Windows.Forms.DockStyle.Bottom;
			cmbEmailTransformationRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbEmailTransformationRule.FormattingEnabled = true;
			cmbEmailTransformationRule.Location = new System.Drawing.Point(0, 518);
			cmbEmailTransformationRule.Margin = new System.Windows.Forms.Padding(2);
			cmbEmailTransformationRule.Name = "cmbEmailTransformationRule";
			cmbEmailTransformationRule.Size = new System.Drawing.Size(319, 28);
			cmbEmailTransformationRule.TabIndex = 7;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Dock = System.Windows.Forms.DockStyle.Bottom;
			label1.Location = new System.Drawing.Point(0, 546);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(85, 20);
			label1.TabIndex = 6;
			label1.Text = "Email field:";
			// 
			// cmbEmailField
			// 
			cmbEmailField.Dock = System.Windows.Forms.DockStyle.Bottom;
			cmbEmailField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbEmailField.FormattingEnabled = true;
			cmbEmailField.Location = new System.Drawing.Point(0, 566);
			cmbEmailField.Margin = new System.Windows.Forms.Padding(2);
			cmbEmailField.Name = "cmbEmailField";
			cmbEmailField.Size = new System.Drawing.Size(319, 28);
			cmbEmailField.TabIndex = 5;
			// 
			// cmdSelectAll
			// 
			cmdSelectAll.Dock = System.Windows.Forms.DockStyle.Top;
			cmdSelectAll.Location = new System.Drawing.Point(0, 32);
			cmdSelectAll.Name = "cmdSelectAll";
			cmdSelectAll.Size = new System.Drawing.Size(319, 32);
			cmdSelectAll.TabIndex = 4;
			cmdSelectAll.Text = "All";
			cmdSelectAll.UseVisualStyleBackColor = true;
			cmdSelectAll.Click += cmdSelectAll_Click;
			// 
			// cmdEmailRefreshStudents
			// 
			cmdEmailRefreshStudents.Dock = System.Windows.Forms.DockStyle.Top;
			cmdEmailRefreshStudents.Location = new System.Drawing.Point(0, 0);
			cmdEmailRefreshStudents.Name = "cmdEmailRefreshStudents";
			cmdEmailRefreshStudents.Size = new System.Drawing.Size(319, 32);
			cmdEmailRefreshStudents.TabIndex = 2;
			cmdEmailRefreshStudents.Text = "Refresh";
			cmdEmailRefreshStudents.UseVisualStyleBackColor = true;
			cmdEmailRefreshStudents.Click += cmdEmailRefreshStudents_Click;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 114);
			splitContainer1.Margin = new System.Windows.Forms.Padding(2);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(txtEmailBody);
			splitContainer1.Panel1.Controls.Add(lblSelectedEmail);
			splitContainer1.Panel1.Controls.Add(button1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new System.Drawing.Size(689, 480);
			splitContainer1.SplitterDistance = 235;
			splitContainer1.SplitterWidth = 2;
			splitContainer1.TabIndex = 11;
			// 
			// txtEmailBody
			// 
			txtEmailBody.AcceptsReturn = true;
			txtEmailBody.AcceptsTab = true;
			txtEmailBody.ChangedColour = System.Drawing.Color.Empty;
			txtEmailBody.Dock = System.Windows.Forms.DockStyle.Fill;
			txtEmailBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEmailBody.Location = new System.Drawing.Point(0, 0);
			txtEmailBody.Margin = new System.Windows.Forms.Padding(6);
			txtEmailBody.MaxLength = 0;
			txtEmailBody.Name = "txtEmailBody";
			txtEmailBody.OriginalText = "";
			txtEmailBody.Size = new System.Drawing.Size(689, 174);
			txtEmailBody.SpellCheck = true;
			txtEmailBody.TabIndex = 6;
			txtEmailBody.TabStop = false;
			txtEmailBody.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			txtEmailBody.TextType = ExtTextBox.TextTypes.String;
			txtEmailBody.Wrapping = true;
			// 
			// lblSelectedEmail
			// 
			lblSelectedEmail.AutoSize = true;
			lblSelectedEmail.Dock = System.Windows.Forms.DockStyle.Bottom;
			lblSelectedEmail.Location = new System.Drawing.Point(0, 174);
			lblSelectedEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			lblSelectedEmail.Name = "lblSelectedEmail";
			lblSelectedEmail.Size = new System.Drawing.Size(128, 20);
			lblSelectedEmail.TabIndex = 11;
			lblSelectedEmail.Text = "<selected email>";
			// 
			// button1
			// 
			button1.Dock = System.Windows.Forms.DockStyle.Bottom;
			button1.Location = new System.Drawing.Point(0, 194);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(689, 41);
			button1.TabIndex = 10;
			button1.Text = "Save";
			button1.UseVisualStyleBackColor = true;
			button1.Click += Button1_Click;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer2.Location = new System.Drawing.Point(0, 0);
			splitContainer2.Margin = new System.Windows.Forms.Padding(2);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(txtEmailPreview);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(StudImage);
			splitContainer2.Size = new System.Drawing.Size(689, 243);
			splitContainer2.SplitterDistance = 436;
			splitContainer2.SplitterWidth = 2;
			splitContainer2.TabIndex = 12;
			// 
			// txtEmailPreview
			// 
			txtEmailPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			txtEmailPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEmailPreview.Location = new System.Drawing.Point(0, 0);
			txtEmailPreview.Multiline = true;
			txtEmailPreview.Name = "txtEmailPreview";
			txtEmailPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtEmailPreview.Size = new System.Drawing.Size(436, 243);
			txtEmailPreview.TabIndex = 7;
			txtEmailPreview.TabStop = false;
			// 
			// StudImage
			// 
			StudImage.BackColor = System.Drawing.Color.Gray;
			StudImage.Dock = System.Windows.Forms.DockStyle.Fill;
			StudImage.Location = new System.Drawing.Point(0, 0);
			StudImage.Margin = new System.Windows.Forms.Padding(2);
			StudImage.Name = "StudImage";
			StudImage.Size = new System.Drawing.Size(251, 243);
			StudImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			StudImage.TabIndex = 20;
			StudImage.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(cmdSend, 1, 0);
			tableLayoutPanel3.Controls.Add(chkEmailDryRun, 0, 0);
			tableLayoutPanel3.Controls.Add(cmbEmailSubject, 1, 1);
			tableLayoutPanel3.Controls.Add(txtEmailCC, 1, 2);
			tableLayoutPanel3.Controls.Add(label10, 0, 1);
			tableLayoutPanel3.Controls.Add(lblCC, 0, 2);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 3;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
			tableLayoutPanel3.Size = new System.Drawing.Size(689, 114);
			tableLayoutPanel3.TabIndex = 12;
			// 
			// cmdSend
			// 
			cmdSend.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cmdSend.Location = new System.Drawing.Point(95, 4);
			cmdSend.Name = "cmdSend";
			cmdSend.Size = new System.Drawing.Size(591, 29);
			cmdSend.TabIndex = 0;
			cmdSend.Text = "Send";
			cmdSend.UseVisualStyleBackColor = true;
			cmdSend.Click += send_Click;
			// 
			// chkEmailDryRun
			// 
			chkEmailDryRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			chkEmailDryRun.AutoSize = true;
			chkEmailDryRun.Checked = true;
			chkEmailDryRun.CheckState = System.Windows.Forms.CheckState.Checked;
			chkEmailDryRun.Location = new System.Drawing.Point(3, 10);
			chkEmailDryRun.Name = "chkEmailDryRun";
			chkEmailDryRun.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			chkEmailDryRun.Size = new System.Drawing.Size(86, 24);
			chkEmailDryRun.TabIndex = 4;
			chkEmailDryRun.Text = "Dry Run";
			chkEmailDryRun.UseVisualStyleBackColor = true;
			// 
			// cmbEmailSubject
			// 
			cmbEmailSubject.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cmbEmailSubject.Location = new System.Drawing.Point(95, 41);
			cmbEmailSubject.Name = "cmbEmailSubject";
			cmbEmailSubject.Size = new System.Drawing.Size(591, 28);
			cmbEmailSubject.TabIndex = 3;
			cmbEmailSubject.SelectedValueChanged += cmbEmailSubject_SelectedValueChanged;
			// 
			// txtEmailCC
			// 
			txtEmailCC.Anchor = System.Windows.Forms.AnchorStyles.Left;
			txtEmailCC.Location = new System.Drawing.Point(95, 81);
			txtEmailCC.Name = "txtEmailCC";
			txtEmailCC.Size = new System.Drawing.Size(591, 26);
			txtEmailCC.TabIndex = 9;
			// 
			// label10
			// 
			label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(3, 45);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(63, 20);
			label10.TabIndex = 2;
			label10.Text = "Subject";
			// 
			// lblCC
			// 
			lblCC.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lblCC.AutoSize = true;
			lblCC.Location = new System.Drawing.Point(3, 84);
			lblCC.Name = "lblCC";
			lblCC.Size = new System.Drawing.Size(31, 20);
			lblCC.TabIndex = 8;
			lblCC.Text = "CC";
			// 
			// tabPage3
			// 
			tabPage3.Location = new System.Drawing.Point(4, 24);
			tabPage3.Margin = new System.Windows.Forms.Padding(2);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new System.Windows.Forms.Padding(2);
			tabPage3.Size = new System.Drawing.Size(1018, 605);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Tools";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// frmMassMail
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new System.Drawing.Size(1026, 767);
			Controls.Add(tabControl1);
			Controls.Add(panel1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "frmMassMail";
			Text = "Mass mailing";
			panel1.ResumeLayout(false);
			tabControl2.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			tabPage4.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tabControl1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			splitContainer3.Panel1.ResumeLayout(false);
			splitContainer3.Panel1.PerformLayout();
			splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
			splitContainer3.ResumeLayout(false);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)StudImage).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			ResumeLayout(false);
		}



		#endregion

		private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.TextBox txtExcelFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button cmdSend;
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
        private System.Windows.Forms.Label lblCC;
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
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbIdField;
		private System.Windows.Forms.PictureBox StudImage;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
	}
}

