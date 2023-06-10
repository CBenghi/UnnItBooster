namespace StudentsFetcher.StudentMarking
{
    partial class ucComponentMark
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
			this.components = new System.ComponentModel.Container();
			this.tbComponentMark = new System.Windows.Forms.TrackBar();
			this.lblDesc = new System.Windows.Forms.Label();
			this.lblMark = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.tbComponentMark)).BeginInit();
			this.SuspendLayout();
			// 
			// tbComponentMark
			// 
			this.tbComponentMark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbComponentMark.AutoSize = false;
			this.tbComponentMark.Location = new System.Drawing.Point(59, 14);
			this.tbComponentMark.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tbComponentMark.Maximum = 80;
			this.tbComponentMark.Minimum = 50;
			this.tbComponentMark.Name = "tbComponentMark";
			this.tbComponentMark.Size = new System.Drawing.Size(276, 37);
			this.tbComponentMark.TabIndex = 0;
			this.tbComponentMark.TabStop = false;
			this.tbComponentMark.TickFrequency = 5;
			this.tbComponentMark.Value = 50;
			this.tbComponentMark.Scroll += new System.EventHandler(this.tbComponentMark_Scroll);
			this.tbComponentMark.ValueChanged += new System.EventHandler(this.tbComponentMark_ValueChanged);
			// 
			// lblDesc
			// 
			this.lblDesc.AutoSize = true;
			this.lblDesc.Location = new System.Drawing.Point(2, 0);
			this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDesc.Name = "lblDesc";
			this.lblDesc.Size = new System.Drawing.Size(42, 13);
			this.lblDesc.TabIndex = 1;
			this.lblDesc.Text = "lblDesc";
			this.lblDesc.Click += new System.EventHandler(this.lblDesc_Click);
			// 
			// lblMark
			// 
			this.lblMark.Location = new System.Drawing.Point(4, 16);
			this.lblMark.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblMark.Name = "lblMark";
			this.lblMark.Size = new System.Drawing.Size(46, 14);
			this.lblMark.TabIndex = 2;
			this.lblMark.Text = "lblMark";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 32);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(52, 17);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.TabStop = false;
			this.checkBox1.Text = "unset";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// ucComponentMark
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.lblMark);
			this.Controls.Add(this.lblDesc);
			this.Controls.Add(this.tbComponentMark);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "ucComponentMark";
			this.Size = new System.Drawing.Size(337, 54);
			((System.ComponentModel.ISupportInitialize)(this.tbComponentMark)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbComponentMark;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblMark;
        private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
