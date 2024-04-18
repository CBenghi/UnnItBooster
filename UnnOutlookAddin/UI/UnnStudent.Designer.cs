namespace UnnOutlookAddin.UI
{
    partial class UnnStudent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CmbFolder = new System.Windows.Forms.ComboBox();
			this.CmdFolder = new System.Windows.Forms.Button();
			this.ButtonToggleWrap = new System.Windows.Forms.Button();
			this.txtInformation = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.cmbAction = new System.Windows.Forms.ComboBox();
			this.ButtonThread = new System.Windows.Forms.Button();
			this.StudImage = new System.Windows.Forms.PictureBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.BtnSolveStudentName = new System.Windows.Forms.Button();
			this.txtSystemInfo = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(267, 390);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(259, 364);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Information";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CmbFolder);
			this.groupBox1.Controls.Add(this.CmdFolder);
			this.groupBox1.Controls.Add(this.ButtonToggleWrap);
			this.groupBox1.Controls.Add(this.txtInformation);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(253, 358);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General";
			// 
			// CmbFolder
			// 
			this.CmbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CmbFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbFolder.FormattingEnabled = true;
			this.CmbFolder.Location = new System.Drawing.Point(37, 17);
			this.CmbFolder.Name = "CmbFolder";
			this.CmbFolder.Size = new System.Drawing.Size(157, 21);
			this.CmbFolder.TabIndex = 7;
			// 
			// CmdFolder
			// 
			this.CmdFolder.Image = global::UnnOutlookAddin.Properties.Resources.folder;
			this.CmdFolder.Location = new System.Drawing.Point(6, 17);
			this.CmdFolder.Name = "CmdFolder";
			this.CmdFolder.Size = new System.Drawing.Size(25, 23);
			this.CmdFolder.TabIndex = 6;
			this.CmdFolder.UseVisualStyleBackColor = true;
			this.CmdFolder.Click += new System.EventHandler(this.CmdFolder_Click);
			// 
			// ButtonToggleWrap
			// 
			this.ButtonToggleWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonToggleWrap.Location = new System.Drawing.Point(200, 17);
			this.ButtonToggleWrap.Name = "ButtonToggleWrap";
			this.ButtonToggleWrap.Size = new System.Drawing.Size(47, 23);
			this.ButtonToggleWrap.TabIndex = 3;
			this.ButtonToggleWrap.Text = "Wrap";
			this.ButtonToggleWrap.UseVisualStyleBackColor = true;
			this.ButtonToggleWrap.Click += new System.EventHandler(this.ButtonToggleWrap_Click);
			// 
			// txtInformation
			// 
			this.txtInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInformation.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInformation.Location = new System.Drawing.Point(3, 46);
			this.txtInformation.Multiline = true;
			this.txtInformation.Name = "txtInformation";
			this.txtInformation.Size = new System.Drawing.Size(244, 306);
			this.txtInformation.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.button1);
			this.tabPage3.Controls.Add(this.cmbAction);
			this.tabPage3.Controls.Add(this.ButtonThread);
			this.tabPage3.Controls.Add(this.StudImage);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(259, 364);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Picture";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(200, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(53, 23);
			this.button1.TabIndex = 23;
			this.button1.Text = "Go";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cmbAction
			// 
			this.cmbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAction.FormattingEnabled = true;
			this.cmbAction.Location = new System.Drawing.Point(84, 5);
			this.cmbAction.Name = "cmbAction";
			this.cmbAction.Size = new System.Drawing.Size(110, 21);
			this.cmbAction.TabIndex = 22;
			// 
			// ButtonThread
			// 
			this.ButtonThread.Location = new System.Drawing.Point(3, 3);
			this.ButtonThread.Name = "ButtonThread";
			this.ButtonThread.Size = new System.Drawing.Size(75, 23);
			this.ButtonThread.TabIndex = 21;
			this.ButtonThread.Text = "Thread";
			this.ButtonThread.UseVisualStyleBackColor = true;
			this.ButtonThread.Click += new System.EventHandler(this.ButtonThread_Click);
			// 
			// StudImage
			// 
			this.StudImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StudImage.BackColor = System.Drawing.Color.Gray;
			this.StudImage.Location = new System.Drawing.Point(0, 33);
			this.StudImage.Margin = new System.Windows.Forms.Padding(2);
			this.StudImage.Name = "StudImage";
			this.StudImage.Size = new System.Drawing.Size(253, 325);
			this.StudImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.StudImage.TabIndex = 20;
			this.StudImage.TabStop = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.BtnSolveStudentName);
			this.tabPage2.Controls.Add(this.txtSystemInfo);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(259, 364);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "System";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// BtnSolveStudentName
			// 
			this.BtnSolveStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSolveStudentName.Location = new System.Drawing.Point(6, 11);
			this.BtnSolveStudentName.Name = "BtnSolveStudentName";
			this.BtnSolveStudentName.Size = new System.Drawing.Size(247, 23);
			this.BtnSolveStudentName.TabIndex = 1;
			this.BtnSolveStudentName.Text = "Resolve first names";
			this.BtnSolveStudentName.UseVisualStyleBackColor = true;
			this.BtnSolveStudentName.Click += new System.EventHandler(this.BtnSolveStudentName_Click);
			// 
			// txtSystemInfo
			// 
			this.txtSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSystemInfo.Location = new System.Drawing.Point(6, 40);
			this.txtSystemInfo.Multiline = true;
			this.txtSystemInfo.Name = "txtSystemInfo";
			this.txtSystemInfo.Size = new System.Drawing.Size(247, 318);
			this.txtSystemInfo.TabIndex = 0;
			// 
			// UnnStudent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl1);
			this.Name = "UnnStudent";
			this.Size = new System.Drawing.Size(273, 396);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtSystemInfo;
		private System.Windows.Forms.TextBox txtInformation;
		private System.Windows.Forms.PictureBox StudImage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button ButtonToggleWrap;
		private System.Windows.Forms.ComboBox CmbFolder;
		private System.Windows.Forms.Button CmdFolder;
		private System.Windows.Forms.Button BtnSolveStudentName;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cmbAction;
		private System.Windows.Forms.Button ButtonThread;
	}
}
