namespace Ps.Clinic.Master
{
    partial class frmMapMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapMachine));
            this.ref_Service_Group_Code = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Machine = new DevExpress.XtraGrid.GridControl();
            this.gridView_Machine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItem_CategoryCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Service_Group_CodeMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TypeResult = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_Group_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Machine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Machine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem_CategoryCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ref_Service_Group_Code
            // 
            this.ref_Service_Group_Code.AutoHeight = false;
            this.ref_Service_Group_Code.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.ref_Service_Group_Code.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Service_Group_Code.Name = "ref_Service_Group_Code";
            this.ref_Service_Group_Code.NullText = "Y/c chọn...!";
            this.ref_Service_Group_Code.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.panelControl2);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(666, 358);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh sách loại mô tả kết quả xét nghiệm";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gridControl_Machine);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(662, 333);
            this.panelControl2.TabIndex = 6;
            // 
            // gridControl_Machine
            // 
            this.gridControl_Machine.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Machine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Machine.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Machine.MainView = this.gridView_Machine;
            this.gridControl_Machine.Name = "gridControl_Machine";
            this.gridControl_Machine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItem_CategoryCode});
            this.gridControl_Machine.Size = new System.Drawing.Size(662, 333);
            this.gridControl_Machine.TabIndex = 1;
            this.gridControl_Machine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Machine});
            // 
            // gridView_Machine
            // 
            this.gridView_Machine.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Machine.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Machine.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Machine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ServiceCategoryCode,
            this.col_Service_Group_CodeMachineCode,
            this.col_TypeResult});
            this.gridView_Machine.GridControl = this.gridControl_Machine;
            this.gridView_Machine.GroupPanelText = "Nhóm loại viện phí theo nhóm!";
            this.gridView_Machine.Name = "gridView_Machine";
            this.gridView_Machine.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (loại viện phí).";
            this.gridView_Machine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Machine.OptionsView.ShowFooter = true;
            this.gridView_Machine.OptionsView.ShowGroupPanel = false;
            // 
            // col_ServiceCategoryCode
            // 
            this.col_ServiceCategoryCode.Caption = "Tên loại viện phí";
            this.col_ServiceCategoryCode.ColumnEdit = this.repItem_CategoryCode;
            this.col_ServiceCategoryCode.FieldName = "ServiceCategoryCode";
            this.col_ServiceCategoryCode.Name = "col_ServiceCategoryCode";
            this.col_ServiceCategoryCode.Visible = true;
            this.col_ServiceCategoryCode.VisibleIndex = 1;
            this.col_ServiceCategoryCode.Width = 498;
            // 
            // repItem_CategoryCode
            // 
            this.repItem_CategoryCode.AutoHeight = false;
            this.repItem_CategoryCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItem_CategoryCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryCode", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryName", "Loại xét nghiệm")});
            this.repItem_CategoryCode.Name = "repItem_CategoryCode";
            this.repItem_CategoryCode.NullText = "";
            // 
            // col_Service_Group_CodeMachineCode
            // 
            this.col_Service_Group_CodeMachineCode.Caption = "Nhóm viện phí";
            this.col_Service_Group_CodeMachineCode.FieldName = "MachineCode";
            this.col_Service_Group_CodeMachineCode.Name = "col_Service_Group_CodeMachineCode";
            this.col_Service_Group_CodeMachineCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ServiceGroupCode", "Count: {0:#,#}")});
            this.col_Service_Group_CodeMachineCode.Visible = true;
            this.col_Service_Group_CodeMachineCode.VisibleIndex = 0;
            this.col_Service_Group_CodeMachineCode.Width = 95;
            // 
            // col_TypeResult
            // 
            this.col_TypeResult.AppearanceCell.Options.UseTextOptions = true;
            this.col_TypeResult.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TypeResult.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TypeResult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TypeResult.Caption = "STT";
            this.col_TypeResult.DisplayFormat.FormatString = "#,###";
            this.col_TypeResult.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_TypeResult.FieldName = "TypeResult";
            this.col_TypeResult.Name = "col_TypeResult";
            this.col_TypeResult.Visible = true;
            this.col_TypeResult.VisibleIndex = 2;
            this.col_TypeResult.Width = 53;
            // 
            // frmMapMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 358);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapMachine";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo loại viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMapMachine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ref_Service_Group_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Machine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Machine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem_CategoryCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl_Machine;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Machine;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Service_Group_CodeMachineCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_TypeResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ref_Service_Group_Code;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItem_CategoryCode;
    }
}