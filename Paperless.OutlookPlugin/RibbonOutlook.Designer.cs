namespace Paperless.OutlookPlugin
{
    partial class RibbonOutlook : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonOutlook()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            RibbonType = "Microsoft.Outlook.Explorer";
  
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
            this.tabPaperless = this.Factory.CreateRibbonTab();
            this.groupDocumentos = this.Factory.CreateRibbonGroup();
            this.buttonRecibir = this.Factory.CreateRibbonButton();
            this.tabPaperless.SuspendLayout();
            this.groupDocumentos.SuspendLayout();
            // 
            // tabPaperless
            // 
            this.tabPaperless.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabPaperless.Groups.Add(this.groupDocumentos);
            this.tabPaperless.Label = "Paperless";
            this.tabPaperless.Name = "tabPaperless";
            // 
            // groupDocumentos
            // 
            this.groupDocumentos.Items.Add(this.buttonRecibir);
            this.groupDocumentos.Label = "Documentos";
            this.groupDocumentos.Name = "groupDocumentos";
            // 
            // buttonRecibir
            // 
            this.buttonRecibir.Label = "Recibir Documentos";
            this.buttonRecibir.Name = "buttonRecibir";
            this.buttonRecibir.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonRecibir_Click);
            // 
            // RibbonOutlook
            // 
            this.Name = "RibbonOutlook";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tabPaperless);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonOutlook_Load);
            this.tabPaperless.ResumeLayout(false);
            this.tabPaperless.PerformLayout();
            this.groupDocumentos.ResumeLayout(false);
            this.groupDocumentos.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabPaperless;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupDocumentos;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonRecibir;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonOutlook RibbonOutlook
        {
            get { return this.GetRibbon<RibbonOutlook>(); }
        }
    }
}
