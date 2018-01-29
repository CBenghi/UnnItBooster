namespace StudentsFetcher
{
    partial class frmTurnitIn
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
            this.cmdFetch = new System.Windows.Forms.Button();
            this.txtTunrintinUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExcelFileName = new System.Windows.Forms.TextBox();
            this.cmdSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmdMakeDatabase = new System.Windows.Forms.Button();
            this.cmdGetFiles = new System.Windows.Forms.Button();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdFetch
            // 
            this.cmdFetch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFetch.Location = new System.Drawing.Point(673, 13);
            this.cmdFetch.Name = "cmdFetch";
            this.cmdFetch.Size = new System.Drawing.Size(187, 23);
            this.cmdFetch.TabIndex = 0;
            this.cmdFetch.Text = "1. Fetch";
            this.cmdFetch.UseVisualStyleBackColor = true;
            this.cmdFetch.Click += new System.EventHandler(this.cmdFetch_Click);
            // 
            // txtTunrintinUrl
            // 
            this.txtTunrintinUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTunrintinUrl.Location = new System.Drawing.Point(123, 45);
            this.txtTunrintinUrl.Multiline = true;
            this.txtTunrintinUrl.Name = "txtTunrintinUrl";
            this.txtTunrintinUrl.Size = new System.Drawing.Size(738, 92);
            this.txtTunrintinUrl.TabIndex = 1;
            this.txtTunrintinUrl.TextChanged += new System.EventHandler(this.txtTunrintinUrl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Turnitin Sample URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Session Id";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(123, 142);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(545, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Excel file report";
            // 
            // txtExcelFileName
            // 
            this.txtExcelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcelFileName.Location = new System.Drawing.Point(123, 12);
            this.txtExcelFileName.Multiline = true;
            this.txtExcelFileName.Name = "txtExcelFileName";
            this.txtExcelFileName.Size = new System.Drawing.Size(495, 22);
            this.txtExcelFileName.TabIndex = 5;
            // 
            // cmdSelectFile
            // 
            this.cmdSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectFile.Location = new System.Drawing.Point(623, 13);
            this.cmdSelectFile.Name = "cmdSelectFile";
            this.cmdSelectFile.Size = new System.Drawing.Size(44, 22);
            this.cmdSelectFile.TabIndex = 7;
            this.cmdSelectFile.Text = "...";
            this.cmdSelectFile.UseVisualStyleBackColor = true;
            this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmdMakeDatabase
            // 
            this.cmdMakeDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMakeDatabase.Enabled = false;
            this.cmdMakeDatabase.Location = new System.Drawing.Point(673, 509);
            this.cmdMakeDatabase.Name = "cmdMakeDatabase";
            this.cmdMakeDatabase.Size = new System.Drawing.Size(187, 23);
            this.cmdMakeDatabase.TabIndex = 15;
            this.cmdMakeDatabase.Text = "3. Make database";
            this.cmdMakeDatabase.UseVisualStyleBackColor = true;
            this.cmdMakeDatabase.Click += new System.EventHandler(this.makeDatabase_Click);
            // 
            // cmdGetFiles
            // 
            this.cmdGetFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetFiles.Enabled = false;
            this.cmdGetFiles.Location = new System.Drawing.Point(673, 142);
            this.cmdGetFiles.Name = "cmdGetFiles";
            this.cmdGetFiles.Size = new System.Drawing.Size(187, 23);
            this.cmdGetFiles.TabIndex = 17;
            this.cmdGetFiles.Text = "2. Get available files";
            this.cmdGetFiles.UseVisualStyleBackColor = true;
            this.cmdGetFiles.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(123, 171);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(737, 323);
            this.txtReport.TabIndex = 18;
            // 
            // frmTurnitIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 543);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.cmdGetFiles);
            this.Controls.Add(this.cmdMakeDatabase);
            this.Controls.Add(this.cmdSelectFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExcelFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTunrintinUrl);
            this.Controls.Add(this.cmdFetch);
            this.Name = "frmTurnitIn";
            this.Text = "frmTurnitIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdFetch;
        private System.Windows.Forms.TextBox txtTunrintinUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExcelFileName;
        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cmdMakeDatabase;
        private System.Windows.Forms.Button cmdGetFiles;
        private System.Windows.Forms.TextBox txtReport;
    }
}