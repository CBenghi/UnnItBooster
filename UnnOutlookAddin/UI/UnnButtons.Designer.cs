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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.ClassificationGroup = this.Factory.CreateRibbonGroup();
            this.btnClassify = this.Factory.CreateRibbonButton();
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
            this.ClassificationGroup.Label = "Classification";
            this.ClassificationGroup.Name = "ClassificationGroup";
            // 
            // btnClassify
            // 
            this.btnClassify.Label = "Classify";
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnClassify_Click);
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
    }

    //partial class ThisRibbonCollection
    //{
    //    internal UnnButtons UnnButtons
    //    {
    //        get { return this.GetRibbon<UnnButtons>(); }
    //    }
    //}
}
