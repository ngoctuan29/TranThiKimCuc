namespace Ps.Clinic.Statistics
{
    partial class frmTheoDoiDauHieuSinhTon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheoDoiDauHieuSinhTon));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.mnoTitle = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.slkupDepartment = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Part_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_DepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_ServiceGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Part_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtTo = new DevExpress.XtraEditors.DateEdit();
            this.txtFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_result_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_ResultS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_result_ResultC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnoTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.mnoTitle);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.slkupDepartment);
            this.groupControl2.Controls.Add(this.butPrint);
            this.groupControl2.Controls.Add(this.butOK);
            this.groupControl2.Controls.Add(this.txtTo);
            this.groupControl2.Controls.Add(this.txtFrom);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(247, 398);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thông số";
            // 
            // mnoTitle
            // 
            this.mnoTitle.Location = new System.Drawing.Point(70, 94);
            this.mnoTitle.Name = "mnoTitle";
            this.mnoTitle.Size = new System.Drawing.Size(172, 39);
            this.mnoTitle.TabIndex = 1042;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 13);
            this.labelControl3.TabIndex = 1037;
            this.labelControl3.Text = "Khoa phòng :";
            // 
            // slkupDepartment
            // 
            this.slkupDepartment.EditValue = "0";
            this.slkupDepartment.Location = new System.Drawing.Point(70, 72);
            this.slkupDepartment.Name = "slkupDepartment";
            this.slkupDepartment.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.slkupDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkupDepartment.Properties.NullText = "";
            this.slkupDepartment.Properties.View = this.gridView1;
            this.slkupDepartment.Size = new System.Drawing.Size(172, 20);
            this.slkupDepartment.TabIndex = 1036;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Part_RowID,
            this.col_Part_DepartmentCode,
            this.col_Part_DepartmentName,
            this.col_Part_ServiceGroupCode,
            this.col_Part_Hide});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col_Part_RowID
            // 
            this.col_Part_RowID.Caption = "Mã";
            this.col_Part_RowID.FieldName = "RowID";
            this.col_Part_RowID.Name = "col_Part_RowID";
            this.col_Part_RowID.Width = 100;
            // 
            // col_Part_DepartmentCode
            // 
            this.col_Part_DepartmentCode.Caption = "Mã Khoa Phòng";
            this.col_Part_DepartmentCode.FieldName = "DepartmentCode";
            this.col_Part_DepartmentCode.Name = "col_Part_DepartmentCode";
            this.col_Part_DepartmentCode.Visible = true;
            this.col_Part_DepartmentCode.VisibleIndex = 0;
            this.col_Part_DepartmentCode.Width = 183;
            // 
            // col_Part_DepartmentName
            // 
            this.col_Part_DepartmentName.Caption = "Khoa phòng";
            this.col_Part_DepartmentName.FieldName = "DepartmentName";
            this.col_Part_DepartmentName.Name = "col_Part_DepartmentName";
            this.col_Part_DepartmentName.Visible = true;
            this.col_Part_DepartmentName.VisibleIndex = 1;
            // 
            // col_Part_ServiceGroupCode
            // 
            this.col_Part_ServiceGroupCode.Caption = "ServiceGroupCode";
            this.col_Part_ServiceGroupCode.FieldName = "ServiceGroupCode";
            this.col_Part_ServiceGroupCode.Name = "col_Part_ServiceGroupCode";
            // 
            // col_Part_Hide
            // 
            this.col_Part_Hide.Caption = "Hide";
            this.col_Part_Hide.FieldName = "Hide";
            this.col_Part_Hide.Name = "col_Part_Hide";
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(154, 139);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(86, 28);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(70, 139);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(83, 28);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txtTo
            // 
            this.txtTo.EditValue = null;
            this.txtTo.Location = new System.Drawing.Point(70, 50);
            this.txtTo.Name = "txtTo";
            this.txtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTo.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtTo.Size = new System.Drawing.Size(172, 20);
            this.txtTo.TabIndex = 3;
            // 
            // txtFrom
            // 
            this.txtFrom.EditValue = null;
            this.txtFrom.Location = new System.Drawing.Point(70, 28);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFrom.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtFrom.Size = new System.Drawing.Size(172, 20);
            this.txtFrom.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Đến ngày :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 97);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Tiêu đề :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày :";
            // 
            // gridControl_result
            // 
            this.gridControl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_result.Location = new System.Drawing.Point(2, 20);
            this.gridControl_result.MainView = this.gridView_result;
            this.gridControl_result.Name = "gridControl_result";
            this.gridControl_result.Size = new System.Drawing.Size(634, 376);
            this.gridControl_result.TabIndex = 6;
            this.gridControl_result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_result});
            // 
            // gridView_result
            // 
            this.gridView_result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_result_PatientCode,
            this.col_result_PatientName,
            this.col_result_CreateDate,
            this.col_result_ResultS,
            this.col_result_ResultC});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsBehavior.Editable = false;
            this.gridView_result.OptionsView.ShowFooter = true;
            this.gridView_result.OptionsView.ShowGroupPanel = false;
            // 
            // col_result_PatientCode
            // 
            this.col_result_PatientCode.Caption = "Mã BN";
            this.col_result_PatientCode.FieldName = "PatientCode";
            this.col_result_PatientCode.Name = "col_result_PatientCode";
            this.col_result_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_result_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_result_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_result_PatientCode.Visible = true;
            this.col_result_PatientCode.VisibleIndex = 0;
            // 
            // col_result_PatientName
            // 
            this.col_result_PatientName.Caption = "Họ và Tên";
            this.col_result_PatientName.FieldName = "PatientName";
            this.col_result_PatientName.Name = "col_result_PatientName";
            this.col_result_PatientName.OptionsColumn.AllowEdit = false;
            this.col_result_PatientName.OptionsColumn.AllowFocus = false;
            this.col_result_PatientName.OptionsColumn.ReadOnly = true;
            this.col_result_PatientName.Visible = true;
            this.col_result_PatientName.VisibleIndex = 1;
            // 
            // col_result_CreateDate
            // 
            this.col_result_CreateDate.Caption = "Ngày";
            this.col_result_CreateDate.FieldName = "CreateDate";
            this.col_result_CreateDate.Name = "col_result_CreateDate";
            this.col_result_CreateDate.OptionsColumn.AllowEdit = false;
            this.col_result_CreateDate.OptionsColumn.AllowFocus = false;
            this.col_result_CreateDate.OptionsColumn.ReadOnly = true;
            this.col_result_CreateDate.Visible = true;
            this.col_result_CreateDate.VisibleIndex = 2;
            // 
            // col_result_ResultS
            // 
            this.col_result_ResultS.Caption = "Sáng";
            this.col_result_ResultS.FieldName = "ResultS";
            this.col_result_ResultS.Name = "col_result_ResultS";
            this.col_result_ResultS.OptionsColumn.AllowEdit = false;
            this.col_result_ResultS.OptionsColumn.AllowFocus = false;
            this.col_result_ResultS.OptionsColumn.ReadOnly = true;
            this.col_result_ResultS.Visible = true;
            this.col_result_ResultS.VisibleIndex = 3;
            // 
            // col_result_ResultC
            // 
            this.col_result_ResultC.Caption = "Chiều";
            this.col_result_ResultC.FieldName = "ResultC";
            this.col_result_ResultC.Name = "col_result_ResultC";
            this.col_result_ResultC.OptionsColumn.AllowEdit = false;
            this.col_result_ResultC.OptionsColumn.AllowFocus = false;
            this.col_result_ResultC.OptionsColumn.ReadOnly = true;
            this.col_result_ResultC.Visible = true;
            this.col_result_ResultC.VisibleIndex = 4;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(890, 398);
            this.splitContainerControl1.SplitterPosition = 247;
            this.splitContainerControl1.TabIndex = 7;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl_result);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(638, 398);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Dữ liệu";
            // 
            // frmTheoDoiDauHieuSinhTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 398);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTheoDoiDauHieuSinhTon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTheoDoiDauHieuSinhTon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnoTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkupDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtTo;
        private DevExpress.XtraEditors.DateEdit txtFrom;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SearchLookUpEdit slkupDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_DepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_ServiceGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Part_Hide;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_CreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_ResultS;
        private DevExpress.XtraGrid.Columns.GridColumn col_result_ResultC;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit mnoTitle;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}