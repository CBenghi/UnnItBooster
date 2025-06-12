using System;
using System.Windows.Forms;

namespace StudentsFetcher.StudentMarking
{
    partial class FrmMarkingMachine
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarkingMachine));
			txtStudentId = new TextBox();
			txtSearch = new TextBox();
			cmdAdd = new Button();
			txtLibReport = new TextBox();
			splitContainer1 = new SplitContainer();
			splitContainer4 = new SplitContainer();
			txtStudentreport = new ExtendedTextBox.ExtTextBox();
			flComponents = new FlowLayoutPanel();
			LblMark = new Label();
			cmdSaveMarks = new Button();
			panel2 = new Panel();
			chkUseSorting = new CheckBox();
			LblOverlap = new Label();
			button12 = new Button();
			button6 = new Button();
			button5 = new Button();
			label6 = new Label();
			splitContainer2 = new SplitContainer();
			panel1 = new Panel();
			label8 = new Label();
			groupBox2 = new GroupBox();
			chkJustComponents = new CheckBox();
			cmdSetFromDelegatedMarks = new Button();
			groupBox4 = new GroupBox();
			button13 = new Button();
			cmbDocuments = new ComboBox();
			button2 = new Button();
			ChkCommNumber = new CheckBox();
			cmdReportSizeDecrease = new Button();
			cmdReportSizeIncrease = new Button();
			cmdWrap = new Button();
			ChkAutoStat = new CheckBox();
			BtnShowStudentStat = new Button();
			tableLayoutPanel1 = new TableLayoutPanel();
			label4 = new Label();
			label2 = new Label();
			txtTextOrPointer = new ExtendedTextBox.ExtTextBox();
			txtAdditionalNote = new ExtendedTextBox.ExtTextBox();
			label1 = new Label();
			txtArea = new TextBox();
			label11 = new Label();
			cmbComponentComment = new ComboBox();
			txtSection = new ComboBox();
			label3 = new Label();
			button11 = new Button();
			BtnEditLast = new Button();
			label7 = new Label();
			cmdSelectFile = new Button();
			txtExcelFileName = new TextBox();
			cmdReload = new Button();
			label5 = new Label();
			openFileDialog1 = new OpenFileDialog();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			tabPage2 = new TabPage();
			splitContainer3 = new SplitContainer();
			splitContainer5 = new SplitContainer();
			lstEmailSendSelection = new ListView();
			colName = new ColumnHeader();
			colNumMarks = new ColumnHeader();
			colMark = new ColumnHeader();
			colLastUpdate = new ColumnHeader();
			colNumComments = new ColumnHeader();
			colSimilarity = new ColumnHeader();
			tableLayoutPanel2 = new TableLayoutPanel();
			cmdEmailRefreshStudents = new Button();
			cmdSelectAll = new Button();
			NudOverlap = new NumericUpDown();
			chkShowDelegate = new CheckBox();
			StudImage = new PictureBox();
			tableLayoutPanel3 = new TableLayoutPanel();
			tabControl2 = new TabControl();
			tabPage4 = new TabPage();
			cmdListVariables = new Button();
			button1 = new Button();
			cmdSaveEmail = new Button();
			txtEmailBody = new ExtendedTextBox.ExtTextBox();
			tabPage5 = new TabPage();
			txtEmailPreview = new TextBox();
			btnSend = new Button();
			chkSendModerationNotice = new CheckBox();
			cmbEmailSubject = new ComboBox();
			label10 = new Label();
			chkEmailDryRun = new CheckBox();
			tabPage3 = new TabPage();
			groupBox1 = new GroupBox();
			ChkExclude0 = new CheckBox();
			NudMarkOffset = new NumericUpDown();
			label9 = new Label();
			ChkRoundupX9 = new CheckBox();
			ChkShowLabels = new CheckBox();
			CmbGrouping = new ComboBox();
			ChkIncludeNoMark = new CheckBox();
			ChkOddRows = new CheckBox();
			ChkEvenRows = new CheckBox();
			button4 = new Button();
			zedGraphControl1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
			groupBox3 = new GroupBox();
			txtElpCode = new TextBox();
			txtToolReport = new TextBox();
			tabControl3 = new TabControl();
			tabPage6 = new TabPage();
			txtSourceTurnitin = new TextBox();
			button8 = new Button();
			btnCompleteData = new Button();
			button7 = new Button();
			tabPage11 = new TabPage();
			label15 = new Label();
			txtImprotFromRepoFilter = new TextBox();
			label14 = new Label();
			button14 = new Button();
			cmbImportCollection = new ComboBox();
			tabPage7 = new TabPage();
			txtSourceDataFile = new TextBox();
			chkImportSubmissions = new CheckBox();
			lblSourceData = new Label();
			chkImportComponents = new CheckBox();
			cmdSourceDataFile = new Button();
			cmdGetData = new Button();
			chkCommentLib = new CheckBox();
			tabPage8 = new TabPage();
			button10 = new Button();
			button9 = new Button();
			tabPage9 = new TabPage();
			TxtExcelComponentSource = new TextBox();
			BtnImportExcel = new Button();
			BtnExportExcel = new Button();
			tabPage10 = new TabPage();
			label12 = new Label();
			TxtScaleFactor = new TextBox();
			TxtMergeReportFolder = new TextBox();
			BtnMergeReport = new Button();
			label13 = new Label();
			tableLayoutPanel4 = new TableLayoutPanel();
			BtnOpenFolder = new Button();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
			splitContainer4.Panel1.SuspendLayout();
			splitContainer4.Panel2.SuspendLayout();
			splitContainer4.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			panel1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox4.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
			splitContainer3.Panel1.SuspendLayout();
			splitContainer3.Panel2.SuspendLayout();
			splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
			splitContainer5.Panel1.SuspendLayout();
			splitContainer5.Panel2.SuspendLayout();
			splitContainer5.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NudOverlap).BeginInit();
			((System.ComponentModel.ISupportInitialize)StudImage).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			tabControl2.SuspendLayout();
			tabPage4.SuspendLayout();
			tabPage5.SuspendLayout();
			tabPage3.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NudMarkOffset).BeginInit();
			groupBox3.SuspendLayout();
			tabControl3.SuspendLayout();
			tabPage6.SuspendLayout();
			tabPage11.SuspendLayout();
			tabPage7.SuspendLayout();
			tabPage8.SuspendLayout();
			tabPage9.SuspendLayout();
			tabPage10.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			SuspendLayout();
			// 
			// txtStudentId
			// 
			txtStudentId.Dock = DockStyle.Top;
			txtStudentId.Location = new System.Drawing.Point(0, 15);
			txtStudentId.Margin = new Padding(4, 3, 4, 3);
			txtStudentId.Name = "txtStudentId";
			txtStudentId.Size = new System.Drawing.Size(408, 23);
			txtStudentId.TabIndex = 0;
			txtStudentId.TabStop = false;
			txtStudentId.KeyDown += txtStudentId_KeyDown;
			// 
			// txtSearch
			// 
			txtSearch.Dock = DockStyle.Fill;
			txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSearch.Location = new System.Drawing.Point(0, 15);
			txtSearch.Margin = new Padding(4, 3, 4, 3);
			txtSearch.Name = "txtSearch";
			txtSearch.Size = new System.Drawing.Size(536, 29);
			txtSearch.TabIndex = 3;
			txtSearch.KeyDown += txtSearch_KeyDown;
			// 
			// cmdAdd
			// 
			cmdAdd.Location = new System.Drawing.Point(152, 593);
			cmdAdd.Margin = new Padding(4, 3, 4, 3);
			cmdAdd.Name = "cmdAdd";
			cmdAdd.Size = new System.Drawing.Size(88, 27);
			cmdAdd.TabIndex = 13;
			cmdAdd.TabStop = false;
			cmdAdd.Text = "Add";
			cmdAdd.UseVisualStyleBackColor = true;
			cmdAdd.Click += cmdAdd_Click;
			// 
			// txtLibReport
			// 
			txtLibReport.BackColor = System.Drawing.Color.LightYellow;
			txtLibReport.Dock = DockStyle.Fill;
			txtLibReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLibReport.Location = new System.Drawing.Point(0, 46);
			txtLibReport.Margin = new Padding(4, 3, 4, 3);
			txtLibReport.Multiline = true;
			txtLibReport.Name = "txtLibReport";
			txtLibReport.ScrollBars = ScrollBars.Both;
			txtLibReport.Size = new System.Drawing.Size(536, 455);
			txtLibReport.TabIndex = 2;
			txtLibReport.TabStop = false;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.Location = new System.Drawing.Point(4, 3);
			splitContainer1.Margin = new Padding(4, 3, 4, 3);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(splitContainer4);
			splitContainer1.Panel1.Controls.Add(panel2);
			splitContainer1.Panel1.Controls.Add(txtStudentId);
			splitContainer1.Panel1.Controls.Add(label6);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new System.Drawing.Size(1615, 639);
			splitContainer1.SplitterDistance = 408;
			splitContainer1.SplitterWidth = 5;
			splitContainer1.TabIndex = 8;
			splitContainer1.TabStop = false;
			// 
			// splitContainer4
			// 
			splitContainer4.Dock = DockStyle.Fill;
			splitContainer4.Location = new System.Drawing.Point(0, 122);
			splitContainer4.Margin = new Padding(2);
			splitContainer4.Name = "splitContainer4";
			splitContainer4.Orientation = Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			splitContainer4.Panel1.Controls.Add(txtStudentreport);
			// 
			// splitContainer4.Panel2
			// 
			splitContainer4.Panel2.Controls.Add(flComponents);
			splitContainer4.Panel2.Controls.Add(LblMark);
			splitContainer4.Panel2.Controls.Add(cmdSaveMarks);
			splitContainer4.Size = new System.Drawing.Size(408, 517);
			splitContainer4.SplitterDistance = 225;
			splitContainer4.SplitterWidth = 3;
			splitContainer4.TabIndex = 15;
			// 
			// txtStudentreport
			// 
			txtStudentreport.AcceptsReturn = true;
			txtStudentreport.AcceptsTab = true;
			txtStudentreport.ChangedColour = System.Drawing.Color.Empty;
			txtStudentreport.Dock = DockStyle.Fill;
			txtStudentreport.Location = new System.Drawing.Point(0, 0);
			txtStudentreport.Margin = new Padding(5);
			txtStudentreport.MaxLength = 0;
			txtStudentreport.Name = "txtStudentreport";
			txtStudentreport.OriginalText = "";
			txtStudentreport.Size = new System.Drawing.Size(408, 225);
			txtStudentreport.SpellCheck = true;
			txtStudentreport.TabIndex = 3;
			txtStudentreport.TabStop = false;
			txtStudentreport.TextCase = CharacterCasing.Normal;
			txtStudentreport.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			txtStudentreport.Wrapping = true;
			// 
			// flComponents
			// 
			flComponents.AutoScroll = true;
			flComponents.Dock = DockStyle.Fill;
			flComponents.Location = new System.Drawing.Point(0, 54);
			flComponents.Margin = new Padding(2);
			flComponents.Name = "flComponents";
			flComponents.Size = new System.Drawing.Size(408, 210);
			flComponents.TabIndex = 13;
			// 
			// LblMark
			// 
			LblMark.Dock = DockStyle.Top;
			LblMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			LblMark.Location = new System.Drawing.Point(0, 0);
			LblMark.Margin = new Padding(2, 0, 2, 0);
			LblMark.Name = "LblMark";
			LblMark.Size = new System.Drawing.Size(408, 54);
			LblMark.TabIndex = 0;
			LblMark.Text = "-";
			LblMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			LblMark.Click += LblMark_Click;
			// 
			// cmdSaveMarks
			// 
			cmdSaveMarks.Dock = DockStyle.Bottom;
			cmdSaveMarks.Location = new System.Drawing.Point(0, 264);
			cmdSaveMarks.Margin = new Padding(4, 3, 4, 3);
			cmdSaveMarks.Name = "cmdSaveMarks";
			cmdSaveMarks.Size = new System.Drawing.Size(408, 25);
			cmdSaveMarks.TabIndex = 6;
			cmdSaveMarks.Text = "Ok";
			cmdSaveMarks.UseVisualStyleBackColor = true;
			cmdSaveMarks.Click += CmdSaveMarks_Click;
			// 
			// panel2
			// 
			panel2.Controls.Add(chkJustComponents);
			panel2.Controls.Add(chkUseSorting);
			panel2.Controls.Add(ChkCommNumber);
			panel2.Controls.Add(LblOverlap);
			panel2.Controls.Add(button12);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(button5);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new System.Drawing.Point(0, 38);
			panel2.Margin = new Padding(2);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(408, 84);
			panel2.TabIndex = 17;
			// 
			// chkUseSorting
			// 
			chkUseSorting.AutoSize = true;
			chkUseSorting.Location = new System.Drawing.Point(5, 29);
			chkUseSorting.Margin = new Padding(4, 3, 4, 3);
			chkUseSorting.Name = "chkUseSorting";
			chkUseSorting.Size = new System.Drawing.Size(85, 19);
			chkUseSorting.TabIndex = 4;
			chkUseSorting.Text = "Use sorting";
			chkUseSorting.UseVisualStyleBackColor = true;
			chkUseSorting.CheckedChanged += chkUseSorting_CheckedChanged;
			// 
			// LblOverlap
			// 
			LblOverlap.AutoSize = true;
			LblOverlap.Location = new System.Drawing.Point(76, 6);
			LblOverlap.Margin = new Padding(4, 0, 4, 0);
			LblOverlap.Name = "LblOverlap";
			LblOverlap.Size = new System.Drawing.Size(12, 15);
			LblOverlap.TabIndex = 3;
			LblOverlap.Text = "-";
			// 
			// button12
			// 
			button12.Location = new System.Drawing.Point(5, 2);
			button12.Margin = new Padding(2);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(65, 22);
			button12.TabIndex = 2;
			button12.Text = "html";
			button12.UseVisualStyleBackColor = true;
			button12.Click += button12_Click;
			// 
			// button6
			// 
			button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button6.Location = new System.Drawing.Point(268, 2);
			button6.Margin = new Padding(2);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(65, 22);
			button6.TabIndex = 0;
			button6.Text = "-";
			button6.UseVisualStyleBackColor = true;
			button6.Click += button6_Click;
			// 
			// button5
			// 
			button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button5.Location = new System.Drawing.Point(338, 2);
			button5.Margin = new Padding(2);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(65, 22);
			button5.TabIndex = 1;
			button5.Text = "+";
			button5.UseVisualStyleBackColor = true;
			button5.Click += Next_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Dock = DockStyle.Top;
			label6.Location = new System.Drawing.Point(0, 0);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(51, 15);
			label6.TabIndex = 12;
			label6.Text = "Student:";
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.FixedPanel = FixedPanel.Panel2;
			splitContainer2.Location = new System.Drawing.Point(0, 0);
			splitContainer2.Margin = new Padding(4, 3, 4, 3);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(txtLibReport);
			splitContainer2.Panel1.Controls.Add(panel1);
			splitContainer2.Panel1.Controls.Add(groupBox2);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(tableLayoutPanel1);
			splitContainer2.Panel2.Controls.Add(label7);
			splitContainer2.Size = new System.Drawing.Size(1202, 639);
			splitContainer2.SplitterDistance = 536;
			splitContainer2.SplitterWidth = 5;
			splitContainer2.TabIndex = 0;
			splitContainer2.TabStop = false;
			// 
			// panel1
			// 
			panel1.Controls.Add(txtSearch);
			panel1.Controls.Add(label8);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Margin = new Padding(4, 3, 4, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(536, 46);
			panel1.TabIndex = 16;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Dock = DockStyle.Top;
			label8.Location = new System.Drawing.Point(0, 0);
			label8.Margin = new Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(45, 15);
			label8.TabIndex = 14;
			label8.Text = "Search:";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(cmdSetFromDelegatedMarks);
			groupBox2.Controls.Add(groupBox4);
			groupBox2.Controls.Add(cmdReportSizeDecrease);
			groupBox2.Controls.Add(cmdReportSizeIncrease);
			groupBox2.Controls.Add(cmdWrap);
			groupBox2.Controls.Add(ChkAutoStat);
			groupBox2.Controls.Add(BtnShowStudentStat);
			groupBox2.Dock = DockStyle.Bottom;
			groupBox2.Location = new System.Drawing.Point(0, 501);
			groupBox2.Margin = new Padding(4, 3, 4, 3);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(4, 3, 4, 3);
			groupBox2.Size = new System.Drawing.Size(536, 138);
			groupBox2.TabIndex = 15;
			groupBox2.TabStop = false;
			groupBox2.Text = "Documents downloaded";
			// 
			// chkJustComponents
			// 
			chkJustComponents.AutoSize = true;
			chkJustComponents.Location = new System.Drawing.Point(5, 46);
			chkJustComponents.Margin = new Padding(2);
			chkJustComponents.Name = "chkJustComponents";
			chkJustComponents.Size = new System.Drawing.Size(146, 19);
			chkJustComponents.TabIndex = 26;
			chkJustComponents.Text = "Just component marks";
			chkJustComponents.UseVisualStyleBackColor = true;
			// 
			// cmdSetFromDelegatedMarks
			// 
			cmdSetFromDelegatedMarks.Location = new System.Drawing.Point(139, 39);
			cmdSetFromDelegatedMarks.Margin = new Padding(4, 3, 4, 3);
			cmdSetFromDelegatedMarks.Name = "cmdSetFromDelegatedMarks";
			cmdSetFromDelegatedMarks.Size = new System.Drawing.Size(209, 27);
			cmdSetFromDelegatedMarks.TabIndex = 25;
			cmdSetFromDelegatedMarks.Text = "Set components from delegates";
			cmdSetFromDelegatedMarks.UseVisualStyleBackColor = true;
			cmdSetFromDelegatedMarks.Click += cmdSetFromDelegatedMarks_Click;
			// 
			// groupBox4
			// 
			groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox4.Controls.Add(button13);
			groupBox4.Controls.Add(cmbDocuments);
			groupBox4.Controls.Add(button2);
			groupBox4.Location = new System.Drawing.Point(8, 77);
			groupBox4.Margin = new Padding(4, 3, 4, 3);
			groupBox4.Name = "groupBox4";
			groupBox4.Padding = new Padding(4, 3, 4, 3);
			groupBox4.Size = new System.Drawing.Size(521, 54);
			groupBox4.TabIndex = 5;
			groupBox4.TabStop = false;
			groupBox4.Text = "Documents downloaded";
			// 
			// button13
			// 
			button13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button13.Location = new System.Drawing.Point(400, 22);
			button13.Margin = new Padding(4, 3, 4, 3);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(63, 27);
			button13.TabIndex = 3;
			button13.Text = "Content";
			button13.UseVisualStyleBackColor = true;
			button13.Click += button13_Click;
			// 
			// cmbDocuments
			// 
			cmbDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbDocuments.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbDocuments.FormattingEnabled = true;
			cmbDocuments.Location = new System.Drawing.Point(7, 22);
			cmbDocuments.Margin = new Padding(4, 3, 4, 3);
			cmbDocuments.Name = "cmbDocuments";
			cmbDocuments.Size = new System.Drawing.Size(386, 23);
			cmbDocuments.TabIndex = 0;
			cmbDocuments.TabStop = false;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button2.Location = new System.Drawing.Point(462, 22);
			button2.Margin = new Padding(4, 3, 4, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(51, 27);
			button2.TabIndex = 2;
			button2.Text = "Open";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Open_Click;
			// 
			// ChkCommNumber
			// 
			ChkCommNumber.AutoSize = true;
			ChkCommNumber.Location = new System.Drawing.Point(5, 63);
			ChkCommNumber.Margin = new Padding(2);
			ChkCommNumber.Name = "ChkCommNumber";
			ChkCommNumber.Size = new System.Drawing.Size(135, 19);
			ChkCommNumber.TabIndex = 4;
			ChkCommNumber.Text = "Add Comm Number";
			ChkCommNumber.UseVisualStyleBackColor = true;
			// 
			// cmdReportSizeDecrease
			// 
			cmdReportSizeDecrease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdReportSizeDecrease.Location = new System.Drawing.Point(428, 14);
			cmdReportSizeDecrease.Margin = new Padding(4, 3, 4, 3);
			cmdReportSizeDecrease.Name = "cmdReportSizeDecrease";
			cmdReportSizeDecrease.Size = new System.Drawing.Size(28, 24);
			cmdReportSizeDecrease.TabIndex = 17;
			cmdReportSizeDecrease.Text = "-";
			cmdReportSizeDecrease.UseVisualStyleBackColor = true;
			cmdReportSizeDecrease.Click += cmdReportSizeDecrease_Click;
			// 
			// cmdReportSizeIncrease
			// 
			cmdReportSizeIncrease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdReportSizeIncrease.Location = new System.Drawing.Point(456, 14);
			cmdReportSizeIncrease.Margin = new Padding(4, 3, 4, 3);
			cmdReportSizeIncrease.Name = "cmdReportSizeIncrease";
			cmdReportSizeIncrease.Size = new System.Drawing.Size(28, 24);
			cmdReportSizeIncrease.TabIndex = 16;
			cmdReportSizeIncrease.Text = "+";
			cmdReportSizeIncrease.UseVisualStyleBackColor = true;
			cmdReportSizeIncrease.Click += cmdReportSizeIncrease_Click;
			// 
			// cmdWrap
			// 
			cmdWrap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdWrap.Location = new System.Drawing.Point(483, 14);
			cmdWrap.Margin = new Padding(4, 3, 4, 3);
			cmdWrap.Name = "cmdWrap";
			cmdWrap.Size = new System.Drawing.Size(47, 24);
			cmdWrap.TabIndex = 15;
			cmdWrap.Text = "wrap";
			cmdWrap.UseVisualStyleBackColor = true;
			cmdWrap.Click += cmdWrap_Click;
			// 
			// ChkAutoStat
			// 
			ChkAutoStat.AutoSize = true;
			ChkAutoStat.Location = new System.Drawing.Point(8, 18);
			ChkAutoStat.Margin = new Padding(2);
			ChkAutoStat.Name = "ChkAutoStat";
			ChkAutoStat.Size = new System.Drawing.Size(74, 19);
			ChkAutoStat.TabIndex = 3;
			ChkAutoStat.Text = "Auto stat";
			ChkAutoStat.UseVisualStyleBackColor = true;
			// 
			// BtnShowStudentStat
			// 
			BtnShowStudentStat.Location = new System.Drawing.Point(6, 39);
			BtnShowStudentStat.Margin = new Padding(4, 3, 4, 3);
			BtnShowStudentStat.Name = "BtnShowStudentStat";
			BtnShowStudentStat.Size = new System.Drawing.Size(126, 27);
			BtnShowStudentStat.TabIndex = 24;
			BtnShowStudentStat.Text = "Show student stats";
			BtnShowStudentStat.UseVisualStyleBackColor = true;
			BtnShowStudentStat.Click += BtnShowStudentStat_Click;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.45509F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.54491F));
			tableLayoutPanel1.Controls.Add(label4, 0, 4);
			tableLayoutPanel1.Controls.Add(label2, 0, 3);
			tableLayoutPanel1.Controls.Add(txtTextOrPointer, 1, 2);
			tableLayoutPanel1.Controls.Add(txtAdditionalNote, 1, 3);
			tableLayoutPanel1.Controls.Add(label1, 0, 2);
			tableLayoutPanel1.Controls.Add(txtArea, 1, 4);
			tableLayoutPanel1.Controls.Add(label11, 0, 5);
			tableLayoutPanel1.Controls.Add(cmdAdd, 1, 6);
			tableLayoutPanel1.Controls.Add(cmbComponentComment, 1, 5);
			tableLayoutPanel1.Controls.Add(txtSection, 1, 0);
			tableLayoutPanel1.Controls.Add(label3, 0, 0);
			tableLayoutPanel1.Controls.Add(button11, 1, 1);
			tableLayoutPanel1.Controls.Add(BtnEditLast, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 15);
			tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 7;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(661, 624);
			tableLayoutPanel1.TabIndex = 8;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(4, 539);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(31, 15);
			label4.TabIndex = 19;
			label4.Text = "Area";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(7, 302);
			label2.Margin = new Padding(7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(102, 15);
			label2.TabIndex = 17;
			label2.Text = "specific comment";
			label2.Click += label2_Click;
			// 
			// txtTextOrPointer
			// 
			txtTextOrPointer.AcceptsReturn = true;
			txtTextOrPointer.AcceptsTab = false;
			txtTextOrPointer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtTextOrPointer.ChangedColour = System.Drawing.Color.Empty;
			txtTextOrPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTextOrPointer.Location = new System.Drawing.Point(154, 64);
			txtTextOrPointer.Margin = new Padding(6);
			txtTextOrPointer.MaxLength = 0;
			txtTextOrPointer.Name = "txtTextOrPointer";
			txtTextOrPointer.OriginalText = "";
			txtTextOrPointer.Size = new System.Drawing.Size(501, 225);
			txtTextOrPointer.SpellCheck = true;
			txtTextOrPointer.TabIndex = 4;
			txtTextOrPointer.TextCase = CharacterCasing.Normal;
			txtTextOrPointer.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			txtTextOrPointer.Wrapping = true;
			txtTextOrPointer.OnCtrlEnter += DoAdd;
			txtTextOrPointer.OnCtrlTab += txtTextOrPointer_OnCtrlTab;
			txtTextOrPointer.OnCtrlKey += txtTextOrPointer_OnCtrlKey;
			txtTextOrPointer.KeyDown += txtTextOrPointer_KeyUp;
			// 
			// txtAdditionalNote
			// 
			txtAdditionalNote.AcceptsReturn = true;
			txtAdditionalNote.AcceptsTab = true;
			txtAdditionalNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtAdditionalNote.ChangedColour = System.Drawing.Color.Empty;
			txtAdditionalNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAdditionalNote.Location = new System.Drawing.Point(154, 301);
			txtAdditionalNote.Margin = new Padding(6);
			txtAdditionalNote.MaxLength = 0;
			txtAdditionalNote.Name = "txtAdditionalNote";
			txtAdditionalNote.OriginalText = "";
			txtAdditionalNote.Size = new System.Drawing.Size(501, 225);
			txtAdditionalNote.SpellCheck = true;
			txtAdditionalNote.TabIndex = 5;
			txtAdditionalNote.TextCase = CharacterCasing.Normal;
			txtAdditionalNote.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			txtAdditionalNote.Wrapping = true;
			txtAdditionalNote.OnCtrlEnter += DoAdd;
			txtAdditionalNote.KeyDown += txtTextOrPointer_KeyUp;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(7, 65);
			label1.Margin = new Padding(7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(47, 15);
			label1.TabIndex = 10;
			label1.Text = "ptr/text";
			label1.Click += label1_Click;
			// 
			// txtArea
			// 
			txtArea.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtArea.Location = new System.Drawing.Point(152, 535);
			txtArea.Margin = new Padding(4, 3, 4, 3);
			txtArea.Name = "txtArea";
			txtArea.Size = new System.Drawing.Size(505, 23);
			txtArea.TabIndex = 12;
			txtArea.TabStop = false;
			// 
			// label11
			// 
			label11.Anchor = AnchorStyles.Left;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(4, 568);
			label11.Margin = new Padding(4, 0, 4, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(71, 15);
			label11.TabIndex = 20;
			label11.Text = "Component";
			// 
			// cmbComponentComment
			// 
			cmbComponentComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbComponentComment.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbComponentComment.FormattingEnabled = true;
			cmbComponentComment.Location = new System.Drawing.Point(152, 564);
			cmbComponentComment.Margin = new Padding(4, 3, 4, 3);
			cmbComponentComment.Name = "cmbComponentComment";
			cmbComponentComment.Size = new System.Drawing.Size(505, 23);
			cmbComponentComment.TabIndex = 21;
			cmbComponentComment.TabStop = false;
			// 
			// txtSection
			// 
			txtSection.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtSection.Location = new System.Drawing.Point(152, 3);
			txtSection.Margin = new Padding(4, 3, 4, 3);
			txtSection.Name = "txtSection";
			txtSection.Size = new System.Drawing.Size(505, 23);
			txtSection.TabIndex = 11;
			txtSection.TabStop = false;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(4, 7);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(46, 15);
			label3.TabIndex = 18;
			label3.Text = "Section";
			// 
			// button11
			// 
			button11.Dock = DockStyle.Fill;
			button11.Location = new System.Drawing.Point(152, 32);
			button11.Margin = new Padding(4, 3, 4, 3);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(505, 23);
			button11.TabIndex = 22;
			button11.Text = "Section rotation";
			button11.UseVisualStyleBackColor = true;
			button11.Click += button11_Click;
			// 
			// BtnEditLast
			// 
			BtnEditLast.Location = new System.Drawing.Point(4, 32);
			BtnEditLast.Margin = new Padding(4, 3, 4, 3);
			BtnEditLast.Name = "BtnEditLast";
			BtnEditLast.Size = new System.Drawing.Size(80, 22);
			BtnEditLast.TabIndex = 23;
			BtnEditLast.Text = "Edit last";
			BtnEditLast.UseVisualStyleBackColor = true;
			BtnEditLast.Click += BtnEditLast_Click;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Dock = DockStyle.Top;
			label7.Location = new System.Drawing.Point(0, 0);
			label7.Margin = new Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(61, 15);
			label7.TabIndex = 13;
			label7.Text = "Comment";
			// 
			// cmdSelectFile
			// 
			cmdSelectFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			cmdSelectFile.Location = new System.Drawing.Point(1530, 6);
			cmdSelectFile.Margin = new Padding(4, 3, 4, 3);
			cmdSelectFile.Name = "cmdSelectFile";
			cmdSelectFile.Size = new System.Drawing.Size(27, 25);
			cmdSelectFile.TabIndex = 10;
			cmdSelectFile.TabStop = false;
			cmdSelectFile.Text = "...";
			cmdSelectFile.UseVisualStyleBackColor = true;
			cmdSelectFile.Click += cmdSelectFile_Click;
			// 
			// txtExcelFileName
			// 
			txtExcelFileName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtExcelFileName.Location = new System.Drawing.Point(74, 6);
			txtExcelFileName.Margin = new Padding(4, 3, 4, 3);
			txtExcelFileName.Multiline = true;
			txtExcelFileName.Name = "txtExcelFileName";
			txtExcelFileName.Size = new System.Drawing.Size(1448, 25);
			txtExcelFileName.TabIndex = 9;
			txtExcelFileName.TabStop = false;
			txtExcelFileName.TextChanged += txtExcelFileName_TextChanged;
			// 
			// cmdReload
			// 
			cmdReload.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			cmdReload.Location = new System.Drawing.Point(1565, 6);
			cmdReload.Margin = new Padding(4, 3, 4, 3);
			cmdReload.Name = "cmdReload";
			cmdReload.Size = new System.Drawing.Size(27, 25);
			cmdReload.TabIndex = 12;
			cmdReload.TabStop = false;
			cmdReload.Text = "R";
			cmdReload.UseVisualStyleBackColor = true;
			cmdReload.Click += cmdReload_Click;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(4, 11);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 15);
			label5.TabIndex = 11;
			label5.Text = "SQLite ";
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 37);
			tabControl1.Margin = new Padding(4, 3, 4, 3);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(1631, 673);
			tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(splitContainer1);
			tabPage1.Location = new System.Drawing.Point(4, 24);
			tabPage1.Margin = new Padding(4, 3, 4, 3);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(4, 3, 4, 3);
			tabPage1.Size = new System.Drawing.Size(1623, 645);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Marking";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(splitContainer3);
			tabPage2.Location = new System.Drawing.Point(4, 24);
			tabPage2.Margin = new Padding(4, 3, 4, 3);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(4, 3, 4, 3);
			tabPage2.Size = new System.Drawing.Size(1623, 645);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Emailing";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			splitContainer3.Dock = DockStyle.Fill;
			splitContainer3.Location = new System.Drawing.Point(4, 3);
			splitContainer3.Margin = new Padding(4, 3, 4, 3);
			splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			splitContainer3.Panel1.Controls.Add(splitContainer5);
			// 
			// splitContainer3.Panel2
			// 
			splitContainer3.Panel2.Controls.Add(tableLayoutPanel3);
			splitContainer3.Size = new System.Drawing.Size(1615, 639);
			splitContainer3.SplitterDistance = 635;
			splitContainer3.SplitterWidth = 5;
			splitContainer3.TabIndex = 3;
			// 
			// splitContainer5
			// 
			splitContainer5.Dock = DockStyle.Fill;
			splitContainer5.FixedPanel = FixedPanel.Panel2;
			splitContainer5.Location = new System.Drawing.Point(0, 0);
			splitContainer5.Margin = new Padding(2);
			splitContainer5.Name = "splitContainer5";
			splitContainer5.Orientation = Orientation.Horizontal;
			// 
			// splitContainer5.Panel1
			// 
			splitContainer5.Panel1.Controls.Add(lstEmailSendSelection);
			splitContainer5.Panel1.Controls.Add(tableLayoutPanel2);
			// 
			// splitContainer5.Panel2
			// 
			splitContainer5.Panel2.Controls.Add(StudImage);
			splitContainer5.Size = new System.Drawing.Size(635, 639);
			splitContainer5.SplitterDistance = 430;
			splitContainer5.SplitterWidth = 3;
			splitContainer5.TabIndex = 14;
			// 
			// lstEmailSendSelection
			// 
			lstEmailSendSelection.CheckBoxes = true;
			lstEmailSendSelection.Columns.AddRange(new ColumnHeader[] { colName, colNumMarks, colMark, colLastUpdate, colNumComments, colSimilarity });
			lstEmailSendSelection.Dock = DockStyle.Fill;
			lstEmailSendSelection.FullRowSelect = true;
			lstEmailSendSelection.GridLines = true;
			lstEmailSendSelection.Location = new System.Drawing.Point(0, 35);
			lstEmailSendSelection.Margin = new Padding(4, 3, 4, 3);
			lstEmailSendSelection.Name = "lstEmailSendSelection";
			lstEmailSendSelection.Size = new System.Drawing.Size(635, 395);
			lstEmailSendSelection.TabIndex = 3;
			lstEmailSendSelection.UseCompatibleStateImageBehavior = false;
			lstEmailSendSelection.View = View.Details;
			lstEmailSendSelection.SelectedIndexChanged += lstEmailSendSelection_SelectedIndexChanged;
			// 
			// colName
			// 
			colName.Text = "Name";
			colName.Width = 146;
			// 
			// colNumMarks
			// 
			colNumMarks.Text = "# Marks";
			colNumMarks.TextAlign = HorizontalAlignment.Right;
			// 
			// colMark
			// 
			colMark.Text = "Mark";
			colMark.TextAlign = HorizontalAlignment.Right;
			// 
			// colLastUpdate
			// 
			colLastUpdate.Text = "Last update";
			colLastUpdate.TextAlign = HorizontalAlignment.Center;
			// 
			// colNumComments
			// 
			colNumComments.Text = "NumComments";
			colNumComments.TextAlign = HorizontalAlignment.Right;
			// 
			// colSimilarity
			// 
			colSimilarity.Text = "Similarity";
			colSimilarity.Width = 300;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 4;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.99999F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.00001F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 144F));
			tableLayoutPanel2.Controls.Add(cmdEmailRefreshStudents, 0, 0);
			tableLayoutPanel2.Controls.Add(cmdSelectAll, 1, 0);
			tableLayoutPanel2.Controls.Add(NudOverlap, 2, 0);
			tableLayoutPanel2.Controls.Add(chkShowDelegate, 3, 0);
			tableLayoutPanel2.Dock = DockStyle.Top;
			tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel2.Margin = new Padding(2);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.Size = new System.Drawing.Size(635, 35);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// cmdEmailRefreshStudents
			// 
			cmdEmailRefreshStudents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmdEmailRefreshStudents.Location = new System.Drawing.Point(4, 3);
			cmdEmailRefreshStudents.Margin = new Padding(4, 3, 4, 3);
			cmdEmailRefreshStudents.Name = "cmdEmailRefreshStudents";
			cmdEmailRefreshStudents.Size = new System.Drawing.Size(178, 27);
			cmdEmailRefreshStudents.TabIndex = 2;
			cmdEmailRefreshStudents.Text = "Refresh";
			cmdEmailRefreshStudents.UseVisualStyleBackColor = true;
			cmdEmailRefreshStudents.Click += cmdEmailRefreshStudents_Click;
			// 
			// cmdSelectAll
			// 
			cmdSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmdSelectAll.Location = new System.Drawing.Point(190, 3);
			cmdSelectAll.Margin = new Padding(4, 3, 4, 3);
			cmdSelectAll.Name = "cmdSelectAll";
			cmdSelectAll.Size = new System.Drawing.Size(179, 27);
			cmdSelectAll.TabIndex = 4;
			cmdSelectAll.Text = "All";
			cmdSelectAll.UseVisualStyleBackColor = true;
			cmdSelectAll.Click += cmdSelectAll_Click;
			// 
			// NudOverlap
			// 
			NudOverlap.Anchor = AnchorStyles.None;
			NudOverlap.Location = new System.Drawing.Point(396, 6);
			NudOverlap.Margin = new Padding(4, 3, 4, 3);
			NudOverlap.Name = "NudOverlap";
			NudOverlap.Size = new System.Drawing.Size(70, 23);
			NudOverlap.TabIndex = 5;
			NudOverlap.TextAlign = HorizontalAlignment.Center;
			NudOverlap.Value = new decimal(new int[] { 25, 0, 0, 0 });
			// 
			// chkShowDelegate
			// 
			chkShowDelegate.Anchor = AnchorStyles.None;
			chkShowDelegate.AutoSize = true;
			chkShowDelegate.Location = new System.Drawing.Point(526, 8);
			chkShowDelegate.Margin = new Padding(4, 3, 4, 3);
			chkShowDelegate.Name = "chkShowDelegate";
			chkShowDelegate.Size = new System.Drawing.Size(72, 19);
			chkShowDelegate.TabIndex = 6;
			chkShowDelegate.Text = "Delegate";
			chkShowDelegate.UseVisualStyleBackColor = true;
			chkShowDelegate.CheckedChanged += chkShowDelegate_CheckedChanged;
			// 
			// StudImage
			// 
			StudImage.Dock = DockStyle.Fill;
			StudImage.Location = new System.Drawing.Point(0, 0);
			StudImage.Margin = new Padding(2);
			StudImage.Name = "StudImage";
			StudImage.Size = new System.Drawing.Size(635, 206);
			StudImage.SizeMode = PictureBoxSizeMode.Zoom;
			StudImage.TabIndex = 13;
			StudImage.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(tabControl2, 0, 3);
			tableLayoutPanel3.Controls.Add(btnSend, 1, 2);
			tableLayoutPanel3.Controls.Add(chkSendModerationNotice, 0, 2);
			tableLayoutPanel3.Controls.Add(cmbEmailSubject, 1, 0);
			tableLayoutPanel3.Controls.Add(label10, 0, 0);
			tableLayoutPanel3.Controls.Add(chkEmailDryRun, 0, 1);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel3.Margin = new Padding(2);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 4;
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new System.Drawing.Size(975, 639);
			tableLayoutPanel3.TabIndex = 8;
			// 
			// tabControl2
			// 
			tabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel3.SetColumnSpan(tabControl2, 2);
			tabControl2.Controls.Add(tabPage4);
			tabControl2.Controls.Add(tabPage5);
			tabControl2.Location = new System.Drawing.Point(2, 85);
			tabControl2.Margin = new Padding(2);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabControl2.Size = new System.Drawing.Size(971, 552);
			tabControl2.TabIndex = 7;
			// 
			// tabPage4
			// 
			tabPage4.Controls.Add(cmdListVariables);
			tabPage4.Controls.Add(button1);
			tabPage4.Controls.Add(cmdSaveEmail);
			tabPage4.Controls.Add(txtEmailBody);
			tabPage4.Location = new System.Drawing.Point(4, 24);
			tabPage4.Margin = new Padding(2);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new Padding(2);
			tabPage4.Size = new System.Drawing.Size(963, 524);
			tabPage4.TabIndex = 0;
			tabPage4.Text = "Template";
			tabPage4.UseVisualStyleBackColor = true;
			// 
			// cmdListVariables
			// 
			cmdListVariables.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			cmdListVariables.Location = new System.Drawing.Point(321, 471);
			cmdListVariables.Margin = new Padding(4, 3, 4, 3);
			cmdListVariables.Name = "cmdListVariables";
			cmdListVariables.Size = new System.Drawing.Size(150, 27);
			cmdListVariables.TabIndex = 10;
			cmdListVariables.Text = "List variables";
			cmdListVariables.UseVisualStyleBackColor = true;
			cmdListVariables.Click += cmdListVariables_Click;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button1.Location = new System.Drawing.Point(6, 471);
			button1.Margin = new Padding(4, 3, 4, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(150, 27);
			button1.TabIndex = 9;
			button1.Text = "Default";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// cmdSaveEmail
			// 
			cmdSaveEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			cmdSaveEmail.Location = new System.Drawing.Point(163, 471);
			cmdSaveEmail.Margin = new Padding(4, 3, 4, 3);
			cmdSaveEmail.Name = "cmdSaveEmail";
			cmdSaveEmail.Size = new System.Drawing.Size(150, 27);
			cmdSaveEmail.TabIndex = 8;
			cmdSaveEmail.Text = "Save Email";
			cmdSaveEmail.UseVisualStyleBackColor = true;
			cmdSaveEmail.Click += cmdSaveEmail_Click;
			// 
			// txtEmailBody
			// 
			txtEmailBody.AcceptsReturn = true;
			txtEmailBody.AcceptsTab = true;
			txtEmailBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtEmailBody.ChangedColour = System.Drawing.Color.Empty;
			txtEmailBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEmailBody.Location = new System.Drawing.Point(5, 8);
			txtEmailBody.Margin = new Padding(7);
			txtEmailBody.MaxLength = 0;
			txtEmailBody.Name = "txtEmailBody";
			txtEmailBody.OriginalText = "";
			txtEmailBody.Size = new System.Drawing.Size(949, 453);
			txtEmailBody.SpellCheck = true;
			txtEmailBody.TabIndex = 6;
			txtEmailBody.TabStop = false;
			txtEmailBody.TextCase = CharacterCasing.Normal;
			txtEmailBody.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			txtEmailBody.Wrapping = true;
			// 
			// tabPage5
			// 
			tabPage5.Controls.Add(txtEmailPreview);
			tabPage5.Location = new System.Drawing.Point(4, 24);
			tabPage5.Margin = new Padding(2);
			tabPage5.Name = "tabPage5";
			tabPage5.Padding = new Padding(2);
			tabPage5.Size = new System.Drawing.Size(963, 524);
			tabPage5.TabIndex = 1;
			tabPage5.Text = "Output";
			tabPage5.UseVisualStyleBackColor = true;
			// 
			// txtEmailPreview
			// 
			txtEmailPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtEmailPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEmailPreview.Location = new System.Drawing.Point(6, 7);
			txtEmailPreview.Margin = new Padding(4, 3, 4, 3);
			txtEmailPreview.Multiline = true;
			txtEmailPreview.Name = "txtEmailPreview";
			txtEmailPreview.ScrollBars = ScrollBars.Vertical;
			txtEmailPreview.Size = new System.Drawing.Size(951, 486);
			txtEmailPreview.TabIndex = 7;
			txtEmailPreview.TabStop = false;
			txtEmailPreview.Text = "Dear {SUB_FirstName}, \r\nThe marking and moderation process for BE1178 has been completed a few days ago. \r\nPlease find your feedback after my signature.\r\nBest regards, \r\nClaudio \r\n\r\n{MarkReport}";
			// 
			// btnSend
			// 
			btnSend.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			btnSend.Location = new System.Drawing.Point(163, 57);
			btnSend.Margin = new Padding(4, 3, 4, 3);
			btnSend.Name = "btnSend";
			btnSend.Size = new System.Drawing.Size(808, 23);
			btnSend.TabIndex = 0;
			btnSend.Text = "Send";
			btnSend.UseVisualStyleBackColor = true;
			btnSend.Click += send_Click;
			// 
			// chkSendModerationNotice
			// 
			chkSendModerationNotice.AutoSize = true;
			chkSendModerationNotice.Location = new System.Drawing.Point(4, 57);
			chkSendModerationNotice.Margin = new Padding(4, 3, 4, 3);
			chkSendModerationNotice.Name = "chkSendModerationNotice";
			chkSendModerationNotice.Size = new System.Drawing.Size(151, 19);
			chkSendModerationNotice.TabIndex = 5;
			chkSendModerationNotice.Text = "Add Moderation Notice";
			chkSendModerationNotice.UseVisualStyleBackColor = true;
			// 
			// cmbEmailSubject
			// 
			cmbEmailSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbEmailSubject.Location = new System.Drawing.Point(163, 3);
			cmbEmailSubject.Margin = new Padding(4, 3, 4, 3);
			cmbEmailSubject.Name = "cmbEmailSubject";
			cmbEmailSubject.Size = new System.Drawing.Size(808, 23);
			cmbEmailSubject.TabIndex = 3;
			cmbEmailSubject.SelectedValueChanged += txtEmailSubject_SelectedValueChanged;
			// 
			// label10
			// 
			label10.Anchor = AnchorStyles.Left;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(4, 7);
			label10.Margin = new Padding(4, 0, 4, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(46, 15);
			label10.TabIndex = 2;
			label10.Text = "Subject";
			// 
			// chkEmailDryRun
			// 
			chkEmailDryRun.AutoSize = true;
			chkEmailDryRun.Checked = true;
			chkEmailDryRun.CheckState = CheckState.Checked;
			chkEmailDryRun.Location = new System.Drawing.Point(4, 32);
			chkEmailDryRun.Margin = new Padding(4, 3, 4, 3);
			chkEmailDryRun.Name = "chkEmailDryRun";
			chkEmailDryRun.Size = new System.Drawing.Size(68, 19);
			chkEmailDryRun.TabIndex = 4;
			chkEmailDryRun.Text = "Dry Run";
			chkEmailDryRun.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			tabPage3.Controls.Add(groupBox1);
			tabPage3.Controls.Add(ChkShowLabels);
			tabPage3.Controls.Add(CmbGrouping);
			tabPage3.Controls.Add(ChkIncludeNoMark);
			tabPage3.Controls.Add(ChkOddRows);
			tabPage3.Controls.Add(ChkEvenRows);
			tabPage3.Controls.Add(button4);
			tabPage3.Controls.Add(zedGraphControl1);
			tabPage3.Controls.Add(groupBox3);
			tabPage3.Location = new System.Drawing.Point(4, 24);
			tabPage3.Margin = new Padding(2);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new Padding(2);
			tabPage3.Size = new System.Drawing.Size(1623, 645);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Tools";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(ChkExclude0);
			groupBox1.Controls.Add(NudMarkOffset);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(ChkRoundupX9);
			groupBox1.Location = new System.Drawing.Point(13, 450);
			groupBox1.Margin = new Padding(4, 3, 4, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 3, 4, 3);
			groupBox1.Size = new System.Drawing.Size(132, 108);
			groupBox1.TabIndex = 29;
			groupBox1.TabStop = false;
			groupBox1.Text = "Mark tweak";
			// 
			// ChkExclude0
			// 
			ChkExclude0.AutoSize = true;
			ChkExclude0.Checked = true;
			ChkExclude0.CheckState = CheckState.Checked;
			ChkExclude0.Location = new System.Drawing.Point(10, 78);
			ChkExclude0.Margin = new Padding(4, 3, 4, 3);
			ChkExclude0.Name = "ChkExclude0";
			ChkExclude0.Size = new System.Drawing.Size(81, 19);
			ChkExclude0.TabIndex = 28;
			ChkExclude0.Text = "Exclude 0s";
			ChkExclude0.UseVisualStyleBackColor = true;
			// 
			// NudMarkOffset
			// 
			NudMarkOffset.Location = new System.Drawing.Point(75, 22);
			NudMarkOffset.Margin = new Padding(4, 3, 4, 3);
			NudMarkOffset.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			NudMarkOffset.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
			NudMarkOffset.Name = "NudMarkOffset";
			NudMarkOffset.Size = new System.Drawing.Size(50, 23);
			NudMarkOffset.TabIndex = 24;
			NudMarkOffset.TextAlign = HorizontalAlignment.Center;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(7, 24);
			label9.Margin = new Padding(4, 0, 4, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(39, 15);
			label9.TabIndex = 25;
			label9.Text = "Offset";
			// 
			// ChkRoundupX9
			// 
			ChkRoundupX9.AutoSize = true;
			ChkRoundupX9.Checked = true;
			ChkRoundupX9.CheckState = CheckState.Checked;
			ChkRoundupX9.Location = new System.Drawing.Point(10, 52);
			ChkRoundupX9.Margin = new Padding(4, 3, 4, 3);
			ChkRoundupX9.Name = "ChkRoundupX9";
			ChkRoundupX9.Size = new System.Drawing.Size(89, 19);
			ChkRoundupX9.TabIndex = 27;
			ChkRoundupX9.Text = "Roundup *9";
			ChkRoundupX9.UseVisualStyleBackColor = true;
			// 
			// ChkShowLabels
			// 
			ChkShowLabels.AutoSize = true;
			ChkShowLabels.Location = new System.Drawing.Point(13, 600);
			ChkShowLabels.Margin = new Padding(4, 3, 4, 3);
			ChkShowLabels.Name = "ChkShowLabels";
			ChkShowLabels.Size = new System.Drawing.Size(88, 19);
			ChkShowLabels.TabIndex = 28;
			ChkShowLabels.Text = "Show labels";
			ChkShowLabels.UseVisualStyleBackColor = true;
			// 
			// CmbGrouping
			// 
			CmbGrouping.DropDownStyle = ComboBoxStyle.DropDownList;
			CmbGrouping.FormattingEnabled = true;
			CmbGrouping.Location = new System.Drawing.Point(13, 419);
			CmbGrouping.Margin = new Padding(4, 3, 4, 3);
			CmbGrouping.Name = "CmbGrouping";
			CmbGrouping.Size = new System.Drawing.Size(131, 23);
			CmbGrouping.TabIndex = 26;
			// 
			// ChkIncludeNoMark
			// 
			ChkIncludeNoMark.AutoSize = true;
			ChkIncludeNoMark.Checked = true;
			ChkIncludeNoMark.CheckState = CheckState.Checked;
			ChkIncludeNoMark.Location = new System.Drawing.Point(13, 573);
			ChkIncludeNoMark.Margin = new Padding(4, 3, 4, 3);
			ChkIncludeNoMark.Name = "ChkIncludeNoMark";
			ChkIncludeNoMark.Size = new System.Drawing.Size(129, 19);
			ChkIncludeNoMark.TabIndex = 23;
			ChkIncludeNoMark.Text = "Show missing mark";
			ChkIncludeNoMark.UseVisualStyleBackColor = true;
			// 
			// ChkOddRows
			// 
			ChkOddRows.AutoSize = true;
			ChkOddRows.Checked = true;
			ChkOddRows.CheckState = CheckState.Checked;
			ChkOddRows.Location = new System.Drawing.Point(13, 370);
			ChkOddRows.Margin = new Padding(4, 3, 4, 3);
			ChkOddRows.Name = "ChkOddRows";
			ChkOddRows.Size = new System.Drawing.Size(67, 19);
			ChkOddRows.TabIndex = 21;
			ChkOddRows.Text = "Odd Ids";
			ChkOddRows.UseVisualStyleBackColor = true;
			// 
			// ChkEvenRows
			// 
			ChkEvenRows.AutoSize = true;
			ChkEvenRows.Checked = true;
			ChkEvenRows.CheckState = CheckState.Checked;
			ChkEvenRows.Location = new System.Drawing.Point(13, 397);
			ChkEvenRows.Margin = new Padding(4, 3, 4, 3);
			ChkEvenRows.Name = "ChkEvenRows";
			ChkEvenRows.Size = new System.Drawing.Size(69, 19);
			ChkEvenRows.TabIndex = 20;
			ChkEvenRows.Text = "Even Ids";
			ChkEvenRows.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			button4.Location = new System.Drawing.Point(7, 300);
			button4.Margin = new Padding(2);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(139, 65);
			button4.TabIndex = 19;
			button4.Text = "Marks chart";
			button4.UseVisualStyleBackColor = true;
			button4.Click += marksChart_Click;
			// 
			// zedGraphControl1
			// 
			zedGraphControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			zedGraphControl1.Location = new System.Drawing.Point(153, 300);
			zedGraphControl1.Margin = new Padding(5);
			zedGraphControl1.MatchAxesScreenDataRatio = false;
			zedGraphControl1.Name = "zedGraphControl1";
			zedGraphControl1.Size = new System.Drawing.Size(784, 235);
			zedGraphControl1.TabIndex = 18;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(txtElpCode);
			groupBox3.Controls.Add(txtToolReport);
			groupBox3.Controls.Add(tabControl3);
			groupBox3.Controls.Add(label13);
			groupBox3.Location = new System.Drawing.Point(7, 14);
			groupBox3.Margin = new Padding(2);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(2);
			groupBox3.Size = new System.Drawing.Size(929, 265);
			groupBox3.TabIndex = 17;
			groupBox3.TabStop = false;
			groupBox3.Text = "Import data";
			// 
			// txtElpCode
			// 
			txtElpCode.Location = new System.Drawing.Point(281, 231);
			txtElpCode.Margin = new Padding(4, 3, 4, 3);
			txtElpCode.Name = "txtElpCode";
			txtElpCode.Size = new System.Drawing.Size(229, 23);
			txtElpCode.TabIndex = 27;
			// 
			// txtToolReport
			// 
			txtToolReport.Location = new System.Drawing.Point(518, 46);
			txtToolReport.Margin = new Padding(4, 3, 4, 3);
			txtToolReport.Multiline = true;
			txtToolReport.Name = "txtToolReport";
			txtToolReport.ScrollBars = ScrollBars.Vertical;
			txtToolReport.Size = new System.Drawing.Size(404, 208);
			txtToolReport.TabIndex = 26;
			// 
			// tabControl3
			// 
			tabControl3.Controls.Add(tabPage6);
			tabControl3.Controls.Add(tabPage11);
			tabControl3.Controls.Add(tabPage7);
			tabControl3.Controls.Add(tabPage8);
			tabControl3.Controls.Add(tabPage9);
			tabControl3.Controls.Add(tabPage10);
			tabControl3.Location = new System.Drawing.Point(6, 21);
			tabControl3.Margin = new Padding(4, 3, 4, 3);
			tabControl3.Name = "tabControl3";
			tabControl3.SelectedIndex = 0;
			tabControl3.Size = new System.Drawing.Size(505, 204);
			tabControl3.TabIndex = 26;
			// 
			// tabPage6
			// 
			tabPage6.Controls.Add(txtSourceTurnitin);
			tabPage6.Controls.Add(button8);
			tabPage6.Controls.Add(btnCompleteData);
			tabPage6.Controls.Add(button7);
			tabPage6.Location = new System.Drawing.Point(4, 24);
			tabPage6.Margin = new Padding(4, 3, 4, 3);
			tabPage6.Name = "tabPage6";
			tabPage6.Padding = new Padding(4, 3, 4, 3);
			tabPage6.Size = new System.Drawing.Size(497, 176);
			tabPage6.TabIndex = 0;
			tabPage6.Text = "Gradebook";
			tabPage6.UseVisualStyleBackColor = true;
			// 
			// txtSourceTurnitin
			// 
			txtSourceTurnitin.Location = new System.Drawing.Point(27, 7);
			txtSourceTurnitin.Margin = new Padding(4, 3, 4, 3);
			txtSourceTurnitin.Multiline = true;
			txtSourceTurnitin.Name = "txtSourceTurnitin";
			txtSourceTurnitin.Size = new System.Drawing.Size(392, 64);
			txtSourceTurnitin.TabIndex = 24;
			// 
			// button8
			// 
			button8.Location = new System.Drawing.Point(427, 46);
			button8.Margin = new Padding(4, 3, 4, 3);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(29, 25);
			button8.TabIndex = 25;
			button8.Text = "...";
			button8.UseVisualStyleBackColor = true;
			button8.Click += button8_Click;
			// 
			// btnCompleteData
			// 
			btnCompleteData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			btnCompleteData.Location = new System.Drawing.Point(27, 141);
			btnCompleteData.Margin = new Padding(2);
			btnCompleteData.Name = "btnCompleteData";
			btnCompleteData.Size = new System.Drawing.Size(426, 30);
			btnCompleteData.TabIndex = 18;
			btnCompleteData.Text = "Update database from elp Learning Analytics";
			btnCompleteData.UseVisualStyleBackColor = true;
			btnCompleteData.Click += BtnCompleteData_Click;
			// 
			// button7
			// 
			button7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			button7.Location = new System.Drawing.Point(27, 76);
			button7.Margin = new Padding(2);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(426, 61);
			button7.TabIndex = 19;
			button7.Text = "Initialize database from elp Learning Analytics  (link on top of submission list)";
			button7.UseVisualStyleBackColor = true;
			button7.Click += Button7_Click;
			// 
			// tabPage11
			// 
			tabPage11.Controls.Add(label15);
			tabPage11.Controls.Add(txtImprotFromRepoFilter);
			tabPage11.Controls.Add(label14);
			tabPage11.Controls.Add(button14);
			tabPage11.Controls.Add(cmbImportCollection);
			tabPage11.Location = new System.Drawing.Point(4, 24);
			tabPage11.Name = "tabPage11";
			tabPage11.Padding = new Padding(3);
			tabPage11.Size = new System.Drawing.Size(497, 176);
			tabPage11.TabIndex = 5;
			tabPage11.Text = "Students repo";
			tabPage11.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(7, 70);
			label15.Margin = new Padding(2, 0, 2, 0);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(162, 15);
			label15.TabIndex = 31;
			label15.Text = "Optional student filters per ID";
			// 
			// txtImprotFromRepoFilter
			// 
			txtImprotFromRepoFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtImprotFromRepoFilter.Location = new System.Drawing.Point(7, 92);
			txtImprotFromRepoFilter.Margin = new Padding(4, 3, 4, 3);
			txtImprotFromRepoFilter.Multiline = true;
			txtImprotFromRepoFilter.Name = "txtImprotFromRepoFilter";
			txtImprotFromRepoFilter.ScrollBars = ScrollBars.Both;
			txtImprotFromRepoFilter.Size = new System.Drawing.Size(488, 85);
			txtImprotFromRepoFilter.TabIndex = 30;
			txtImprotFromRepoFilter.TabStop = false;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(6, 9);
			label14.Margin = new Padding(4, 0, 4, 0);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(186, 15);
			label14.TabIndex = 29;
			label14.Text = "elp code (saved in student record)";
			// 
			// button14
			// 
			button14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			button14.Location = new System.Drawing.Point(6, 34);
			button14.Margin = new Padding(2);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(325, 30);
			button14.TabIndex = 28;
			button14.Text = "Import students";
			button14.UseVisualStyleBackColor = true;
			button14.Click += button14_Click;
			// 
			// cmbImportCollection
			// 
			cmbImportCollection.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbImportCollection.FormattingEnabled = true;
			cmbImportCollection.Location = new System.Drawing.Point(200, 6);
			cmbImportCollection.Margin = new Padding(4, 3, 4, 3);
			cmbImportCollection.Name = "cmbImportCollection";
			cmbImportCollection.Size = new System.Drawing.Size(131, 23);
			cmbImportCollection.TabIndex = 27;
			// 
			// tabPage7
			// 
			tabPage7.Controls.Add(txtSourceDataFile);
			tabPage7.Controls.Add(chkImportSubmissions);
			tabPage7.Controls.Add(lblSourceData);
			tabPage7.Controls.Add(chkImportComponents);
			tabPage7.Controls.Add(cmdSourceDataFile);
			tabPage7.Controls.Add(cmdGetData);
			tabPage7.Controls.Add(chkCommentLib);
			tabPage7.Location = new System.Drawing.Point(4, 24);
			tabPage7.Margin = new Padding(4, 3, 4, 3);
			tabPage7.Name = "tabPage7";
			tabPage7.Padding = new Padding(4, 3, 4, 3);
			tabPage7.Size = new System.Drawing.Size(497, 176);
			tabPage7.TabIndex = 1;
			tabPage7.Text = "AMM Sql";
			tabPage7.UseVisualStyleBackColor = true;
			// 
			// txtSourceDataFile
			// 
			txtSourceDataFile.Location = new System.Drawing.Point(117, 20);
			txtSourceDataFile.Margin = new Padding(4, 3, 4, 3);
			txtSourceDataFile.Multiline = true;
			txtSourceDataFile.Name = "txtSourceDataFile";
			txtSourceDataFile.Size = new System.Drawing.Size(372, 46);
			txtSourceDataFile.TabIndex = 12;
			// 
			// chkImportSubmissions
			// 
			chkImportSubmissions.AutoSize = true;
			chkImportSubmissions.Location = new System.Drawing.Point(118, 94);
			chkImportSubmissions.Margin = new Padding(2);
			chkImportSubmissions.Name = "chkImportSubmissions";
			chkImportSubmissions.Size = new System.Drawing.Size(130, 19);
			chkImportSubmissions.TabIndex = 23;
			chkImportSubmissions.Text = "Import submissions";
			chkImportSubmissions.UseVisualStyleBackColor = true;
			// 
			// lblSourceData
			// 
			lblSourceData.AutoSize = true;
			lblSourceData.Location = new System.Drawing.Point(13, 22);
			lblSourceData.Margin = new Padding(4, 0, 4, 0);
			lblSourceData.Name = "lblSourceData";
			lblSourceData.Size = new System.Drawing.Size(76, 15);
			lblSourceData.TabIndex = 14;
			lblSourceData.Text = "sqlite source:";
			// 
			// chkImportComponents
			// 
			chkImportComponents.AutoSize = true;
			chkImportComponents.Location = new System.Drawing.Point(285, 71);
			chkImportComponents.Margin = new Padding(2);
			chkImportComponents.Name = "chkImportComponents";
			chkImportComponents.Size = new System.Drawing.Size(162, 19);
			chkImportComponents.TabIndex = 17;
			chkImportComponents.Text = "Import mark components";
			chkImportComponents.UseVisualStyleBackColor = true;
			// 
			// cmdSourceDataFile
			// 
			cmdSourceDataFile.Location = new System.Drawing.Point(460, 72);
			cmdSourceDataFile.Margin = new Padding(4, 3, 4, 3);
			cmdSourceDataFile.Name = "cmdSourceDataFile";
			cmdSourceDataFile.Size = new System.Drawing.Size(29, 25);
			cmdSourceDataFile.TabIndex = 13;
			cmdSourceDataFile.Text = "...";
			cmdSourceDataFile.UseVisualStyleBackColor = true;
			cmdSourceDataFile.Click += cmdSourceDataFile_Click;
			// 
			// cmdGetData
			// 
			cmdGetData.Location = new System.Drawing.Point(118, 117);
			cmdGetData.Margin = new Padding(2);
			cmdGetData.Name = "cmdGetData";
			cmdGetData.Size = new System.Drawing.Size(329, 30);
			cmdGetData.TabIndex = 15;
			cmdGetData.Text = "Get Data";
			cmdGetData.UseVisualStyleBackColor = true;
			cmdGetData.Click += cmdGetData_Click;
			// 
			// chkCommentLib
			// 
			chkCommentLib.AutoSize = true;
			chkCommentLib.Location = new System.Drawing.Point(117, 71);
			chkCommentLib.Margin = new Padding(2);
			chkCommentLib.Name = "chkCommentLib";
			chkCommentLib.Size = new System.Drawing.Size(158, 19);
			chkCommentLib.TabIndex = 16;
			chkCommentLib.Text = "Import Comment Library";
			chkCommentLib.UseVisualStyleBackColor = true;
			// 
			// tabPage8
			// 
			tabPage8.Controls.Add(button10);
			tabPage8.Controls.Add(button9);
			tabPage8.Location = new System.Drawing.Point(4, 24);
			tabPage8.Margin = new Padding(4, 3, 4, 3);
			tabPage8.Name = "tabPage8";
			tabPage8.Size = new System.Drawing.Size(497, 176);
			tabPage8.TabIndex = 2;
			tabPage8.Text = "DocumentArchive";
			tabPage8.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			button10.Location = new System.Drawing.Point(21, 48);
			button10.Margin = new Padding(4, 3, 4, 3);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(422, 27);
			button10.TabIndex = 1;
			button10.Text = "Get manifest information";
			button10.UseVisualStyleBackColor = true;
			button10.Click += Button10_Click;
			// 
			// button9
			// 
			button9.Location = new System.Drawing.Point(21, 15);
			button9.Margin = new Padding(4, 3, 4, 3);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(422, 27);
			button9.TabIndex = 0;
			button9.Text = "Expand";
			button9.UseVisualStyleBackColor = true;
			button9.Click += button9_Click;
			// 
			// tabPage9
			// 
			tabPage9.Controls.Add(TxtExcelComponentSource);
			tabPage9.Controls.Add(BtnImportExcel);
			tabPage9.Controls.Add(BtnExportExcel);
			tabPage9.Location = new System.Drawing.Point(4, 24);
			tabPage9.Margin = new Padding(4, 3, 4, 3);
			tabPage9.Name = "tabPage9";
			tabPage9.Padding = new Padding(4, 3, 4, 3);
			tabPage9.Size = new System.Drawing.Size(497, 176);
			tabPage9.TabIndex = 3;
			tabPage9.Text = "Excel";
			tabPage9.UseVisualStyleBackColor = true;
			// 
			// TxtExcelComponentSource
			// 
			TxtExcelComponentSource.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtExcelComponentSource.Location = new System.Drawing.Point(7, 112);
			TxtExcelComponentSource.Margin = new Padding(4, 3, 4, 3);
			TxtExcelComponentSource.Multiline = true;
			TxtExcelComponentSource.Name = "TxtExcelComponentSource";
			TxtExcelComponentSource.Size = new System.Drawing.Size(481, 25);
			TxtExcelComponentSource.TabIndex = 10;
			TxtExcelComponentSource.TabStop = false;
			// 
			// BtnImportExcel
			// 
			BtnImportExcel.Location = new System.Drawing.Point(7, 62);
			BtnImportExcel.Margin = new Padding(4, 3, 4, 3);
			BtnImportExcel.Name = "BtnImportExcel";
			BtnImportExcel.Size = new System.Drawing.Size(222, 48);
			BtnImportExcel.TabIndex = 1;
			BtnImportExcel.Text = "Import Excel Components";
			BtnImportExcel.UseVisualStyleBackColor = true;
			BtnImportExcel.Click += BtnImportExcel_Click;
			// 
			// BtnExportExcel
			// 
			BtnExportExcel.Location = new System.Drawing.Point(7, 7);
			BtnExportExcel.Margin = new Padding(4, 3, 4, 3);
			BtnExportExcel.Name = "BtnExportExcel";
			BtnExportExcel.Size = new System.Drawing.Size(222, 48);
			BtnExportExcel.TabIndex = 0;
			BtnExportExcel.Text = "Export excel";
			BtnExportExcel.UseVisualStyleBackColor = true;
			BtnExportExcel.Click += BtnExportExcel_Click;
			// 
			// tabPage10
			// 
			tabPage10.Controls.Add(label12);
			tabPage10.Controls.Add(TxtScaleFactor);
			tabPage10.Controls.Add(TxtMergeReportFolder);
			tabPage10.Controls.Add(BtnMergeReport);
			tabPage10.Location = new System.Drawing.Point(4, 24);
			tabPage10.Margin = new Padding(4, 3, 4, 3);
			tabPage10.Name = "tabPage10";
			tabPage10.Padding = new Padding(4, 3, 4, 3);
			tabPage10.Size = new System.Drawing.Size(497, 176);
			tabPage10.TabIndex = 4;
			tabPage10.Text = "PlagiarismReport";
			tabPage10.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(14, 100);
			label12.Margin = new Padding(4, 0, 4, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(34, 15);
			label12.TabIndex = 14;
			label12.Text = "Scale";
			// 
			// TxtScaleFactor
			// 
			TxtScaleFactor.Location = new System.Drawing.Point(61, 97);
			TxtScaleFactor.Margin = new Padding(4, 3, 4, 3);
			TxtScaleFactor.Name = "TxtScaleFactor";
			TxtScaleFactor.Size = new System.Drawing.Size(153, 23);
			TxtScaleFactor.TabIndex = 13;
			TxtScaleFactor.Text = "1.0";
			TxtScaleFactor.TextAlign = HorizontalAlignment.Right;
			// 
			// TxtMergeReportFolder
			// 
			TxtMergeReportFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtMergeReportFolder.Location = new System.Drawing.Point(14, 77);
			TxtMergeReportFolder.Margin = new Padding(4, 3, 4, 3);
			TxtMergeReportFolder.Multiline = true;
			TxtMergeReportFolder.Name = "TxtMergeReportFolder";
			TxtMergeReportFolder.Size = new System.Drawing.Size(461, 57);
			TxtMergeReportFolder.TabIndex = 12;
			TxtMergeReportFolder.TabStop = false;
			// 
			// BtnMergeReport
			// 
			BtnMergeReport.Location = new System.Drawing.Point(18, 18);
			BtnMergeReport.Margin = new Padding(4, 3, 4, 3);
			BtnMergeReport.Name = "BtnMergeReport";
			BtnMergeReport.Size = new System.Drawing.Size(197, 48);
			BtnMergeReport.TabIndex = 11;
			BtnMergeReport.Text = "Merge reports";
			BtnMergeReport.UseVisualStyleBackColor = true;
			BtnMergeReport.Click += BtnMergeReport_Click;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(87, 235);
			label13.Margin = new Padding(4, 0, 4, 0);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(186, 15);
			label13.TabIndex = 26;
			label13.Text = "elp code (saved in student record)";
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 5;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
			tableLayoutPanel4.Controls.Add(cmdReload, 3, 0);
			tableLayoutPanel4.Controls.Add(label5, 0, 0);
			tableLayoutPanel4.Controls.Add(cmdSelectFile, 2, 0);
			tableLayoutPanel4.Controls.Add(txtExcelFileName, 1, 0);
			tableLayoutPanel4.Controls.Add(BtnOpenFolder, 4, 0);
			tableLayoutPanel4.Dock = DockStyle.Top;
			tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel4.Margin = new Padding(2);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.Size = new System.Drawing.Size(1631, 37);
			tableLayoutPanel4.TabIndex = 13;
			// 
			// BtnOpenFolder
			// 
			BtnOpenFolder.Image = UnnItBooster.Properties.Resources.folder;
			BtnOpenFolder.Location = new System.Drawing.Point(1600, 3);
			BtnOpenFolder.Margin = new Padding(4, 3, 4, 3);
			BtnOpenFolder.Name = "BtnOpenFolder";
			BtnOpenFolder.Size = new System.Drawing.Size(27, 27);
			BtnOpenFolder.TabIndex = 13;
			BtnOpenFolder.UseVisualStyleBackColor = true;
			BtnOpenFolder.Click += BtnOpenFolder_Click;
			// 
			// FrmMarkingMachine
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1631, 710);
			Controls.Add(tabControl1);
			Controls.Add(tableLayoutPanel4);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4, 3, 4, 3);
			Name = "FrmMarkingMachine";
			Text = "Marking Machine";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer4.Panel1.ResumeLayout(false);
			splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
			splitContainer4.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox4.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			splitContainer3.Panel1.ResumeLayout(false);
			splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
			splitContainer3.ResumeLayout(false);
			splitContainer5.Panel1.ResumeLayout(false);
			splitContainer5.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
			splitContainer5.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NudOverlap).EndInit();
			((System.ComponentModel.ISupportInitialize)StudImage).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			tabControl2.ResumeLayout(false);
			tabPage4.ResumeLayout(false);
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NudMarkOffset).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			tabControl3.ResumeLayout(false);
			tabPage6.ResumeLayout(false);
			tabPage6.PerformLayout();
			tabPage11.ResumeLayout(false);
			tabPage11.PerformLayout();
			tabPage7.ResumeLayout(false);
			tabPage7.PerformLayout();
			tabPage8.ResumeLayout(false);
			tabPage9.ResumeLayout(false);
			tabPage9.PerformLayout();
			tabPage10.ResumeLayout(false);
			tabPage10.PerformLayout();
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			ResumeLayout(false);
		}


		#endregion

		private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtLibReport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ExtendedTextBox.ExtTextBox txtAdditionalNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtSection;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.TextBox txtExcelFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdSaveMarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbDocuments;
        private ExtendedTextBox.ExtTextBox txtStudentreport;
        private ExtendedTextBox.ExtTextBox txtTextOrPointer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button cmdEmailRefreshStudents;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lstEmailSendSelection;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colNumMarks;
        private System.Windows.Forms.ComboBox cmbEmailSubject;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkEmailDryRun;
        private System.Windows.Forms.ColumnHeader colMark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbComponentComment;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button cmdGetData;
        private System.Windows.Forms.Label lblSourceData;
        private System.Windows.Forms.Button cmdSourceDataFile;
        private System.Windows.Forms.TextBox txtSourceDataFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkImportComponents;
        private System.Windows.Forms.CheckBox chkCommentLib;
        private System.Windows.Forms.FlowLayoutPanel flComponents;
        private System.Windows.Forms.Button cmdReload;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button button4;
		private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart zedGraphControl1;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.PictureBox StudImage;
        private System.Windows.Forms.CheckBox chkSendModerationNotice;
        private ExtendedTextBox.ExtTextBox txtEmailBody;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtEmailPreview;
        private System.Windows.Forms.Button cmdSaveEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader colNumComments;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ColumnHeader colSimilarity;
        private System.Windows.Forms.Button btnCompleteData;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox chkImportSubmissions;
		private System.Windows.Forms.TextBox txtSourceTurnitin;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox txtToolReport;
		private System.Windows.Forms.TabControl tabControl3;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private Button BtnOpenFolder;
		private TabPage tabPage9;
		private Button BtnExportExcel;
		private Button button11;
		private Button button12;
		private Button BtnImportExcel;
		private TextBox TxtExcelComponentSource;
		private CheckBox ChkAutoStat;
		private Label LblMark;
		private CheckBox ChkCommNumber;
		private Label label1;
		private Button BtnEditLast;
		private Button BtnShowStudentStat;
		private ColumnHeader colLastUpdate;
		private CheckBox ChkOddRows;
		private CheckBox ChkEvenRows;
		private CheckBox ChkIncludeNoMark;
		private Label label9;
		private NumericUpDown NudMarkOffset;
		private ComboBox CmbGrouping;
		private CheckBox ChkRoundupX9;
		private CheckBox ChkShowLabels;
		private GroupBox groupBox1;
		private Label LblOverlap;
		private NumericUpDown NudOverlap;
		private CheckBox ChkExclude0;
		private TabPage tabPage10;
		private TextBox TxtMergeReportFolder;
		private Button BtnMergeReport;
		private Label label12;
		private TextBox TxtScaleFactor;
		private TextBox txtElpCode;
		private Label label13;
		private CheckBox chkShowDelegate;
		private Panel panel1;
		private Button cmdWrap;
		private Button cmdReportSizeDecrease;
		private Button cmdReportSizeIncrease;
		private Button cmdSetFromDelegatedMarks;
		private GroupBox groupBox4;
		private CheckBox chkUseSorting;
		private Button button13;
		private TabPage tabPage11;
		private ComboBox cmbImportCollection;
		private Label label14;
		private Button button14;
		private Button cmdListVariables;
		private Label label15;
		private TextBox txtImprotFromRepoFilter;
		private CheckBox chkJustComponents;
	}
}

