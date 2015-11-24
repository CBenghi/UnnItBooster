namespace StudentsFetcher
{
    partial class frmMatchLists
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
            this.txtMain = new StudentsFetcher.SelectAllTextbox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMatched = new StudentsFetcher.SelectAllTextbox();
            this.txtToMatch = new StudentsFetcher.SelectAllTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdGo = new System.Windows.Forms.Button();
            this.cmdSwap = new System.Windows.Forms.Button();
            this.cmdCopyClip = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMain.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMain.Location = new System.Drawing.Point(3, 16);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(208, 422);
            this.txtMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMatched, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtToMatch, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMain, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdGo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmdSwap, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdCopyClip, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(892, 478);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtMatched
            // 
            this.txtMatched.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatched.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatched.Location = new System.Drawing.Point(467, 16);
            this.txtMatched.Multiline = true;
            this.txtMatched.Name = "txtMatched";
            this.txtMatched.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMatched.Size = new System.Drawing.Size(422, 422);
            this.txtMatched.TabIndex = 8;
            // 
            // txtToMatch
            // 
            this.txtToMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToMatch.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMatch.Location = new System.Drawing.Point(253, 16);
            this.txtToMatch.Multiline = true;
            this.txtToMatch.Name = "txtToMatch";
            this.txtToMatch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtToMatch.Size = new System.Drawing.Size(208, 422);
            this.txtToMatch.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Main";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ToMatch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "matched";
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(253, 444);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(112, 31);
            this.cmdGo.TabIndex = 6;
            this.cmdGo.Text = "Find matches";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.Go_Click);
            // 
            // cmdSwap
            // 
            this.cmdSwap.Location = new System.Drawing.Point(217, 16);
            this.cmdSwap.Name = "cmdSwap";
            this.cmdSwap.Size = new System.Drawing.Size(30, 23);
            this.cmdSwap.TabIndex = 9;
            this.cmdSwap.Text = "<->";
            this.cmdSwap.UseVisualStyleBackColor = true;
            this.cmdSwap.Click += new System.EventHandler(this.cmdSwap_Click);
            // 
            // cmdCopyClip
            // 
            this.cmdCopyClip.Location = new System.Drawing.Point(467, 444);
            this.cmdCopyClip.Name = "cmdCopyClip";
            this.cmdCopyClip.Size = new System.Drawing.Size(146, 31);
            this.cmdCopyClip.TabIndex = 10;
            this.cmdCopyClip.Text = "Copy to clipboard";
            this.cmdCopyClip.UseVisualStyleBackColor = true;
            this.cmdCopyClip.Click += new System.EventHandler(this.cmdCopyClip_Click);
            // 
            // frmMatchLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 478);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMatchLists";
            this.Text = "frmMatchLists";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SelectAllTextbox txtMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SelectAllTextbox txtMatched;
        private SelectAllTextbox txtToMatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.Button cmdSwap;
        private System.Windows.Forms.Button cmdCopyClip;
    }
}