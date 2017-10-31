namespace UnnOutlookAddin.UI
{
    partial class UnnButtons : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public UnnButtons()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnnButtons));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.ClassificationGroup = this.Factory.CreateRibbonGroup();
            this.btnClassify = this.Factory.CreateRibbonButton();
            this.CopyId = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.ClassificationGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.ClassificationGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // ClassificationGroup
            // 
            this.ClassificationGroup.Items.Add(this.btnClassify);
            this.ClassificationGroup.Items.Add(this.CopyId);
            this.ClassificationGroup.Items.Add(this.button1);
            this.ClassificationGroup.Label = "Classification";
            this.ClassificationGroup.Name = "ClassificationGroup";
            // 
            // btnClassify
            // 
            this.btnClassify.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnClassify.Image = ((System.Drawing.Image)(resources.GetObject("btnClassify.Image")));
            this.btnClassify.Label = "Classify";
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.ShowImage = true;
            this.btnClassify.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnClassify_Click);
            // 
            // CopyId
            // 
            this.CopyId.Label = "Copy User ID";
            this.CopyId.Name = "CopyId";
            this.CopyId.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CopyId_Click);
            // 
            // button1
            // 
            this.button1.Label = "Copy User Number";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // UnnButtons
            // 
            this.Name = "UnnButtons";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.UnnButtons_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.ClassificationGroup.ResumeLayout(false);
            this.ClassificationGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ClassificationGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnClassify;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton CopyId;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    //partial class ThisRibbonCollection
    //{
    //    internal UnnButtons UnnButtons
    //    {
    //        get { return this.GetRibbon<UnnButtons>(); }
    //    }
    //}
}
