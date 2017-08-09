namespace Ps.Clinic.ViewPopup
{
    partial class frmViewImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewImage));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pnImageView = new DevExpress.XtraEditors.PanelControl();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtEdit = new System.Windows.Forms.ToolStripButton();
            this.toolbtSave = new System.Windows.Forms.ToolStripButton();
            this.toolbtDelete = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnImageView)).BeginInit();
            this.pnImageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 585);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(692, 31);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowItemCaptionsInPageHeader = true;
            this.ribbon.ShowItemCaptionsInQAT = true;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(692, 27);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // pnImageView
            // 
            this.pnImageView.Controls.Add(this.picPreview);
            this.pnImageView.Controls.Add(this.panelControl1);
            this.pnImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnImageView.Location = new System.Drawing.Point(0, 27);
            this.pnImageView.Name = "pnImageView";
            this.pnImageView.Size = new System.Drawing.Size(692, 558);
            this.pnImageView.TabIndex = 179;
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(2, 31);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(688, 525);
            this.picPreview.TabIndex = 2;
            this.picPreview.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.toolStrip1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(688, 29);
            this.panelControl1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtEdit,
            this.toolbtSave,
            this.toolbtDelete,
            this.btnExport});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(688, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtEdit
            // 
            this.toolbtEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolbtEdit.Image")));
            this.toolbtEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtEdit.Name = "toolbtEdit";
            this.toolbtEdit.Size = new System.Drawing.Size(23, 22);
            this.toolbtEdit.Text = "Thay đổi ảnh";
            this.toolbtEdit.Click += new System.EventHandler(this.toolbtEdit_Click);
            // 
            // toolbtSave
            // 
            this.toolbtSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtSave.Image = ((System.Drawing.Image)(resources.GetObject("toolbtSave.Image")));
            this.toolbtSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtSave.Name = "toolbtSave";
            this.toolbtSave.Size = new System.Drawing.Size(23, 22);
            this.toolbtSave.Text = "Lưu hình";
            this.toolbtSave.Click += new System.EventHandler(this.toolbtSave_Click);
            // 
            // toolbtDelete
            // 
            this.toolbtDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolbtDelete.Image")));
            this.toolbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtDelete.Name = "toolbtDelete";
            this.toolbtDelete.Size = new System.Drawing.Size(23, 22);
            this.toolbtDelete.Text = "Xóa hình";
            this.toolbtDelete.Click += new System.EventHandler(this.toolbtDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::Ps.Clinic.Properties.Resources.Download_16;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 22);
            this.btnExport.Tag = "Export";
            this.btnExport.Text = "toolStripButton1";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmViewImage
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 616);
            this.Controls.Add(this.pnImageView);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewImage";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Xem hình ảnh";
            this.Load += new System.EventHandler(this.frmViewImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnImageView)).EndInit();
            this.pnImageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl pnImageView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtEdit;
        private System.Windows.Forms.ToolStripButton toolbtSave;
        public System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.ToolStripButton toolbtDelete;
        private System.Windows.Forms.ToolStripButton btnExport;
    }
}