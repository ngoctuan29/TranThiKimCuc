namespace Ps.Clinic.Master
{
    partial class frmMenuRelationPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuRelationPatient));
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RelationTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupMain = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMain)).BeginInit();
            this.groupMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.Size = new System.Drawing.Size(690, 312);
            this.gridControl_Data.TabIndex = 2;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            this.gridControl_Data.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Symptom_ProcessGridKey);
            // 
            // gridView_Data
            // 
            this.gridView_Data.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Data.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Data.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Data.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RelationTitle,
            this.col_RowID});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.NewItemRowText = "Thông tin gia đình (cha, mẹ, ...)";
            this.gridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Data.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Data.OptionsView.ShowFooter = true;
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            this.gridView_Data.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Symptoms_InvalidRowException);
            this.gridView_Data.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Symptoms_ValidateRow);
            // 
            // col_RelationTitle
            // 
            this.col_RelationTitle.Caption = "Thông tin";
            this.col_RelationTitle.FieldName = "RelationTitle";
            this.col_RelationTitle.Name = "col_RelationTitle";
            this.col_RelationTitle.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowID", "")});
            this.col_RelationTitle.Visible = true;
            this.col_RelationTitle.VisibleIndex = 0;
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "Mã";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            // 
            // groupMain
            // 
            this.groupMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupMain.AppearanceCaption.Options.UseFont = true;
            this.groupMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupMain.CaptionImage")));
            this.groupMain.Controls.Add(this.gridControl_Data);
            this.groupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMain.Location = new System.Drawing.Point(0, 0);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(694, 337);
            this.groupMain.TabIndex = 3;
            this.groupMain.Text = "Danh mục - Thông tin gia đình";
            // 
            // frmMenuRelationPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 337);
            this.Controls.Add(this.groupMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenuRelationPatient";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Triệu chứng bệnh ban đầu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuRelationPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMain)).EndInit();
            this.groupMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn col_RelationTitle;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraEditors.GroupControl groupMain;
    }
}