﻿using System;
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
			txtStudentId.Location = new System.Drawing.Point(0, 30);
			txtStudentId.Margin = new Padding(7, 6, 7, 6);
			txtStudentId.Name = "txtStudentId";
			txtStudentId.Size = new System.Drawing.Size(699, 35);
			txtStudentId.TabIndex = 0;
			txtStudentId.TabStop = false;
			txtStudentId.KeyDown += txtStudentId_KeyDown;
			// 
			// txtSearch
			// 
			txtSearch.Dock = DockStyle.Fill;
			txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSearch.Location = new System.Drawing.Point(0, 30);
			txtSearch.Margin = new Padding(7, 6, 7, 6);
			txtSearch.Name = "txtSearch";
			txtSearch.Size = new System.Drawing.Size(620, 45);
			txtSearch.TabIndex = 3;
			txtSearch.KeyDown += txtSearch_KeyDown;
			// 
			// cmdAdd
			// 
			cmdAdd.Location = new System.Drawing.Point(253, 1201);
			cmdAdd.Margin = new Padding(7, 6, 7, 6);
			cmdAdd.Name = "cmdAdd";
			cmdAdd.Size = new System.Drawing.Size(151, 54);
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
			txtLibReport.Location = new System.Drawing.Point(0, 92);
			txtLibReport.Margin = new Padding(7, 6, 7, 6);
			txtLibReport.Multiline = true;
			txtLibReport.Name = "txtLibReport";
			txtLibReport.ScrollBars = ScrollBars.Both;
			txtLibReport.Size = new System.Drawing.Size(620, 923);
			txtLibReport.TabIndex = 2;
			txtLibReport.TabStop = false;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.Location = new System.Drawing.Point(7, 6);
			splitContainer1.Margin = new Padding(7, 6, 7, 6);
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
			splitContainer1.Size = new System.Drawing.Size(2436, 1291);
			splitContainer1.SplitterDistance = 699;
			splitContainer1.SplitterWidth = 9;
			splitContainer1.TabIndex = 8;
			splitContainer1.TabStop = false;
			// 
			// splitContainer4
			// 
			splitContainer4.Dock = DockStyle.Fill;
			splitContainer4.Location = new System.Drawing.Point(0, 123);
			splitContainer4.Margin = new Padding(3, 4, 3, 4);
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
			splitContainer4.Size = new System.Drawing.Size(699, 1168);
			splitContainer4.SplitterDistance = 514;
			splitContainer4.SplitterWidth = 6;
			splitContainer4.TabIndex = 15;
			// 
			// txtStudentreport
			// 
			txtStudentreport.AcceptsReturn = true;
			txtStudentreport.AcceptsTab = true;
			txtStudentreport.ChangedColour = System.Drawing.Color.Empty;
			txtStudentreport.Dock = DockStyle.Fill;
			txtStudentreport.Location = new System.Drawing.Point(0, 0);
			txtStudentreport.Margin = new Padding(9, 10, 9, 10);
			txtStudentreport.MaxLength = 0;
			txtStudentreport.Name = "txtStudentreport";
			txtStudentreport.OriginalText = "";
			txtStudentreport.Size = new System.Drawing.Size(699, 514);
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
			flComponents.Location = new System.Drawing.Point(0, 108);
			flComponents.Margin = new Padding(3, 4, 3, 4);
			flComponents.Name = "flComponents";
			flComponents.Size = new System.Drawing.Size(699, 490);
			flComponents.TabIndex = 13;
			// 
			// LblMark
			// 
			LblMark.Dock = DockStyle.Top;
			LblMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			LblMark.Location = new System.Drawing.Point(0, 0);
			LblMark.Name = "LblMark";
			LblMark.Size = new System.Drawing.Size(699, 108);
			LblMark.TabIndex = 0;
			LblMark.Text = "-";
			LblMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			LblMark.Click += LblMark_Click;
			// 
			// cmdSaveMarks
			// 
			cmdSaveMarks.Dock = DockStyle.Bottom;
			cmdSaveMarks.Location = new System.Drawing.Point(0, 598);
			cmdSaveMarks.Margin = new Padding(7, 6, 7, 6);
			cmdSaveMarks.Name = "cmdSaveMarks";
			cmdSaveMarks.Size = new System.Drawing.Size(699, 50);
			cmdSaveMarks.TabIndex = 6;
			cmdSaveMarks.Text = "Ok";
			cmdSaveMarks.UseVisualStyleBackColor = true;
			cmdSaveMarks.Click += CmdSaveMarks_Click;
			// 
			// panel2
			// 
			panel2.Controls.Add(chkUseSorting);
			panel2.Controls.Add(LblOverlap);
			panel2.Controls.Add(button12);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(button5);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new System.Drawing.Point(0, 65);
			panel2.Margin = new Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(699, 58);
			panel2.TabIndex = 17;
			// 
			// chkUseSorting
			// 
			chkUseSorting.AutoSize = true;
			chkUseSorting.Location = new System.Drawing.Point(290, 10);
			chkUseSorting.Margin = new Padding(7, 6, 7, 6);
			chkUseSorting.Name = "chkUseSorting";
			chkUseSorting.Size = new System.Drawing.Size(143, 34);
			chkUseSorting.TabIndex = 4;
			chkUseSorting.Text = "Use sorting";
			chkUseSorting.UseVisualStyleBackColor = true;
			chkUseSorting.CheckedChanged += chkUseSorting_CheckedChanged;
			// 
			// LblOverlap
			// 
			LblOverlap.AutoSize = true;
			LblOverlap.Location = new System.Drawing.Point(130, 12);
			LblOverlap.Margin = new Padding(7, 0, 7, 0);
			LblOverlap.Name = "LblOverlap";
			LblOverlap.Size = new System.Drawing.Size(21, 30);
			LblOverlap.TabIndex = 3;
			LblOverlap.Text = "-";
			// 
			// button12
			// 
			button12.Location = new System.Drawing.Point(9, 4);
			button12.Margin = new Padding(3, 4, 3, 4);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(111, 44);
			button12.TabIndex = 2;
			button12.Text = "html";
			button12.UseVisualStyleBackColor = true;
			button12.Click += button12_Click;
			// 
			// button6
			// 
			button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button6.Location = new System.Drawing.Point(459, 4);
			button6.Margin = new Padding(3, 4, 3, 4);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(111, 44);
			button6.TabIndex = 0;
			button6.Text = "-";
			button6.UseVisualStyleBackColor = true;
			button6.Click += button6_Click;
			// 
			// button5
			// 
			button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button5.Location = new System.Drawing.Point(579, 4);
			button5.Margin = new Padding(3, 4, 3, 4);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(111, 44);
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
			label6.Margin = new Padding(7, 0, 7, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(89, 30);
			label6.TabIndex = 12;
			label6.Text = "Student:";
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.FixedPanel = FixedPanel.Panel2;
			splitContainer2.Location = new System.Drawing.Point(0, 0);
			splitContainer2.Margin = new Padding(7, 6, 7, 6);
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
			splitContainer2.Size = new System.Drawing.Size(1728, 1291);
			splitContainer2.SplitterDistance = 620;
			splitContainer2.SplitterWidth = 9;
			splitContainer2.TabIndex = 0;
			splitContainer2.TabStop = false;
			// 
			// panel1
			// 
			panel1.Controls.Add(txtSearch);
			panel1.Controls.Add(label8);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Margin = new Padding(7, 6, 7, 6);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(620, 92);
			panel1.TabIndex = 16;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Dock = DockStyle.Top;
			label8.Location = new System.Drawing.Point(0, 0);
			label8.Margin = new Padding(7, 0, 7, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(80, 30);
			label8.TabIndex = 14;
			label8.Text = "Search:";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(cmdSetFromDelegatedMarks);
			groupBox2.Controls.Add(groupBox4);
			groupBox2.Controls.Add(ChkCommNumber);
			groupBox2.Controls.Add(cmdReportSizeDecrease);
			groupBox2.Controls.Add(cmdReportSizeIncrease);
			groupBox2.Controls.Add(cmdWrap);
			groupBox2.Controls.Add(ChkAutoStat);
			groupBox2.Controls.Add(BtnShowStudentStat);
			groupBox2.Dock = DockStyle.Bottom;
			groupBox2.Location = new System.Drawing.Point(0, 1015);
			groupBox2.Margin = new Padding(7, 6, 7, 6);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(7, 6, 7, 6);
			groupBox2.Size = new System.Drawing.Size(620, 276);
			groupBox2.TabIndex = 15;
			groupBox2.TabStop = false;
			groupBox2.Text = "Documents downloaded";
			// 
			// cmdSetFromDelegatedMarks
			// 
			cmdSetFromDelegatedMarks.Location = new System.Drawing.Point(238, 78);
			cmdSetFromDelegatedMarks.Margin = new Padding(7, 6, 7, 6);
			cmdSetFromDelegatedMarks.Name = "cmdSetFromDelegatedMarks";
			cmdSetFromDelegatedMarks.Size = new System.Drawing.Size(358, 54);
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
			groupBox4.Location = new System.Drawing.Point(14, 154);
			groupBox4.Margin = new Padding(7, 6, 7, 6);
			groupBox4.Name = "groupBox4";
			groupBox4.Padding = new Padding(7, 6, 7, 6);
			groupBox4.Size = new System.Drawing.Size(594, 108);
			groupBox4.TabIndex = 5;
			groupBox4.TabStop = false;
			groupBox4.Text = "Documents downloaded";
			// 
			// button13
			// 
			button13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button13.Location = new System.Drawing.Point(388, 44);
			button13.Margin = new Padding(7, 6, 7, 6);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(108, 54);
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
			cmbDocuments.Location = new System.Drawing.Point(12, 44);
			cmbDocuments.Margin = new Padding(7, 6, 7, 6);
			cmbDocuments.Name = "cmbDocuments";
			cmbDocuments.Size = new System.Drawing.Size(360, 38);
			cmbDocuments.TabIndex = 0;
			cmbDocuments.TabStop = false;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button2.Location = new System.Drawing.Point(494, 44);
			button2.Margin = new Padding(7, 6, 7, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(87, 54);
			button2.TabIndex = 2;
			button2.Text = "Open";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Open_Click;
			// 
			// ChkCommNumber
			// 
			ChkCommNumber.AutoSize = true;
			ChkCommNumber.Location = new System.Drawing.Point(158, 36);
			ChkCommNumber.Margin = new Padding(3, 4, 3, 4);
			ChkCommNumber.Name = "ChkCommNumber";
			ChkCommNumber.Size = new System.Drawing.Size(226, 34);
			ChkCommNumber.TabIndex = 4;
			ChkCommNumber.Text = "Add Comm Number";
			ChkCommNumber.UseVisualStyleBackColor = true;
			// 
			// cmdReportSizeDecrease
			// 
			cmdReportSizeDecrease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdReportSizeDecrease.Location = new System.Drawing.Point(436, 28);
			cmdReportSizeDecrease.Margin = new Padding(7, 6, 7, 6);
			cmdReportSizeDecrease.Name = "cmdReportSizeDecrease";
			cmdReportSizeDecrease.Size = new System.Drawing.Size(48, 48);
			cmdReportSizeDecrease.TabIndex = 17;
			cmdReportSizeDecrease.Text = "-";
			cmdReportSizeDecrease.UseVisualStyleBackColor = true;
			cmdReportSizeDecrease.Click += cmdReportSizeDecrease_Click;
			// 
			// cmdReportSizeIncrease
			// 
			cmdReportSizeIncrease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdReportSizeIncrease.Location = new System.Drawing.Point(484, 28);
			cmdReportSizeIncrease.Margin = new Padding(7, 6, 7, 6);
			cmdReportSizeIncrease.Name = "cmdReportSizeIncrease";
			cmdReportSizeIncrease.Size = new System.Drawing.Size(48, 48);
			cmdReportSizeIncrease.TabIndex = 16;
			cmdReportSizeIncrease.Text = "+";
			cmdReportSizeIncrease.UseVisualStyleBackColor = true;
			cmdReportSizeIncrease.Click += cmdReportSizeIncrease_Click;
			// 
			// cmdWrap
			// 
			cmdWrap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdWrap.Location = new System.Drawing.Point(529, 28);
			cmdWrap.Margin = new Padding(7, 6, 7, 6);
			cmdWrap.Name = "cmdWrap";
			cmdWrap.Size = new System.Drawing.Size(81, 48);
			cmdWrap.TabIndex = 15;
			cmdWrap.Text = "wrap";
			cmdWrap.UseVisualStyleBackColor = true;
			cmdWrap.Click += cmdWrap_Click;
			// 
			// ChkAutoStat
			// 
			ChkAutoStat.AutoSize = true;
			ChkAutoStat.Location = new System.Drawing.Point(14, 36);
			ChkAutoStat.Margin = new Padding(3, 4, 3, 4);
			ChkAutoStat.Name = "ChkAutoStat";
			ChkAutoStat.Size = new System.Drawing.Size(124, 34);
			ChkAutoStat.TabIndex = 3;
			ChkAutoStat.Text = "Auto stat";
			ChkAutoStat.UseVisualStyleBackColor = true;
			// 
			// BtnShowStudentStat
			// 
			BtnShowStudentStat.Location = new System.Drawing.Point(10, 78);
			BtnShowStudentStat.Margin = new Padding(7, 6, 7, 6);
			BtnShowStudentStat.Name = "BtnShowStudentStat";
			BtnShowStudentStat.Size = new System.Drawing.Size(216, 54);
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
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
			tableLayoutPanel1.Margin = new Padding(7, 6, 7, 6);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 7;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(1099, 1261);
			tableLayoutPanel1.TabIndex = 8;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(7, 1106);
			label4.Margin = new Padding(7, 0, 7, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(56, 30);
			label4.TabIndex = 19;
			label4.Text = "Area";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 617);
			label2.Margin = new Padding(12, 14, 12, 14);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(176, 30);
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
			txtTextOrPointer.Location = new System.Drawing.Point(256, 120);
			txtTextOrPointer.Margin = new Padding(10, 12, 10, 12);
			txtTextOrPointer.MaxLength = 0;
			txtTextOrPointer.Name = "txtTextOrPointer";
			txtTextOrPointer.OriginalText = "";
			txtTextOrPointer.Size = new System.Drawing.Size(833, 471);
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
			txtAdditionalNote.Location = new System.Drawing.Point(256, 615);
			txtAdditionalNote.Margin = new Padding(10, 12, 10, 12);
			txtAdditionalNote.MaxLength = 0;
			txtAdditionalNote.Name = "txtAdditionalNote";
			txtAdditionalNote.OriginalText = "";
			txtAdditionalNote.Size = new System.Drawing.Size(833, 471);
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
			label1.Location = new System.Drawing.Point(12, 122);
			label1.Margin = new Padding(12, 14, 12, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 30);
			label1.TabIndex = 10;
			label1.Text = "ptr/text";
			label1.Click += label1_Click;
			// 
			// txtArea
			// 
			txtArea.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtArea.Location = new System.Drawing.Point(253, 1104);
			txtArea.Margin = new Padding(7, 6, 7, 6);
			txtArea.Name = "txtArea";
			txtArea.Size = new System.Drawing.Size(839, 35);
			txtArea.TabIndex = 12;
			txtArea.TabStop = false;
			// 
			// label11
			// 
			label11.Anchor = AnchorStyles.Left;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(7, 1155);
			label11.Margin = new Padding(7, 0, 7, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(122, 30);
			label11.TabIndex = 20;
			label11.Text = "Component";
			// 
			// cmbComponentComment
			// 
			cmbComponentComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbComponentComment.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbComponentComment.FormattingEnabled = true;
			cmbComponentComment.Location = new System.Drawing.Point(253, 1151);
			cmbComponentComment.Margin = new Padding(7, 6, 7, 6);
			cmbComponentComment.Name = "cmbComponentComment";
			cmbComponentComment.Size = new System.Drawing.Size(839, 38);
			cmbComponentComment.TabIndex = 21;
			cmbComponentComment.TabStop = false;
			// 
			// txtSection
			// 
			txtSection.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtSection.Location = new System.Drawing.Point(253, 6);
			txtSection.Margin = new Padding(7, 6, 7, 6);
			txtSection.Name = "txtSection";
			txtSection.Size = new System.Drawing.Size(839, 38);
			txtSection.TabIndex = 11;
			txtSection.TabStop = false;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(7, 10);
			label3.Margin = new Padding(7, 0, 7, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(81, 30);
			label3.TabIndex = 18;
			label3.Text = "Section";
			// 
			// button11
			// 
			button11.Dock = DockStyle.Fill;
			button11.Location = new System.Drawing.Point(253, 56);
			button11.Margin = new Padding(7, 6, 7, 6);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(839, 46);
			button11.TabIndex = 22;
			button11.Text = "Section rotation";
			button11.UseVisualStyleBackColor = true;
			button11.Click += button11_Click;
			// 
			// BtnEditLast
			// 
			BtnEditLast.Location = new System.Drawing.Point(7, 56);
			BtnEditLast.Margin = new Padding(7, 6, 7, 6);
			BtnEditLast.Name = "BtnEditLast";
			BtnEditLast.Size = new System.Drawing.Size(137, 44);
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
			label7.Margin = new Padding(7, 0, 7, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(104, 30);
			label7.TabIndex = 13;
			label7.Text = "Comment";
			// 
			// cmdSelectFile
			// 
			cmdSelectFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			cmdSelectFile.Location = new System.Drawing.Point(2285, 12);
			cmdSelectFile.Margin = new Padding(7, 6, 7, 6);
			cmdSelectFile.Name = "cmdSelectFile";
			cmdSelectFile.Size = new System.Drawing.Size(46, 50);
			cmdSelectFile.TabIndex = 10;
			cmdSelectFile.TabStop = false;
			cmdSelectFile.Text = "...";
			cmdSelectFile.UseVisualStyleBackColor = true;
			cmdSelectFile.Click += cmdSelectFile_Click;
			// 
			// txtExcelFileName
			// 
			txtExcelFileName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtExcelFileName.Location = new System.Drawing.Point(127, 14);
			txtExcelFileName.Margin = new Padding(7, 6, 7, 6);
			txtExcelFileName.Multiline = true;
			txtExcelFileName.Name = "txtExcelFileName";
			txtExcelFileName.Size = new System.Drawing.Size(2144, 46);
			txtExcelFileName.TabIndex = 9;
			txtExcelFileName.TabStop = false;
			txtExcelFileName.TextChanged += txtExcelFileName_TextChanged;
			// 
			// cmdReload
			// 
			cmdReload.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			cmdReload.Location = new System.Drawing.Point(2345, 12);
			cmdReload.Margin = new Padding(7, 6, 7, 6);
			cmdReload.Name = "cmdReload";
			cmdReload.Size = new System.Drawing.Size(46, 50);
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
			label5.Location = new System.Drawing.Point(7, 22);
			label5.Margin = new Padding(7, 0, 7, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(79, 30);
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
			tabControl1.Location = new System.Drawing.Point(0, 74);
			tabControl1.Margin = new Padding(7, 6, 7, 6);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(2458, 1346);
			tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(splitContainer1);
			tabPage1.Location = new System.Drawing.Point(4, 39);
			tabPage1.Margin = new Padding(7, 6, 7, 6);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(7, 6, 7, 6);
			tabPage1.Size = new System.Drawing.Size(2450, 1303);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Marking";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(splitContainer3);
			tabPage2.Location = new System.Drawing.Point(4, 39);
			tabPage2.Margin = new Padding(7, 6, 7, 6);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(7, 6, 7, 6);
			tabPage2.Size = new System.Drawing.Size(2450, 1303);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Emailing";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			splitContainer3.Dock = DockStyle.Fill;
			splitContainer3.Location = new System.Drawing.Point(7, 6);
			splitContainer3.Margin = new Padding(7, 6, 7, 6);
			splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			splitContainer3.Panel1.Controls.Add(splitContainer5);
			// 
			// splitContainer3.Panel2
			// 
			splitContainer3.Panel2.Controls.Add(tableLayoutPanel3);
			splitContainer3.Size = new System.Drawing.Size(2436, 1291);
			splitContainer3.SplitterDistance = 960;
			splitContainer3.SplitterWidth = 9;
			splitContainer3.TabIndex = 3;
			// 
			// splitContainer5
			// 
			splitContainer5.Dock = DockStyle.Fill;
			splitContainer5.FixedPanel = FixedPanel.Panel2;
			splitContainer5.Location = new System.Drawing.Point(0, 0);
			splitContainer5.Margin = new Padding(3, 4, 3, 4);
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
			splitContainer5.Size = new System.Drawing.Size(960, 1291);
			splitContainer5.SplitterDistance = 849;
			splitContainer5.SplitterWidth = 6;
			splitContainer5.TabIndex = 14;
			// 
			// lstEmailSendSelection
			// 
			lstEmailSendSelection.CheckBoxes = true;
			lstEmailSendSelection.Columns.AddRange(new ColumnHeader[] { colName, colNumMarks, colMark, colLastUpdate, colNumComments, colSimilarity });
			lstEmailSendSelection.Dock = DockStyle.Fill;
			lstEmailSendSelection.FullRowSelect = true;
			lstEmailSendSelection.GridLines = true;
			lstEmailSendSelection.Location = new System.Drawing.Point(0, 70);
			lstEmailSendSelection.Margin = new Padding(7, 6, 7, 6);
			lstEmailSendSelection.Name = "lstEmailSendSelection";
			lstEmailSendSelection.Size = new System.Drawing.Size(960, 779);
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
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 201F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 245F));
			tableLayoutPanel2.Controls.Add(cmdEmailRefreshStudents, 0, 0);
			tableLayoutPanel2.Controls.Add(cmdSelectAll, 1, 0);
			tableLayoutPanel2.Controls.Add(NudOverlap, 2, 0);
			tableLayoutPanel2.Controls.Add(chkShowDelegate, 3, 0);
			tableLayoutPanel2.Dock = DockStyle.Top;
			tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.Size = new System.Drawing.Size(960, 70);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// cmdEmailRefreshStudents
			// 
			cmdEmailRefreshStudents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmdEmailRefreshStudents.Location = new System.Drawing.Point(7, 6);
			cmdEmailRefreshStudents.Margin = new Padding(7, 6, 7, 6);
			cmdEmailRefreshStudents.Name = "cmdEmailRefreshStudents";
			cmdEmailRefreshStudents.Size = new System.Drawing.Size(242, 54);
			cmdEmailRefreshStudents.TabIndex = 2;
			cmdEmailRefreshStudents.Text = "Refresh";
			cmdEmailRefreshStudents.UseVisualStyleBackColor = true;
			cmdEmailRefreshStudents.Click += cmdEmailRefreshStudents_Click;
			// 
			// cmdSelectAll
			// 
			cmdSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmdSelectAll.Location = new System.Drawing.Point(263, 6);
			cmdSelectAll.Margin = new Padding(7, 6, 7, 6);
			cmdSelectAll.Name = "cmdSelectAll";
			cmdSelectAll.Size = new System.Drawing.Size(243, 54);
			cmdSelectAll.TabIndex = 4;
			cmdSelectAll.Text = "All";
			cmdSelectAll.UseVisualStyleBackColor = true;
			cmdSelectAll.Click += cmdSelectAll_Click;
			// 
			// NudOverlap
			// 
			NudOverlap.Anchor = AnchorStyles.None;
			NudOverlap.Location = new System.Drawing.Point(553, 17);
			NudOverlap.Margin = new Padding(7, 6, 7, 6);
			NudOverlap.Name = "NudOverlap";
			NudOverlap.Size = new System.Drawing.Size(120, 35);
			NudOverlap.TabIndex = 5;
			NudOverlap.TextAlign = HorizontalAlignment.Center;
			NudOverlap.Value = new decimal(new int[] { 25, 0, 0, 0 });
			// 
			// chkShowDelegate
			// 
			chkShowDelegate.Anchor = AnchorStyles.None;
			chkShowDelegate.AutoSize = true;
			chkShowDelegate.Location = new System.Drawing.Point(776, 18);
			chkShowDelegate.Margin = new Padding(7, 6, 7, 6);
			chkShowDelegate.Name = "chkShowDelegate";
			chkShowDelegate.Size = new System.Drawing.Size(122, 34);
			chkShowDelegate.TabIndex = 6;
			chkShowDelegate.Text = "Delegate";
			chkShowDelegate.UseVisualStyleBackColor = true;
			chkShowDelegate.CheckedChanged += chkShowDelegate_CheckedChanged;
			// 
			// StudImage
			// 
			StudImage.Dock = DockStyle.Fill;
			StudImage.Location = new System.Drawing.Point(0, 0);
			StudImage.Margin = new Padding(3, 4, 3, 4);
			StudImage.Name = "StudImage";
			StudImage.Size = new System.Drawing.Size(960, 436);
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
			tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 4;
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new System.Drawing.Size(1467, 1291);
			tableLayoutPanel3.TabIndex = 8;
			// 
			// tabControl2
			// 
			tabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel3.SetColumnSpan(tabControl2, 2);
			tabControl2.Controls.Add(tabPage4);
			tabControl2.Controls.Add(tabPage5);
			tabControl2.Location = new System.Drawing.Point(3, 158);
			tabControl2.Margin = new Padding(3, 4, 3, 4);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabControl2.Size = new System.Drawing.Size(1461, 1129);
			tabControl2.TabIndex = 7;
			// 
			// tabPage4
			// 
			tabPage4.Controls.Add(cmdListVariables);
			tabPage4.Controls.Add(button1);
			tabPage4.Controls.Add(cmdSaveEmail);
			tabPage4.Controls.Add(txtEmailBody);
			tabPage4.Location = new System.Drawing.Point(4, 39);
			tabPage4.Margin = new Padding(3, 4, 3, 4);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new Padding(3, 4, 3, 4);
			tabPage4.Size = new System.Drawing.Size(1453, 1086);
			tabPage4.TabIndex = 0;
			tabPage4.Text = "Template";
			tabPage4.UseVisualStyleBackColor = true;
			// 
			// cmdListVariables
			// 
			cmdListVariables.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			cmdListVariables.Location = new System.Drawing.Point(550, 953);
			cmdListVariables.Margin = new Padding(7, 6, 7, 6);
			cmdListVariables.Name = "cmdListVariables";
			cmdListVariables.Size = new System.Drawing.Size(257, 54);
			cmdListVariables.TabIndex = 10;
			cmdListVariables.Text = "List variables";
			cmdListVariables.UseVisualStyleBackColor = true;
			cmdListVariables.Click += cmdListVariables_Click;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			button1.Location = new System.Drawing.Point(10, 953);
			button1.Margin = new Padding(7, 6, 7, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(257, 54);
			button1.TabIndex = 9;
			button1.Text = "Default";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// cmdSaveEmail
			// 
			cmdSaveEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			cmdSaveEmail.Location = new System.Drawing.Point(279, 953);
			cmdSaveEmail.Margin = new Padding(7, 6, 7, 6);
			cmdSaveEmail.Name = "cmdSaveEmail";
			cmdSaveEmail.Size = new System.Drawing.Size(257, 54);
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
			txtEmailBody.Location = new System.Drawing.Point(9, 16);
			txtEmailBody.Margin = new Padding(12, 14, 12, 14);
			txtEmailBody.MaxLength = 0;
			txtEmailBody.Name = "txtEmailBody";
			txtEmailBody.OriginalText = "";
			txtEmailBody.Size = new System.Drawing.Size(1423, 917);
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
			tabPage5.Location = new System.Drawing.Point(4, 39);
			tabPage5.Margin = new Padding(3, 4, 3, 4);
			tabPage5.Name = "tabPage5";
			tabPage5.Padding = new Padding(3, 4, 3, 4);
			tabPage5.Size = new System.Drawing.Size(1453, 1086);
			tabPage5.TabIndex = 1;
			tabPage5.Text = "Output";
			tabPage5.UseVisualStyleBackColor = true;
			// 
			// txtEmailPreview
			// 
			txtEmailPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtEmailPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEmailPreview.Location = new System.Drawing.Point(10, 14);
			txtEmailPreview.Margin = new Padding(7, 6, 7, 6);
			txtEmailPreview.Multiline = true;
			txtEmailPreview.Name = "txtEmailPreview";
			txtEmailPreview.ScrollBars = ScrollBars.Vertical;
			txtEmailPreview.Size = new System.Drawing.Size(1424, 979);
			txtEmailPreview.TabIndex = 7;
			txtEmailPreview.TabStop = false;
			txtEmailPreview.Text = "Dear {SUB_FirstName}, \r\nThe marking and moderation process for BE1178 has been completed a few days ago. \r\nPlease find your feedback after my signature.\r\nBest regards, \r\nClaudio \r\n\r\n{MarkReport}";
			// 
			// btnSend
			// 
			btnSend.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			btnSend.Location = new System.Drawing.Point(279, 102);
			btnSend.Margin = new Padding(7, 6, 7, 6);
			btnSend.Name = "btnSend";
			btnSend.Size = new System.Drawing.Size(1181, 46);
			btnSend.TabIndex = 0;
			btnSend.Text = "Send";
			btnSend.UseVisualStyleBackColor = true;
			btnSend.Click += send_Click;
			// 
			// chkSendModerationNotice
			// 
			chkSendModerationNotice.AutoSize = true;
			chkSendModerationNotice.Location = new System.Drawing.Point(7, 102);
			chkSendModerationNotice.Margin = new Padding(7, 6, 7, 6);
			chkSendModerationNotice.Name = "chkSendModerationNotice";
			chkSendModerationNotice.Size = new System.Drawing.Size(258, 34);
			chkSendModerationNotice.TabIndex = 5;
			chkSendModerationNotice.Text = "Add Moderation Notice";
			chkSendModerationNotice.UseVisualStyleBackColor = true;
			// 
			// cmbEmailSubject
			// 
			cmbEmailSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbEmailSubject.Location = new System.Drawing.Point(279, 6);
			cmbEmailSubject.Margin = new Padding(7, 6, 7, 6);
			cmbEmailSubject.Name = "cmbEmailSubject";
			cmbEmailSubject.Size = new System.Drawing.Size(1181, 38);
			cmbEmailSubject.TabIndex = 3;
			cmbEmailSubject.SelectedValueChanged += txtEmailSubject_SelectedValueChanged;
			// 
			// label10
			// 
			label10.Anchor = AnchorStyles.Left;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(7, 10);
			label10.Margin = new Padding(7, 0, 7, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(81, 30);
			label10.TabIndex = 2;
			label10.Text = "Subject";
			// 
			// chkEmailDryRun
			// 
			chkEmailDryRun.AutoSize = true;
			chkEmailDryRun.Checked = true;
			chkEmailDryRun.CheckState = CheckState.Checked;
			chkEmailDryRun.Location = new System.Drawing.Point(7, 56);
			chkEmailDryRun.Margin = new Padding(7, 6, 7, 6);
			chkEmailDryRun.Name = "chkEmailDryRun";
			chkEmailDryRun.Size = new System.Drawing.Size(114, 34);
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
			tabPage3.Location = new System.Drawing.Point(4, 39);
			tabPage3.Margin = new Padding(3, 4, 3, 4);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new Padding(3, 4, 3, 4);
			tabPage3.Size = new System.Drawing.Size(2450, 1303);
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
			groupBox1.Location = new System.Drawing.Point(22, 900);
			groupBox1.Margin = new Padding(7, 6, 7, 6);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(7, 6, 7, 6);
			groupBox1.Size = new System.Drawing.Size(226, 216);
			groupBox1.TabIndex = 29;
			groupBox1.TabStop = false;
			groupBox1.Text = "Mark tweak";
			// 
			// ChkExclude0
			// 
			ChkExclude0.AutoSize = true;
			ChkExclude0.Checked = true;
			ChkExclude0.CheckState = CheckState.Checked;
			ChkExclude0.Location = new System.Drawing.Point(17, 156);
			ChkExclude0.Margin = new Padding(7, 6, 7, 6);
			ChkExclude0.Name = "ChkExclude0";
			ChkExclude0.Size = new System.Drawing.Size(136, 34);
			ChkExclude0.TabIndex = 28;
			ChkExclude0.Text = "Exclude 0s";
			ChkExclude0.UseVisualStyleBackColor = true;
			// 
			// NudMarkOffset
			// 
			NudMarkOffset.Location = new System.Drawing.Point(129, 44);
			NudMarkOffset.Margin = new Padding(7, 6, 7, 6);
			NudMarkOffset.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			NudMarkOffset.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
			NudMarkOffset.Name = "NudMarkOffset";
			NudMarkOffset.Size = new System.Drawing.Size(86, 35);
			NudMarkOffset.TabIndex = 24;
			NudMarkOffset.TextAlign = HorizontalAlignment.Center;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(12, 48);
			label9.Margin = new Padding(7, 0, 7, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(70, 30);
			label9.TabIndex = 25;
			label9.Text = "Offset";
			// 
			// ChkRoundupX9
			// 
			ChkRoundupX9.AutoSize = true;
			ChkRoundupX9.Checked = true;
			ChkRoundupX9.CheckState = CheckState.Checked;
			ChkRoundupX9.Location = new System.Drawing.Point(17, 104);
			ChkRoundupX9.Margin = new Padding(7, 6, 7, 6);
			ChkRoundupX9.Name = "ChkRoundupX9";
			ChkRoundupX9.Size = new System.Drawing.Size(149, 34);
			ChkRoundupX9.TabIndex = 27;
			ChkRoundupX9.Text = "Roundup *9";
			ChkRoundupX9.UseVisualStyleBackColor = true;
			// 
			// ChkShowLabels
			// 
			ChkShowLabels.AutoSize = true;
			ChkShowLabels.Location = new System.Drawing.Point(22, 1200);
			ChkShowLabels.Margin = new Padding(7, 6, 7, 6);
			ChkShowLabels.Name = "ChkShowLabels";
			ChkShowLabels.Size = new System.Drawing.Size(148, 34);
			ChkShowLabels.TabIndex = 28;
			ChkShowLabels.Text = "Show labels";
			ChkShowLabels.UseVisualStyleBackColor = true;
			// 
			// CmbGrouping
			// 
			CmbGrouping.DropDownStyle = ComboBoxStyle.DropDownList;
			CmbGrouping.FormattingEnabled = true;
			CmbGrouping.Location = new System.Drawing.Point(22, 838);
			CmbGrouping.Margin = new Padding(7, 6, 7, 6);
			CmbGrouping.Name = "CmbGrouping";
			CmbGrouping.Size = new System.Drawing.Size(222, 38);
			CmbGrouping.TabIndex = 26;
			// 
			// ChkIncludeNoMark
			// 
			ChkIncludeNoMark.AutoSize = true;
			ChkIncludeNoMark.Checked = true;
			ChkIncludeNoMark.CheckState = CheckState.Checked;
			ChkIncludeNoMark.Location = new System.Drawing.Point(22, 1146);
			ChkIncludeNoMark.Margin = new Padding(7, 6, 7, 6);
			ChkIncludeNoMark.Name = "ChkIncludeNoMark";
			ChkIncludeNoMark.Size = new System.Drawing.Size(217, 34);
			ChkIncludeNoMark.TabIndex = 23;
			ChkIncludeNoMark.Text = "Show missing mark";
			ChkIncludeNoMark.UseVisualStyleBackColor = true;
			// 
			// ChkOddRows
			// 
			ChkOddRows.AutoSize = true;
			ChkOddRows.Checked = true;
			ChkOddRows.CheckState = CheckState.Checked;
			ChkOddRows.Location = new System.Drawing.Point(22, 740);
			ChkOddRows.Margin = new Padding(7, 6, 7, 6);
			ChkOddRows.Name = "ChkOddRows";
			ChkOddRows.Size = new System.Drawing.Size(112, 34);
			ChkOddRows.TabIndex = 21;
			ChkOddRows.Text = "Odd Ids";
			ChkOddRows.UseVisualStyleBackColor = true;
			// 
			// ChkEvenRows
			// 
			ChkEvenRows.AutoSize = true;
			ChkEvenRows.Checked = true;
			ChkEvenRows.CheckState = CheckState.Checked;
			ChkEvenRows.Location = new System.Drawing.Point(22, 794);
			ChkEvenRows.Margin = new Padding(7, 6, 7, 6);
			ChkEvenRows.Name = "ChkEvenRows";
			ChkEvenRows.Size = new System.Drawing.Size(116, 34);
			ChkEvenRows.TabIndex = 20;
			ChkEvenRows.Text = "Even Ids";
			ChkEvenRows.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			button4.Location = new System.Drawing.Point(12, 600);
			button4.Margin = new Padding(3, 4, 3, 4);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(238, 130);
			button4.TabIndex = 19;
			button4.Text = "Marks chart";
			button4.UseVisualStyleBackColor = true;
			button4.Click += marksChart_Click;
			// 
			// zedGraphControl1
			// 
			zedGraphControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			zedGraphControl1.Location = new System.Drawing.Point(262, 600);
			zedGraphControl1.Margin = new Padding(9, 10, 9, 10);
			zedGraphControl1.MatchAxesScreenDataRatio = false;
			zedGraphControl1.Name = "zedGraphControl1";
			zedGraphControl1.Size = new System.Drawing.Size(1344, 470);
			zedGraphControl1.TabIndex = 18;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(txtElpCode);
			groupBox3.Controls.Add(txtToolReport);
			groupBox3.Controls.Add(tabControl3);
			groupBox3.Controls.Add(label13);
			groupBox3.Location = new System.Drawing.Point(12, 28);
			groupBox3.Margin = new Padding(3, 4, 3, 4);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(3, 4, 3, 4);
			groupBox3.Size = new System.Drawing.Size(1593, 530);
			groupBox3.TabIndex = 17;
			groupBox3.TabStop = false;
			groupBox3.Text = "Import data";
			// 
			// txtElpCode
			// 
			txtElpCode.Location = new System.Drawing.Point(482, 462);
			txtElpCode.Margin = new Padding(7, 6, 7, 6);
			txtElpCode.Name = "txtElpCode";
			txtElpCode.Size = new System.Drawing.Size(390, 35);
			txtElpCode.TabIndex = 27;
			// 
			// txtToolReport
			// 
			txtToolReport.Location = new System.Drawing.Point(888, 92);
			txtToolReport.Margin = new Padding(7, 6, 7, 6);
			txtToolReport.Multiline = true;
			txtToolReport.Name = "txtToolReport";
			txtToolReport.ScrollBars = ScrollBars.Vertical;
			txtToolReport.Size = new System.Drawing.Size(690, 412);
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
			tabControl3.Location = new System.Drawing.Point(10, 42);
			tabControl3.Margin = new Padding(7, 6, 7, 6);
			tabControl3.Name = "tabControl3";
			tabControl3.SelectedIndex = 0;
			tabControl3.Size = new System.Drawing.Size(866, 408);
			tabControl3.TabIndex = 26;
			// 
			// tabPage6
			// 
			tabPage6.Controls.Add(txtSourceTurnitin);
			tabPage6.Controls.Add(button8);
			tabPage6.Controls.Add(btnCompleteData);
			tabPage6.Controls.Add(button7);
			tabPage6.Location = new System.Drawing.Point(4, 39);
			tabPage6.Margin = new Padding(7, 6, 7, 6);
			tabPage6.Name = "tabPage6";
			tabPage6.Padding = new Padding(7, 6, 7, 6);
			tabPage6.Size = new System.Drawing.Size(858, 365);
			tabPage6.TabIndex = 0;
			tabPage6.Text = "Gradebook";
			tabPage6.UseVisualStyleBackColor = true;
			// 
			// txtSourceTurnitin
			// 
			txtSourceTurnitin.Location = new System.Drawing.Point(46, 14);
			txtSourceTurnitin.Margin = new Padding(7, 6, 7, 6);
			txtSourceTurnitin.Multiline = true;
			txtSourceTurnitin.Name = "txtSourceTurnitin";
			txtSourceTurnitin.Size = new System.Drawing.Size(669, 124);
			txtSourceTurnitin.TabIndex = 24;
			// 
			// button8
			// 
			button8.Location = new System.Drawing.Point(732, 92);
			button8.Margin = new Padding(7, 6, 7, 6);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(50, 50);
			button8.TabIndex = 25;
			button8.Text = "...";
			button8.UseVisualStyleBackColor = true;
			button8.Click += button8_Click;
			// 
			// btnCompleteData
			// 
			btnCompleteData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			btnCompleteData.Location = new System.Drawing.Point(46, 282);
			btnCompleteData.Margin = new Padding(3, 4, 3, 4);
			btnCompleteData.Name = "btnCompleteData";
			btnCompleteData.Size = new System.Drawing.Size(730, 60);
			btnCompleteData.TabIndex = 18;
			btnCompleteData.Text = "Update database from elp Learning Analytics";
			btnCompleteData.UseVisualStyleBackColor = true;
			btnCompleteData.Click += BtnCompleteData_Click;
			// 
			// button7
			// 
			button7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			button7.Location = new System.Drawing.Point(46, 152);
			button7.Margin = new Padding(3, 4, 3, 4);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(730, 122);
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
			tabPage11.Location = new System.Drawing.Point(4, 39);
			tabPage11.Margin = new Padding(5, 6, 5, 6);
			tabPage11.Name = "tabPage11";
			tabPage11.Padding = new Padding(5, 6, 5, 6);
			tabPage11.Size = new System.Drawing.Size(858, 365);
			tabPage11.TabIndex = 5;
			tabPage11.Text = "Students repo";
			tabPage11.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(12, 141);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(289, 30);
			label15.TabIndex = 31;
			label15.Text = "Optional student filters per ID";
			// 
			// txtImprotFromRepoFilter
			// 
			txtImprotFromRepoFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txtImprotFromRepoFilter.Location = new System.Drawing.Point(12, 177);
			txtImprotFromRepoFilter.Margin = new Padding(7, 6, 7, 6);
			txtImprotFromRepoFilter.Multiline = true;
			txtImprotFromRepoFilter.Name = "txtImprotFromRepoFilter";
			txtImprotFromRepoFilter.ScrollBars = ScrollBars.Both;
			txtImprotFromRepoFilter.Size = new System.Drawing.Size(834, 166);
			txtImprotFromRepoFilter.TabIndex = 30;
			txtImprotFromRepoFilter.TabStop = false;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(10, 18);
			label14.Margin = new Padding(7, 0, 7, 0);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(327, 30);
			label14.TabIndex = 29;
			label14.Text = "elp code (saved in student record)";
			// 
			// button14
			// 
			button14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			button14.Location = new System.Drawing.Point(10, 68);
			button14.Margin = new Padding(3, 4, 3, 4);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(557, 61);
			button14.TabIndex = 28;
			button14.Text = "Import students";
			button14.UseVisualStyleBackColor = true;
			button14.Click += button14_Click;
			// 
			// cmbImportCollection
			// 
			cmbImportCollection.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbImportCollection.FormattingEnabled = true;
			cmbImportCollection.Location = new System.Drawing.Point(343, 12);
			cmbImportCollection.Margin = new Padding(7, 6, 7, 6);
			cmbImportCollection.Name = "cmbImportCollection";
			cmbImportCollection.Size = new System.Drawing.Size(222, 38);
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
			tabPage7.Location = new System.Drawing.Point(4, 39);
			tabPage7.Margin = new Padding(7, 6, 7, 6);
			tabPage7.Name = "tabPage7";
			tabPage7.Padding = new Padding(7, 6, 7, 6);
			tabPage7.Size = new System.Drawing.Size(858, 365);
			tabPage7.TabIndex = 1;
			tabPage7.Text = "AMM Sql";
			tabPage7.UseVisualStyleBackColor = true;
			// 
			// txtSourceDataFile
			// 
			txtSourceDataFile.Location = new System.Drawing.Point(201, 40);
			txtSourceDataFile.Margin = new Padding(7, 6, 7, 6);
			txtSourceDataFile.Multiline = true;
			txtSourceDataFile.Name = "txtSourceDataFile";
			txtSourceDataFile.Size = new System.Drawing.Size(635, 88);
			txtSourceDataFile.TabIndex = 12;
			// 
			// chkImportSubmissions
			// 
			chkImportSubmissions.AutoSize = true;
			chkImportSubmissions.Location = new System.Drawing.Point(202, 188);
			chkImportSubmissions.Margin = new Padding(3, 4, 3, 4);
			chkImportSubmissions.Name = "chkImportSubmissions";
			chkImportSubmissions.Size = new System.Drawing.Size(219, 34);
			chkImportSubmissions.TabIndex = 23;
			chkImportSubmissions.Text = "Import submissions";
			chkImportSubmissions.UseVisualStyleBackColor = true;
			// 
			// lblSourceData
			// 
			lblSourceData.AutoSize = true;
			lblSourceData.Location = new System.Drawing.Point(22, 44);
			lblSourceData.Margin = new Padding(7, 0, 7, 0);
			lblSourceData.Name = "lblSourceData";
			lblSourceData.Size = new System.Drawing.Size(134, 30);
			lblSourceData.TabIndex = 14;
			lblSourceData.Text = "sqlite source:";
			// 
			// chkImportComponents
			// 
			chkImportComponents.AutoSize = true;
			chkImportComponents.Location = new System.Drawing.Point(489, 142);
			chkImportComponents.Margin = new Padding(3, 4, 3, 4);
			chkImportComponents.Name = "chkImportComponents";
			chkImportComponents.Size = new System.Drawing.Size(274, 34);
			chkImportComponents.TabIndex = 17;
			chkImportComponents.Text = "Import mark components";
			chkImportComponents.UseVisualStyleBackColor = true;
			// 
			// cmdSourceDataFile
			// 
			cmdSourceDataFile.Location = new System.Drawing.Point(789, 144);
			cmdSourceDataFile.Margin = new Padding(7, 6, 7, 6);
			cmdSourceDataFile.Name = "cmdSourceDataFile";
			cmdSourceDataFile.Size = new System.Drawing.Size(50, 50);
			cmdSourceDataFile.TabIndex = 13;
			cmdSourceDataFile.Text = "...";
			cmdSourceDataFile.UseVisualStyleBackColor = true;
			cmdSourceDataFile.Click += cmdSourceDataFile_Click;
			// 
			// cmdGetData
			// 
			cmdGetData.Location = new System.Drawing.Point(202, 234);
			cmdGetData.Margin = new Padding(3, 4, 3, 4);
			cmdGetData.Name = "cmdGetData";
			cmdGetData.Size = new System.Drawing.Size(564, 60);
			cmdGetData.TabIndex = 15;
			cmdGetData.Text = "Get Data";
			cmdGetData.UseVisualStyleBackColor = true;
			cmdGetData.Click += cmdGetData_Click;
			// 
			// chkCommentLib
			// 
			chkCommentLib.AutoSize = true;
			chkCommentLib.Location = new System.Drawing.Point(201, 142);
			chkCommentLib.Margin = new Padding(3, 4, 3, 4);
			chkCommentLib.Name = "chkCommentLib";
			chkCommentLib.Size = new System.Drawing.Size(266, 34);
			chkCommentLib.TabIndex = 16;
			chkCommentLib.Text = "Import Comment Library";
			chkCommentLib.UseVisualStyleBackColor = true;
			// 
			// tabPage8
			// 
			tabPage8.Controls.Add(button10);
			tabPage8.Controls.Add(button9);
			tabPage8.Location = new System.Drawing.Point(4, 39);
			tabPage8.Margin = new Padding(7, 6, 7, 6);
			tabPage8.Name = "tabPage8";
			tabPage8.Size = new System.Drawing.Size(858, 365);
			tabPage8.TabIndex = 2;
			tabPage8.Text = "DocumentArchive";
			tabPage8.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			button10.Location = new System.Drawing.Point(36, 96);
			button10.Margin = new Padding(7, 6, 7, 6);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(723, 54);
			button10.TabIndex = 1;
			button10.Text = "Get manifest information";
			button10.UseVisualStyleBackColor = true;
			button10.Click += Button10_Click;
			// 
			// button9
			// 
			button9.Location = new System.Drawing.Point(36, 30);
			button9.Margin = new Padding(7, 6, 7, 6);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(723, 54);
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
			tabPage9.Location = new System.Drawing.Point(4, 39);
			tabPage9.Margin = new Padding(7, 6, 7, 6);
			tabPage9.Name = "tabPage9";
			tabPage9.Padding = new Padding(7, 6, 7, 6);
			tabPage9.Size = new System.Drawing.Size(858, 365);
			tabPage9.TabIndex = 3;
			tabPage9.Text = "Excel";
			tabPage9.UseVisualStyleBackColor = true;
			// 
			// TxtExcelComponentSource
			// 
			TxtExcelComponentSource.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtExcelComponentSource.Location = new System.Drawing.Point(12, 216);
			TxtExcelComponentSource.Margin = new Padding(7, 6, 7, 6);
			TxtExcelComponentSource.Multiline = true;
			TxtExcelComponentSource.Name = "TxtExcelComponentSource";
			TxtExcelComponentSource.Size = new System.Drawing.Size(822, 46);
			TxtExcelComponentSource.TabIndex = 10;
			TxtExcelComponentSource.TabStop = false;
			// 
			// BtnImportExcel
			// 
			BtnImportExcel.Location = new System.Drawing.Point(12, 124);
			BtnImportExcel.Margin = new Padding(7, 6, 7, 6);
			BtnImportExcel.Name = "BtnImportExcel";
			BtnImportExcel.Size = new System.Drawing.Size(381, 96);
			BtnImportExcel.TabIndex = 1;
			BtnImportExcel.Text = "Import Excel Components";
			BtnImportExcel.UseVisualStyleBackColor = true;
			BtnImportExcel.Click += BtnImportExcel_Click;
			// 
			// BtnExportExcel
			// 
			BtnExportExcel.Location = new System.Drawing.Point(12, 14);
			BtnExportExcel.Margin = new Padding(7, 6, 7, 6);
			BtnExportExcel.Name = "BtnExportExcel";
			BtnExportExcel.Size = new System.Drawing.Size(381, 96);
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
			tabPage10.Location = new System.Drawing.Point(4, 39);
			tabPage10.Margin = new Padding(7, 6, 7, 6);
			tabPage10.Name = "tabPage10";
			tabPage10.Padding = new Padding(7, 6, 7, 6);
			tabPage10.Size = new System.Drawing.Size(858, 365);
			tabPage10.TabIndex = 4;
			tabPage10.Text = "PlagiarismReport";
			tabPage10.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(24, 200);
			label12.Margin = new Padding(7, 0, 7, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(61, 30);
			label12.TabIndex = 14;
			label12.Text = "Scale";
			// 
			// TxtScaleFactor
			// 
			TxtScaleFactor.Location = new System.Drawing.Point(105, 194);
			TxtScaleFactor.Margin = new Padding(7, 6, 7, 6);
			TxtScaleFactor.Name = "TxtScaleFactor";
			TxtScaleFactor.Size = new System.Drawing.Size(259, 35);
			TxtScaleFactor.TabIndex = 13;
			TxtScaleFactor.Text = "1.0";
			TxtScaleFactor.TextAlign = HorizontalAlignment.Right;
			// 
			// TxtMergeReportFolder
			// 
			TxtMergeReportFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtMergeReportFolder.Location = new System.Drawing.Point(24, 146);
			TxtMergeReportFolder.Margin = new Padding(7, 6, 7, 6);
			TxtMergeReportFolder.Multiline = true;
			TxtMergeReportFolder.Name = "TxtMergeReportFolder";
			TxtMergeReportFolder.Size = new System.Drawing.Size(787, 110);
			TxtMergeReportFolder.TabIndex = 12;
			TxtMergeReportFolder.TabStop = false;
			// 
			// BtnMergeReport
			// 
			BtnMergeReport.Location = new System.Drawing.Point(31, 36);
			BtnMergeReport.Margin = new Padding(7, 6, 7, 6);
			BtnMergeReport.Name = "BtnMergeReport";
			BtnMergeReport.Size = new System.Drawing.Size(338, 96);
			BtnMergeReport.TabIndex = 11;
			BtnMergeReport.Text = "Merge reports";
			BtnMergeReport.UseVisualStyleBackColor = true;
			BtnMergeReport.Click += BtnMergeReport_Click;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(149, 470);
			label13.Margin = new Padding(7, 0, 7, 0);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(327, 30);
			label13.TabIndex = 26;
			label13.Text = "elp code (saved in student record)";
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 5;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
			tableLayoutPanel4.Controls.Add(cmdReload, 3, 0);
			tableLayoutPanel4.Controls.Add(label5, 0, 0);
			tableLayoutPanel4.Controls.Add(cmdSelectFile, 2, 0);
			tableLayoutPanel4.Controls.Add(txtExcelFileName, 1, 0);
			tableLayoutPanel4.Controls.Add(BtnOpenFolder, 4, 0);
			tableLayoutPanel4.Dock = DockStyle.Top;
			tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.Size = new System.Drawing.Size(2458, 74);
			tableLayoutPanel4.TabIndex = 13;
			// 
			// BtnOpenFolder
			// 
			BtnOpenFolder.Image = UnnItBooster.Properties.Resources.folder;
			BtnOpenFolder.Location = new System.Drawing.Point(2405, 6);
			BtnOpenFolder.Margin = new Padding(7, 6, 7, 6);
			BtnOpenFolder.Name = "BtnOpenFolder";
			BtnOpenFolder.Size = new System.Drawing.Size(46, 54);
			BtnOpenFolder.TabIndex = 13;
			BtnOpenFolder.UseVisualStyleBackColor = true;
			BtnOpenFolder.Click += BtnOpenFolder_Click;
			// 
			// FrmMarkingMachine
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(2458, 1420);
			Controls.Add(tabControl1);
			Controls.Add(tableLayoutPanel4);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(7, 6, 7, 6);
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
	}
}

