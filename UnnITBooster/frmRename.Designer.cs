namespace StudentsFetcher
{
    partial class frmRename
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
			this.button1 = new System.Windows.Forms.Button();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(368, 123);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(60, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Rename";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtFolder
			// 
			this.txtFolder.Location = new System.Drawing.Point(12, 97);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(416, 20);
			this.txtFolder.TabIndex = 1;
			this.txtFolder.Text = "C:\\Users\\sgmk2\\Dropbox\\A&H\\A&H Shared\\_STAMPARE\\da fare";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(406, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Renames files in folder to progressive ints, avoiding conflicts and retaining ext" +
    "ensions";
			// 
			// frmRename
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 158);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtFolder);
			this.Controls.Add(this.button1);
			this.Name = "frmRename";
			this.Text = "Bulk file renamer";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.Label label1;
	}
}