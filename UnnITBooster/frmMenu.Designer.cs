namespace StudentsFetcher
{
    partial class frmMenu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
			flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			flowLayoutPanel1.Location = new System.Drawing.Point(13, 13);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new System.Drawing.Size(273, 476);
			flowLayoutPanel1.TabIndex = 1;
			// 
			// frmMenu
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			AutoSize = true;
			ClientSize = new System.Drawing.Size(298, 501);
			Controls.Add(flowLayoutPanel1);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "frmMenu";
			Text = "Application  Menu";
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        // private System.Windows.Forms.Button button2;
    }
}