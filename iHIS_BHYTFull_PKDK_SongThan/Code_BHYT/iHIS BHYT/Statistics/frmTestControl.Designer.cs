namespace Ps.Clinic.Statistics
{
    partial class frmTestControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestControl));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.pivotGridResult = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbonGalleryBarItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(871, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Id = 1;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.ribbonGalleryBarItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 513);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(871, 31);
            // 
            // pivotGridResult
            // 
            this.pivotGridResult.Appearance.Cell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pivotGridResult.Appearance.Cell.Options.UseForeColor = true;
            this.pivotGridResult.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Tahoma", 10F);
            this.pivotGridResult.Appearance.ColumnHeaderArea.Options.UseFont = true;
            this.pivotGridResult.Appearance.CustomTotalCell.ForeColor = System.Drawing.Color.Blue;
            this.pivotGridResult.Appearance.CustomTotalCell.Options.UseForeColor = true;
            this.pivotGridResult.Appearance.FieldValueTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pivotGridResult.Appearance.FieldValueTotal.Options.UseForeColor = true;
            this.pivotGridResult.Appearance.RowHeaderArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pivotGridResult.Appearance.RowHeaderArea.Options.UseForeColor = true;
            this.pivotGridResult.Appearance.TotalCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.pivotGridResult.Appearance.TotalCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pivotGridResult.Appearance.TotalCell.Options.UseFont = true;
            this.pivotGridResult.Appearance.TotalCell.Options.UseForeColor = true;
            this.pivotGridResult.Location = new System.Drawing.Point(0, 110);
            this.pivotGridResult.Name = "pivotGridResult";
            this.pivotGridResult.Size = new System.Drawing.Size(871, 403);
            this.pivotGridResult.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(792, 53);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 544);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.pivotGridResult);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTestControl";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmTestControl";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTestControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridResult;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}