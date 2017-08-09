namespace Ps.Clinic.Master
{
    partial class frmLimitForService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLimitForService));
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Service = new DevExpress.XtraGrid.GridControl();
            this.gridView_Service = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Ser_ServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ser_ServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ser_ServiceCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Ser_Chon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_Ser_ServiceGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grListEmployee = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Employee = new DevExpress.XtraGrid.GridControl();
            this.gridView_Employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Employee_Sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_status_sex = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_EmployeeMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeIDCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeeBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_status_position = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_EmployeeUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmployeePass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_OffWork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_OffWork = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_DepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Department = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pnTemplate = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Ser_Chon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grListEmployee)).BeginInit();
            this.grListEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_OffWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).BeginInit();
            this.pnTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grDetails
            // 
            this.grDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grDetails.AppearanceCaption.Options.UseFont = true;
            this.grDetails.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grDetails.CaptionImage")));
            this.grDetails.Controls.Add(this.chkAll);
            this.grDetails.Controls.Add(this.butSave);
            this.grDetails.Controls.Add(this.gridControl_Service);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 0);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(613, 595);
            this.grDetails.TabIndex = 0;
            this.grDetails.Text = "Dịch vụ";
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.Location = new System.Drawing.Point(524, 77);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Chọn tất cả";
            this.chkAll.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkAll.Size = new System.Drawing.Size(85, 19);
            this.chkAll.TabIndex = 1012;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(532, 31);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(77, 29);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Cập nhật";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // gridControl_Service
            // 
            this.gridControl_Service.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Service.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Service.MainView = this.gridView_Service;
            this.gridControl_Service.Name = "gridControl_Service";
            this.gridControl_Service.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_Ser_Chon});
            this.gridControl_Service.Size = new System.Drawing.Size(609, 570);
            this.gridControl_Service.TabIndex = 13;
            this.gridControl_Service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Service});
            // 
            // gridView_Service
            // 
            this.gridView_Service.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Service.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Service.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Ser_ServiceCode,
            this.col_Ser_ServiceName,
            this.col_Ser_ServiceCategoryName,
            this.col_Chon,
            this.col_Ser_ServiceGroupName});
            this.gridView_Service.GridControl = this.gridControl_Service;
            this.gridView_Service.Name = "gridView_Service";
            this.gridView_Service.NewItemRowText = "Khai báo chi tiết gói";
            this.gridView_Service.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Service.OptionsFind.AlwaysVisible = true;
            this.gridView_Service.OptionsFind.FindFilterColumns = "ServiceName";
            this.gridView_Service.OptionsView.ShowFooter = true;
            // 
            // col_Ser_ServiceCode
            // 
            this.col_Ser_ServiceCode.Caption = "Mã DV";
            this.col_Ser_ServiceCode.FieldName = "ServiceCode";
            this.col_Ser_ServiceCode.Name = "col_Ser_ServiceCode";
            this.col_Ser_ServiceCode.OptionsColumn.AllowEdit = false;
            this.col_Ser_ServiceCode.OptionsColumn.AllowFocus = false;
            this.col_Ser_ServiceCode.OptionsColumn.AllowMove = false;
            this.col_Ser_ServiceCode.Visible = true;
            this.col_Ser_ServiceCode.VisibleIndex = 0;
            this.col_Ser_ServiceCode.Width = 105;
            // 
            // col_Ser_ServiceName
            // 
            this.col_Ser_ServiceName.Caption = "Tên dịch vụ";
            this.col_Ser_ServiceName.FieldName = "ServiceName";
            this.col_Ser_ServiceName.Name = "col_Ser_ServiceName";
            this.col_Ser_ServiceName.OptionsColumn.AllowEdit = false;
            this.col_Ser_ServiceName.OptionsColumn.AllowFocus = false;
            this.col_Ser_ServiceName.OptionsColumn.AllowMove = false;
            this.col_Ser_ServiceName.OptionsColumn.ReadOnly = true;
            this.col_Ser_ServiceName.Visible = true;
            this.col_Ser_ServiceName.VisibleIndex = 1;
            this.col_Ser_ServiceName.Width = 335;
            // 
            // col_Ser_ServiceCategoryName
            // 
            this.col_Ser_ServiceCategoryName.Caption = "Loại dịch vụ";
            this.col_Ser_ServiceCategoryName.FieldName = "ServiceCategoryName";
            this.col_Ser_ServiceCategoryName.Name = "col_Ser_ServiceCategoryName";
            this.col_Ser_ServiceCategoryName.OptionsColumn.AllowEdit = false;
            this.col_Ser_ServiceCategoryName.OptionsColumn.AllowFocus = false;
            this.col_Ser_ServiceCategoryName.OptionsColumn.ReadOnly = true;
            this.col_Ser_ServiceCategoryName.Visible = true;
            this.col_Ser_ServiceCategoryName.VisibleIndex = 2;
            this.col_Ser_ServiceCategoryName.Width = 162;
            // 
            // col_Chon
            // 
            this.col_Chon.AppearanceCell.Options.UseTextOptions = true;
            this.col_Chon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Chon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Chon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Chon.Caption = "Chọn";
            this.col_Chon.ColumnEdit = this.rep_Ser_Chon;
            this.col_Chon.FieldName = "Chon";
            this.col_Chon.Name = "col_Chon";
            this.col_Chon.OptionsColumn.AllowMove = false;
            this.col_Chon.Visible = true;
            this.col_Chon.VisibleIndex = 4;
            this.col_Chon.Width = 56;
            // 
            // rep_Ser_Chon
            // 
            this.rep_Ser_Chon.AutoHeight = false;
            this.rep_Ser_Chon.DisplayValueChecked = "1";
            this.rep_Ser_Chon.DisplayValueGrayed = "0";
            this.rep_Ser_Chon.DisplayValueUnchecked = "0";
            this.rep_Ser_Chon.Name = "rep_Ser_Chon";
            this.rep_Ser_Chon.ValueChecked = 1;
            this.rep_Ser_Chon.ValueGrayed = 0;
            this.rep_Ser_Chon.ValueUnchecked = 0;
            // 
            // col_Ser_ServiceGroupName
            // 
            this.col_Ser_ServiceGroupName.Caption = "Nhóm";
            this.col_Ser_ServiceGroupName.FieldName = "ServiceGroupName";
            this.col_Ser_ServiceGroupName.Name = "col_Ser_ServiceGroupName";
            this.col_Ser_ServiceGroupName.OptionsColumn.AllowEdit = false;
            this.col_Ser_ServiceGroupName.OptionsColumn.AllowFocus = false;
            this.col_Ser_ServiceGroupName.OptionsColumn.ReadOnly = true;
            this.col_Ser_ServiceGroupName.Visible = true;
            this.col_Ser_ServiceGroupName.VisibleIndex = 3;
            this.col_Ser_ServiceGroupName.Width = 116;
            // 
            // grListEmployee
            // 
            this.grListEmployee.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grListEmployee.AppearanceCaption.Options.UseFont = true;
            this.grListEmployee.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grListEmployee.CaptionImage")));
            this.grListEmployee.Controls.Add(this.gridControl_Employee);
            this.grListEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grListEmployee.Location = new System.Drawing.Point(0, 0);
            this.grListEmployee.Name = "grListEmployee";
            this.grListEmployee.Size = new System.Drawing.Size(393, 595);
            this.grListEmployee.TabIndex = 0;
            this.grListEmployee.Text = "Danh sách nhân viên";
            // 
            // gridControl_Employee
            // 
            this.gridControl_Employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Employee.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Employee.MainView = this.gridView_Employee;
            this.gridControl_Employee.Name = "gridControl_Employee";
            this.gridControl_Employee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_status_sex,
            this.ref_status_position,
            this.ref_OffWork,
            this.ref_Department});
            this.gridControl_Employee.Size = new System.Drawing.Size(389, 570);
            this.gridControl_Employee.TabIndex = 2;
            this.gridControl_Employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Employee});
            // 
            // gridView_Employee
            // 
            this.gridView_Employee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_EmployeeCode,
            this.col_EmployeeName,
            this.col_Employee_Sex,
            this.col_EmployeeMobile,
            this.col_EmployeeIDCard,
            this.col_EmployeeAddress,
            this.col_EmployeeBirthday,
            this.col_EmployeePosition,
            this.col_EmployeeUsername,
            this.col_EmployeePass,
            this.col_OffWork,
            this.col_DepartmentCode});
            this.gridView_Employee.GridControl = this.gridControl_Employee;
            this.gridView_Employee.IndicatorWidth = 30;
            this.gridView_Employee.Name = "gridView_Employee";
            this.gridView_Employee.NewItemRowText = "Thêm mới nhân viên sử dụng phần mềm";
            this.gridView_Employee.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Employee.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Employee.OptionsBehavior.Editable = false;
            this.gridView_Employee.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_Employee_CustomDrawRowIndicator);
            this.gridView_Employee.Click += new System.EventHandler(this.gridView_Employee_Click);
            // 
            // col_EmployeeCode
            // 
            this.col_EmployeeCode.Caption = "Mã nv";
            this.col_EmployeeCode.FieldName = "EmployeeCode";
            this.col_EmployeeCode.Name = "col_EmployeeCode";
            this.col_EmployeeCode.OptionsColumn.AllowEdit = false;
            this.col_EmployeeCode.OptionsColumn.AllowFocus = false;
            this.col_EmployeeCode.OptionsColumn.ReadOnly = true;
            // 
            // col_EmployeeName
            // 
            this.col_EmployeeName.Caption = "Họ tên";
            this.col_EmployeeName.FieldName = "EmployeeName";
            this.col_EmployeeName.Name = "col_EmployeeName";
            this.col_EmployeeName.OptionsColumn.AllowEdit = false;
            this.col_EmployeeName.OptionsColumn.AllowFocus = false;
            this.col_EmployeeName.Visible = true;
            this.col_EmployeeName.VisibleIndex = 0;
            this.col_EmployeeName.Width = 150;
            // 
            // col_Employee_Sex
            // 
            this.col_Employee_Sex.AppearanceCell.Options.UseTextOptions = true;
            this.col_Employee_Sex.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Employee_Sex.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Employee_Sex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Employee_Sex.Caption = "Giới tính";
            this.col_Employee_Sex.ColumnEdit = this.ref_status_sex;
            this.col_Employee_Sex.FieldName = "Sex";
            this.col_Employee_Sex.Name = "col_Employee_Sex";
            this.col_Employee_Sex.OptionsColumn.AllowEdit = false;
            this.col_Employee_Sex.OptionsColumn.AllowFocus = false;
            this.col_Employee_Sex.Visible = true;
            this.col_Employee_Sex.VisibleIndex = 1;
            this.col_Employee_Sex.Width = 47;
            // 
            // ref_status_sex
            // 
            this.ref_status_sex.AutoHeight = false;
            this.ref_status_sex.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_status_sex.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusCode", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusName", "Nội dung")});
            this.ref_status_sex.Name = "ref_status_sex";
            this.ref_status_sex.NullText = "...";
            // 
            // col_EmployeeMobile
            // 
            this.col_EmployeeMobile.Caption = "Điện thoại";
            this.col_EmployeeMobile.FieldName = "Mobile";
            this.col_EmployeeMobile.Name = "col_EmployeeMobile";
            this.col_EmployeeMobile.Width = 67;
            // 
            // col_EmployeeIDCard
            // 
            this.col_EmployeeIDCard.Caption = "TAX/CMND";
            this.col_EmployeeIDCard.FieldName = "IDCard";
            this.col_EmployeeIDCard.Name = "col_EmployeeIDCard";
            this.col_EmployeeIDCard.Width = 67;
            // 
            // col_EmployeeAddress
            // 
            this.col_EmployeeAddress.Caption = "Địa chỉ";
            this.col_EmployeeAddress.FieldName = "Address";
            this.col_EmployeeAddress.Name = "col_EmployeeAddress";
            this.col_EmployeeAddress.Width = 67;
            // 
            // col_EmployeeBirthday
            // 
            this.col_EmployeeBirthday.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeeBirthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeeBirthday.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeeBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeeBirthday.Caption = "Ngày sinh";
            this.col_EmployeeBirthday.FieldName = "Birthday";
            this.col_EmployeeBirthday.Name = "col_EmployeeBirthday";
            this.col_EmployeeBirthday.Width = 67;
            // 
            // col_EmployeePosition
            // 
            this.col_EmployeePosition.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeePosition.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePosition.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeePosition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePosition.Caption = "Chức danh";
            this.col_EmployeePosition.ColumnEdit = this.ref_status_position;
            this.col_EmployeePosition.FieldName = "PositionCode";
            this.col_EmployeePosition.Name = "col_EmployeePosition";
            this.col_EmployeePosition.OptionsColumn.AllowEdit = false;
            this.col_EmployeePosition.OptionsColumn.AllowFocus = false;
            this.col_EmployeePosition.Visible = true;
            this.col_EmployeePosition.VisibleIndex = 2;
            this.col_EmployeePosition.Width = 67;
            // 
            // ref_status_position
            // 
            this.ref_status_position.AutoHeight = false;
            this.ref_status_position.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_status_position.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionCode", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionName", "Vị trí")});
            this.ref_status_position.Name = "ref_status_position";
            this.ref_status_position.NullText = "...";
            // 
            // col_EmployeeUsername
            // 
            this.col_EmployeeUsername.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeeUsername.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_EmployeeUsername.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeeUsername.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeeUsername.Caption = "Tên đăng nhập";
            this.col_EmployeeUsername.FieldName = "Username";
            this.col_EmployeeUsername.Name = "col_EmployeeUsername";
            this.col_EmployeeUsername.Width = 67;
            // 
            // col_EmployeePass
            // 
            this.col_EmployeePass.AppearanceCell.Options.UseTextOptions = true;
            this.col_EmployeePass.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePass.AppearanceHeader.Options.UseTextOptions = true;
            this.col_EmployeePass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_EmployeePass.Caption = "Mật khẩu";
            this.col_EmployeePass.FieldName = "Password";
            this.col_EmployeePass.Name = "col_EmployeePass";
            this.col_EmployeePass.Width = 79;
            // 
            // col_OffWork
            // 
            this.col_OffWork.Caption = "Nghỉ việc";
            this.col_OffWork.ColumnEdit = this.ref_OffWork;
            this.col_OffWork.FieldName = "OffWork";
            this.col_OffWork.Name = "col_OffWork";
            // 
            // ref_OffWork
            // 
            this.ref_OffWork.AutoHeight = false;
            this.ref_OffWork.DisplayValueChecked = "1";
            this.ref_OffWork.DisplayValueGrayed = "0";
            this.ref_OffWork.DisplayValueUnchecked = "0";
            this.ref_OffWork.Name = "ref_OffWork";
            this.ref_OffWork.ValueChecked = 1;
            this.ref_OffWork.ValueGrayed = 0;
            this.ref_OffWork.ValueUnchecked = 0;
            // 
            // col_DepartmentCode
            // 
            this.col_DepartmentCode.Caption = "Phòng";
            this.col_DepartmentCode.ColumnEdit = this.ref_Department;
            this.col_DepartmentCode.FieldName = "DepartmentCode";
            this.col_DepartmentCode.Name = "col_DepartmentCode";
            // 
            // ref_Department
            // 
            this.ref_Department.AutoHeight = false;
            this.ref_Department.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Department.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", "Mã phòng", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Tên phòng")});
            this.ref_Department.Name = "ref_Department";
            this.ref_Department.NullText = "...";
            // 
            // pnTemplate
            // 
            this.pnTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTemplate.Location = new System.Drawing.Point(0, 0);
            this.pnTemplate.Name = "pnTemplate";
            this.pnTemplate.Panel1.Controls.Add(this.grListEmployee);
            this.pnTemplate.Panel1.Text = "Panel1";
            this.pnTemplate.Panel2.Controls.Add(this.grDetails);
            this.pnTemplate.Panel2.Text = "Panel2";
            this.pnTemplate.Size = new System.Drawing.Size(1011, 595);
            this.pnTemplate.SplitterPosition = 393;
            this.pnTemplate.TabIndex = 5;
            this.pnTemplate.Text = "splitContainerControl1";
            // 
            // frmLimitForService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 595);
            this.Controls.Add(this.pnTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLimitForService";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo mẫu mô tả dùng cho siêu âm, x-quang,nọi soi...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLimitForService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Ser_Chon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grListEmployee)).EndInit();
            this.grListEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_OffWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTemplate)).EndInit();
            this.pnTemplate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraEditors.GroupControl grListEmployee;
        private DevExpress.XtraEditors.SplitContainerControl pnTemplate;
        private DevExpress.XtraGrid.GridControl gridControl_Service;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Service;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Chon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_Ser_Chon;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ser_ServiceGroupName;
        private DevExpress.XtraGrid.GridControl gridControl_Employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Employee_Sex;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_status_sex;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeMobile;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeIDCard;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeBirthday;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeePosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_status_position;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeeUsername;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmployeePass;
        private DevExpress.XtraGrid.Columns.GridColumn col_OffWork;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ref_OffWork;
        private DevExpress.XtraGrid.Columns.GridColumn col_DepartmentCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_Department;
        private DevExpress.XtraEditors.CheckEdit chkAll;

    }
}