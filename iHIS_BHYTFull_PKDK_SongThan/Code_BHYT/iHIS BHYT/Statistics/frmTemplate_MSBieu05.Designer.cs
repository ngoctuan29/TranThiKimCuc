namespace Ps.Clinic.Statistics
{
    partial class frmTemplate_MSBieu05
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplate_MSBieu05));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridVIew_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_RowIDTemplate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_OrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repspin_OrderNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridCol_LaMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_LaMa_Detail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_TargetName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_Result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChkCB_Service = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repspin_OrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkCB_Service)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.Controls.Add(this.panelControl1);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(999, 526);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Biểu mẫu báo cáo (05/YTTN) - Sức khỏe sinh sản";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_Result);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(995, 504);
            this.panelControl1.TabIndex = 1041;
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Result.MainView = this.gridVIew_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repspin_OrderNumber,
            this.repChkCB_Service});
            this.gridControl_Result.Size = new System.Drawing.Size(995, 504);
            this.gridControl_Result.TabIndex = 3;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVIew_Result});
            this.gridControl_Result.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Result_ProcessGridKey);
            // 
            // gridVIew_Result
            // 
            this.gridVIew_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_RowIDTemplate,
            this.gridCol_OrderNumber,
            this.gridCol_LaMa,
            this.gridCol_LaMa_Detail,
            this.gridCol_TargetName,
            this.gridCol_Result,
            this.gridCol_ServiceCode});
            this.gridVIew_Result.GridControl = this.gridControl_Result;
            this.gridVIew_Result.GroupPanelText = "Kéo thả column gom nhóm";
            this.gridVIew_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ObjectName", null, "- Tổng {0:#,#}", "0")});
            this.gridVIew_Result.Name = "gridVIew_Result";
            this.gridVIew_Result.OptionsFind.FindFilterColumns = "PatientName;PatientCode";
            this.gridVIew_Result.OptionsView.ShowGroupPanel = false;
            this.gridVIew_Result.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridVIew_Result_ValidateRow);
            // 
            // gridCol_RowIDTemplate
            // 
            this.gridCol_RowIDTemplate.Caption = "RowIDTemplate";
            this.gridCol_RowIDTemplate.FieldName = "RowIDTemplate";
            this.gridCol_RowIDTemplate.Name = "gridCol_RowIDTemplate";
            // 
            // gridCol_OrderNumber
            // 
            this.gridCol_OrderNumber.AppearanceCell.Options.UseTextOptions = true;
            this.gridCol_OrderNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_OrderNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCol_OrderNumber.AppearanceHeader.Options.UseFont = true;
            this.gridCol_OrderNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol_OrderNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_OrderNumber.Caption = "STT";
            this.gridCol_OrderNumber.ColumnEdit = this.repspin_OrderNumber;
            this.gridCol_OrderNumber.FieldName = "OrderNumber";
            this.gridCol_OrderNumber.Name = "gridCol_OrderNumber";
            this.gridCol_OrderNumber.OptionsColumn.AllowEdit = false;
            this.gridCol_OrderNumber.OptionsColumn.AllowFocus = false;
            this.gridCol_OrderNumber.OptionsColumn.ReadOnly = true;
            this.gridCol_OrderNumber.Visible = true;
            this.gridCol_OrderNumber.VisibleIndex = 4;
            this.gridCol_OrderNumber.Width = 54;
            // 
            // repspin_OrderNumber
            // 
            this.repspin_OrderNumber.AutoHeight = false;
            this.repspin_OrderNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repspin_OrderNumber.Name = "repspin_OrderNumber";
            // 
            // gridCol_LaMa
            // 
            this.gridCol_LaMa.AppearanceCell.Options.UseTextOptions = true;
            this.gridCol_LaMa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_LaMa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCol_LaMa.AppearanceHeader.Options.UseFont = true;
            this.gridCol_LaMa.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol_LaMa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_LaMa.Caption = "Mục";
            this.gridCol_LaMa.FieldName = "LaMa";
            this.gridCol_LaMa.Name = "gridCol_LaMa";
            this.gridCol_LaMa.OptionsColumn.AllowEdit = false;
            this.gridCol_LaMa.OptionsColumn.AllowFocus = false;
            this.gridCol_LaMa.OptionsColumn.ReadOnly = true;
            this.gridCol_LaMa.Visible = true;
            this.gridCol_LaMa.VisibleIndex = 0;
            this.gridCol_LaMa.Width = 55;
            // 
            // gridCol_LaMa_Detail
            // 
            this.gridCol_LaMa_Detail.AppearanceCell.Options.UseTextOptions = true;
            this.gridCol_LaMa_Detail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridCol_LaMa_Detail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCol_LaMa_Detail.AppearanceHeader.Options.UseFont = true;
            this.gridCol_LaMa_Detail.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol_LaMa_Detail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_LaMa_Detail.Caption = "Mục ...";
            this.gridCol_LaMa_Detail.FieldName = "LaMa_Detail";
            this.gridCol_LaMa_Detail.Name = "gridCol_LaMa_Detail";
            this.gridCol_LaMa_Detail.OptionsColumn.AllowEdit = false;
            this.gridCol_LaMa_Detail.OptionsColumn.AllowFocus = false;
            this.gridCol_LaMa_Detail.OptionsColumn.ReadOnly = true;
            this.gridCol_LaMa_Detail.Visible = true;
            this.gridCol_LaMa_Detail.VisibleIndex = 1;
            // 
            // gridCol_TargetName
            // 
            this.gridCol_TargetName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCol_TargetName.AppearanceHeader.Options.UseFont = true;
            this.gridCol_TargetName.Caption = "Chỉ tiêu";
            this.gridCol_TargetName.FieldName = "TargetName";
            this.gridCol_TargetName.Name = "gridCol_TargetName";
            this.gridCol_TargetName.OptionsColumn.AllowEdit = false;
            this.gridCol_TargetName.OptionsColumn.AllowFocus = false;
            this.gridCol_TargetName.OptionsColumn.ReadOnly = true;
            this.gridCol_TargetName.Visible = true;
            this.gridCol_TargetName.VisibleIndex = 2;
            this.gridCol_TargetName.Width = 405;
            // 
            // gridCol_Result
            // 
            this.gridCol_Result.AppearanceCell.Options.UseTextOptions = true;
            this.gridCol_Result.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_Result.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCol_Result.AppearanceHeader.Options.UseFont = true;
            this.gridCol_Result.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol_Result.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_Result.Caption = "Kết quả";
            this.gridCol_Result.FieldName = "Result";
            this.gridCol_Result.Name = "gridCol_Result";
            this.gridCol_Result.Visible = true;
            this.gridCol_Result.VisibleIndex = 3;
            this.gridCol_Result.Width = 81;
            // 
            // gridCol_ServiceCode
            // 
            this.gridCol_ServiceCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCol_ServiceCode.AppearanceHeader.Options.UseFont = true;
            this.gridCol_ServiceCode.Caption = "Map Dịch vụ";
            this.gridCol_ServiceCode.ColumnEdit = this.repChkCB_Service;
            this.gridCol_ServiceCode.FieldName = "ServiceCode";
            this.gridCol_ServiceCode.Name = "gridCol_ServiceCode";
            this.gridCol_ServiceCode.Visible = true;
            this.gridCol_ServiceCode.VisibleIndex = 5;
            this.gridCol_ServiceCode.Width = 307;
            // 
            // repChkCB_Service
            // 
            this.repChkCB_Service.AutoHeight = false;
            this.repChkCB_Service.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repChkCB_Service.Name = "repChkCB_Service";
            // 
            // frmTemplate_MSBieu05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 526);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTemplate_MSBieu05";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thống kê doanh thu nhà thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTemplate_MSBieu05_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repspin_OrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkCB_Service)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVIew_Result;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_RowIDTemplate;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_OrderNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repspin_OrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_LaMa;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_LaMa_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_TargetName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_Result;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_ServiceCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repChkCB_Service;
    }
}