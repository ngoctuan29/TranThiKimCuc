namespace Ps.Clinic.Statistics
{
    partial class frmKBSoXN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKBSoXN));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridVIew_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Result_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_GenderFeMale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_GenderMale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_CareerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_EThnicName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_DiagnosisCustom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_PostingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_kq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.controlDatetime = new UserControlDateTimes.UserControlDateTimes();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butRefesh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.panelControl1);
            this.grMain.Controls.Add(this.panelControl3);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(999, 526);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Sổ Khám Bệnh Ngày";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_Result);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(995, 464);
            this.panelControl1.TabIndex = 1041;
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Result.MainView = this.gridVIew_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(995, 464);
            this.gridControl_Result.TabIndex = 3;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVIew_Result});
            // 
            // gridVIew_Result
            // 
            this.gridVIew_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Result_PatientName,
            this.col_Result_GenderFeMale,
            this.col_Result_GenderMale,
            this.col_Result_CareerName,
            this.col_Result_EThnicName,
            this.col_Result_DiagnosisCustom,
            this.col_Result_PatientAddress,
            this.col_Result_PostingDate,
            this.col_STT,
            this.col_PatientCode,
            this.col_ServiceName,
            this.col_kq,
            this.col_EmployeeName});
            this.gridVIew_Result.GridControl = this.gridControl_Result;
            this.gridVIew_Result.GroupPanelText = "Kéo thả column gom nhóm";
            this.gridVIew_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ObjectName", null, "- Tổng {0:#,#}", "0")});
            this.gridVIew_Result.Name = "gridVIew_Result";
            this.gridVIew_Result.OptionsFind.FindFilterColumns = "PatientName;PatientCode";
            this.gridVIew_Result.OptionsView.ColumnAutoWidth = false;
            this.gridVIew_Result.OptionsView.ShowFooter = true;
            // 
            // col_Result_PatientName
            // 
            this.col_Result_PatientName.Caption = "Họ và tên";
            this.col_Result_PatientName.FieldName = "PatientName";
            this.col_Result_PatientName.Name = "col_Result_PatientName";
            this.col_Result_PatientName.OptionsColumn.AllowEdit = false;
            this.col_Result_PatientName.OptionsColumn.AllowFocus = false;
            this.col_Result_PatientName.Visible = true;
            this.col_Result_PatientName.VisibleIndex = 3;
            this.col_Result_PatientName.Width = 179;
            // 
            // col_Result_GenderFeMale
            // 
            this.col_Result_GenderFeMale.AppearanceCell.Options.UseTextOptions = true;
            this.col_Result_GenderFeMale.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Result_GenderFeMale.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Result_GenderFeMale.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Result_GenderFeMale.Caption = "Nữ";
            this.col_Result_GenderFeMale.DisplayFormat.FormatString = "{0:#,#}";
            this.col_Result_GenderFeMale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Result_GenderFeMale.FieldName = "GenderFeMale";
            this.col_Result_GenderFeMale.Name = "col_Result_GenderFeMale";
            this.col_Result_GenderFeMale.OptionsColumn.AllowEdit = false;
            this.col_Result_GenderFeMale.OptionsColumn.AllowFocus = false;
            this.col_Result_GenderFeMale.Visible = true;
            this.col_Result_GenderFeMale.VisibleIndex = 5;
            this.col_Result_GenderFeMale.Width = 43;
            // 
            // col_Result_GenderMale
            // 
            this.col_Result_GenderMale.AppearanceCell.Options.UseTextOptions = true;
            this.col_Result_GenderMale.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Result_GenderMale.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Result_GenderMale.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Result_GenderMale.Caption = "Nam";
            this.col_Result_GenderMale.DisplayFormat.FormatString = "{0:#,#}";
            this.col_Result_GenderMale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Result_GenderMale.FieldName = "GenderMale";
            this.col_Result_GenderMale.Name = "col_Result_GenderMale";
            this.col_Result_GenderMale.OptionsColumn.AllowEdit = false;
            this.col_Result_GenderMale.OptionsColumn.AllowFocus = false;
            this.col_Result_GenderMale.Visible = true;
            this.col_Result_GenderMale.VisibleIndex = 4;
            this.col_Result_GenderMale.Width = 42;
            // 
            // col_Result_CareerName
            // 
            this.col_Result_CareerName.Caption = "Nghề nghiệp";
            this.col_Result_CareerName.FieldName = "CareerName";
            this.col_Result_CareerName.Name = "col_Result_CareerName";
            this.col_Result_CareerName.OptionsColumn.AllowEdit = false;
            this.col_Result_CareerName.OptionsColumn.AllowFocus = false;
            this.col_Result_CareerName.Visible = true;
            this.col_Result_CareerName.VisibleIndex = 7;
            this.col_Result_CareerName.Width = 86;
            // 
            // col_Result_EThnicName
            // 
            this.col_Result_EThnicName.Caption = "Dân tộc";
            this.col_Result_EThnicName.FieldName = "EThnicName";
            this.col_Result_EThnicName.Name = "col_Result_EThnicName";
            this.col_Result_EThnicName.OptionsColumn.AllowEdit = false;
            this.col_Result_EThnicName.OptionsColumn.AllowFocus = false;
            this.col_Result_EThnicName.Visible = true;
            this.col_Result_EThnicName.VisibleIndex = 8;
            this.col_Result_EThnicName.Width = 84;
            // 
            // col_Result_DiagnosisCustom
            // 
            this.col_Result_DiagnosisCustom.Caption = "Chẩn đoán";
            this.col_Result_DiagnosisCustom.FieldName = "DiagnosisCustom";
            this.col_Result_DiagnosisCustom.Name = "col_Result_DiagnosisCustom";
            this.col_Result_DiagnosisCustom.OptionsColumn.AllowEdit = false;
            this.col_Result_DiagnosisCustom.OptionsColumn.AllowFocus = false;
            this.col_Result_DiagnosisCustom.Visible = true;
            this.col_Result_DiagnosisCustom.VisibleIndex = 9;
            this.col_Result_DiagnosisCustom.Width = 128;
            // 
            // col_Result_PatientAddress
            // 
            this.col_Result_PatientAddress.Caption = "Địa chỉ";
            this.col_Result_PatientAddress.FieldName = "PatientAddress";
            this.col_Result_PatientAddress.Name = "col_Result_PatientAddress";
            this.col_Result_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_Result_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_Result_PatientAddress.Visible = true;
            this.col_Result_PatientAddress.VisibleIndex = 6;
            this.col_Result_PatientAddress.Width = 194;
            // 
            // col_Result_PostingDate
            // 
            this.col_Result_PostingDate.Caption = "Ngày xét nghiệm";
            this.col_Result_PostingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_Result_PostingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_Result_PostingDate.FieldName = "PostingDate";
            this.col_Result_PostingDate.Name = "col_Result_PostingDate";
            this.col_Result_PostingDate.OptionsColumn.AllowEdit = false;
            this.col_Result_PostingDate.OptionsColumn.AllowFocus = false;
            this.col_Result_PostingDate.Visible = true;
            this.col_Result_PostingDate.VisibleIndex = 0;
            this.col_Result_PostingDate.Width = 93;
            // 
            // col_STT
            // 
            this.col_STT.Caption = "STT";
            this.col_STT.FieldName = "STT";
            this.col_STT.Name = "col_STT";
            this.col_STT.OptionsColumn.AllowEdit = false;
            this.col_STT.OptionsColumn.AllowFocus = false;
            this.col_STT.OptionsColumn.ReadOnly = true;
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 1;
            this.col_STT.Width = 26;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.Caption = "Mã bệnh nhân";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 2;
            this.col_PatientCode.Width = 78;
            // 
            // col_ServiceName
            // 
            this.col_ServiceName.Caption = "Tên xét nghiệm";
            this.col_ServiceName.FieldName = "ServiceName";
            this.col_ServiceName.Name = "col_ServiceName";
            this.col_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_ServiceName.Visible = true;
            this.col_ServiceName.VisibleIndex = 10;
            this.col_ServiceName.Width = 180;
            // 
            // col_kq
            // 
            this.col_kq.Caption = "Kết quả xét nghiệm";
            this.col_kq.FieldName = "kq";
            this.col_kq.Name = "col_kq";
            this.col_kq.OptionsColumn.AllowEdit = false;
            this.col_kq.OptionsColumn.AllowFocus = false;
            this.col_kq.Visible = true;
            this.col_kq.VisibleIndex = 11;
            this.col_kq.Width = 258;
            // 
            // col_EmployeeName
            // 
            this.col_EmployeeName.Caption = "Người thực hiện";
            this.col_EmployeeName.FieldName = "EmployeeName";
            this.col_EmployeeName.Name = "col_EmployeeName";
            this.col_EmployeeName.OptionsColumn.AllowEdit = false;
            this.col_EmployeeName.OptionsColumn.AllowFocus = false;
            this.col_EmployeeName.Visible = true;
            this.col_EmployeeName.VisibleIndex = 12;
            this.col_EmployeeName.Width = 147;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.controlDatetime);
            this.panelControl3.Controls.Add(this.butPrint);
            this.panelControl3.Controls.Add(this.butRefesh);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 20);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(995, 40);
            this.panelControl3.TabIndex = 3;
            // 
            // controlDatetime
            // 
            this.controlDatetime.Location = new System.Drawing.Point(3, 6);
            this.controlDatetime.Name = "controlDatetime";
            this.controlDatetime.Size = new System.Drawing.Size(640, 25);
            this.controlDatetime.TabIndex = 6;
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(752, 6);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(81, 26);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In báo cáo";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butRefesh
            // 
            this.butRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butRefesh.Image = ((System.Drawing.Image)(resources.GetObject("butRefesh.Image")));
            this.butRefesh.Location = new System.Drawing.Point(649, 6);
            this.butRefesh.Name = "butRefesh";
            this.butRefesh.Size = new System.Drawing.Size(102, 26);
            this.butRefesh.TabIndex = 4;
            this.butRefesh.Text = "Lấy dữ liệu";
            this.butRefesh.Click += new System.EventHandler(this.butRefesh_Click);
            // 
            // frmKBSoXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 526);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKBSoXN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thống kê doanh thu nhà thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVIew_Result;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private UserControlDateTimes.UserControlDateTimes controlDatetime;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butRefesh;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_GenderFeMale;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_GenderMale;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_CareerName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_EThnicName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_DiagnosisCustom;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_PostingDate;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_kq;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeName;
    }
}