namespace Ps.Clinic.Statistics
{
    partial class frm_BM04_YTTN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BM04_YTTN));
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridVIew_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProvincialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_WardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DistrictName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_WorkDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DoseNoName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.controlDatetime = new UserControlDateTimes.UserControlDateTimes();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butRefesh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 40);
            this.gridControl_Result.MainView = this.gridVIew_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(858, 340);
            this.gridControl_Result.TabIndex = 5;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVIew_Result});
            // 
            // gridVIew_Result
            // 
            this.gridVIew_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_PatientCode,
            this.col_PatientName,
            this.col_PatientGender,
            this.col_PatientBirthday,
            this.col_ProvincialName,
            this.col_WardName,
            this.col_DistrictName,
            this.col_PatientAddress,
            this.col_WorkDate,
            this.col_ServiceName,
            this.col_DoseNoName,
            this.col_Note});
            this.gridVIew_Result.GridControl = this.gridControl_Result;
            this.gridVIew_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridVIew_Result.Name = "gridVIew_Result";
            this.gridVIew_Result.OptionsFind.FindFilterColumns = "ItemName";
            this.gridVIew_Result.OptionsView.ColumnAutoWidth = false;
            this.gridVIew_Result.OptionsView.ShowFooter = true;
            this.gridVIew_Result.OptionsView.ShowGroupPanel = false;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.Caption = "Mã bệnh nhân";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 0;
            this.col_PatientCode.Width = 90;
            // 
            // col_PatientName
            // 
            this.col_PatientName.Caption = "Họ và tên";
            this.col_PatientName.FieldName = "PatientName";
            this.col_PatientName.Name = "col_PatientName";
            this.col_PatientName.OptionsColumn.AllowEdit = false;
            this.col_PatientName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_PatientName.Visible = true;
            this.col_PatientName.VisibleIndex = 1;
            this.col_PatientName.Width = 154;
            // 
            // col_PatientGender
            // 
            this.col_PatientGender.Caption = "Giới tính";
            this.col_PatientGender.FieldName = "PatientGender";
            this.col_PatientGender.Name = "col_PatientGender";
            this.col_PatientGender.OptionsColumn.AllowEdit = false;
            this.col_PatientGender.Visible = true;
            this.col_PatientGender.VisibleIndex = 2;
            this.col_PatientGender.Width = 56;
            // 
            // col_PatientBirthday
            // 
            this.col_PatientBirthday.Caption = "Ngày sinh";
            this.col_PatientBirthday.FieldName = "PatientBirthday";
            this.col_PatientBirthday.Name = "col_PatientBirthday";
            this.col_PatientBirthday.OptionsColumn.AllowEdit = false;
            this.col_PatientBirthday.Visible = true;
            this.col_PatientBirthday.VisibleIndex = 3;
            // 
            // col_ProvincialName
            // 
            this.col_ProvincialName.Caption = "Tỉnh, TP";
            this.col_ProvincialName.FieldName = "ProvincialName";
            this.col_ProvincialName.Name = "col_ProvincialName";
            this.col_ProvincialName.OptionsColumn.AllowEdit = false;
            this.col_ProvincialName.Visible = true;
            this.col_ProvincialName.VisibleIndex = 4;
            this.col_ProvincialName.Width = 136;
            // 
            // col_WardName
            // 
            this.col_WardName.Caption = "Quận, Huyện";
            this.col_WardName.FieldName = "WardName";
            this.col_WardName.Name = "col_WardName";
            this.col_WardName.OptionsColumn.AllowEdit = false;
            this.col_WardName.Visible = true;
            this.col_WardName.VisibleIndex = 5;
            this.col_WardName.Width = 125;
            // 
            // col_DistrictName
            // 
            this.col_DistrictName.Caption = "Xã, Phường";
            this.col_DistrictName.FieldName = "DistrictName";
            this.col_DistrictName.Name = "col_DistrictName";
            this.col_DistrictName.OptionsColumn.AllowEdit = false;
            this.col_DistrictName.Visible = true;
            this.col_DistrictName.VisibleIndex = 6;
            this.col_DistrictName.Width = 158;
            // 
            // col_PatientAddress
            // 
            this.col_PatientAddress.Caption = "Địa chỉ nơi ở hiện nay";
            this.col_PatientAddress.FieldName = "PatientAddress";
            this.col_PatientAddress.Name = "col_PatientAddress";
            this.col_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_PatientAddress.Visible = true;
            this.col_PatientAddress.VisibleIndex = 7;
            this.col_PatientAddress.Width = 239;
            // 
            // col_WorkDate
            // 
            this.col_WorkDate.Caption = "Ngày tiêm chủng";
            this.col_WorkDate.FieldName = "WorkDate";
            this.col_WorkDate.Name = "col_WorkDate";
            this.col_WorkDate.OptionsColumn.AllowEdit = false;
            this.col_WorkDate.Visible = true;
            this.col_WorkDate.VisibleIndex = 8;
            this.col_WorkDate.Width = 96;
            // 
            // col_ServiceName
            // 
            this.col_ServiceName.Caption = "Loại vaccine";
            this.col_ServiceName.FieldName = "ServiceName";
            this.col_ServiceName.Name = "col_ServiceName";
            this.col_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_ServiceName.Visible = true;
            this.col_ServiceName.VisibleIndex = 9;
            this.col_ServiceName.Width = 85;
            // 
            // col_DoseNoName
            // 
            this.col_DoseNoName.Caption = "Mũi tiêm thử";
            this.col_DoseNoName.FieldName = "DoseNoName";
            this.col_DoseNoName.Name = "col_DoseNoName";
            this.col_DoseNoName.OptionsColumn.AllowEdit = false;
            this.col_DoseNoName.Visible = true;
            this.col_DoseNoName.VisibleIndex = 10;
            this.col_DoseNoName.Width = 68;
            // 
            // col_Note
            // 
            this.col_Note.Caption = "Ghi chú";
            this.col_Note.FieldName = "Note";
            this.col_Note.Name = "col_Note";
            this.col_Note.OptionsColumn.AllowEdit = false;
            this.col_Note.Visible = true;
            this.col_Note.VisibleIndex = 11;
            this.col_Note.Width = 113;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.controlDatetime);
            this.panelControl3.Controls.Add(this.butPrint);
            this.panelControl3.Controls.Add(this.butRefesh);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(858, 40);
            this.panelControl3.TabIndex = 8;
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
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(752, 6);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(81, 26);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "File Excel";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butRefesh
            // 
            this.butRefesh.Image = ((System.Drawing.Image)(resources.GetObject("butRefesh.Image")));
            this.butRefesh.Location = new System.Drawing.Point(649, 6);
            this.butRefesh.Name = "butRefesh";
            this.butRefesh.Size = new System.Drawing.Size(102, 26);
            this.butRefesh.TabIndex = 4;
            this.butRefesh.Text = "Lấy dữ liệu";
            this.butRefesh.Click += new System.EventHandler(this.butRefesh_Click);
            // 
            // frm_BM04_YTTN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 380);
            this.Controls.Add(this.gridControl_Result);
            this.Controls.Add(this.panelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_BM04_YTTN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tình hình tiêm chủng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVIew_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientGender;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientBirthday;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProvincialName;
        private DevExpress.XtraGrid.Columns.GridColumn col_WardName;
        private DevExpress.XtraGrid.Columns.GridColumn col_DistrictName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_WorkDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_DoseNoName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Note;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private UserControlDateTimes.UserControlDateTimes controlDatetime;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butRefesh;
    }
}