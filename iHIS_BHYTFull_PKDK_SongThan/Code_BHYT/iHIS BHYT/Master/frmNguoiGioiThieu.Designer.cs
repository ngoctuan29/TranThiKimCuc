namespace Ps.Clinic.Master
{
    partial class frmNguoiGioiThieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNguoiGioiThieu));
            this.gridControl_NguoiGT = new DevExpress.XtraGrid.GridControl();
            this.gridView_NguoiGT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_IntroCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IntroName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_status_sex = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Mobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IDCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Birthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Career = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Career = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_NguoiGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_NguoiGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Career)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_NguoiGT
            // 
            this.gridControl_NguoiGT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_NguoiGT.Location = new System.Drawing.Point(0, 0);
            this.gridControl_NguoiGT.MainView = this.gridView_NguoiGT;
            this.gridControl_NguoiGT.Name = "gridControl_NguoiGT";
            this.gridControl_NguoiGT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_status_sex,
            this.ref_Career});
            this.gridControl_NguoiGT.Size = new System.Drawing.Size(706, 444);
            this.gridControl_NguoiGT.TabIndex = 2;
            this.gridControl_NguoiGT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_NguoiGT});
            this.gridControl_NguoiGT.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_NguoiGT_ProcessGridKey);
            // 
            // gridView_NguoiGT
            // 
            this.gridView_NguoiGT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_IntroCode,
            this.col_IntroName,
            this.col_Sex,
            this.col_Mobile,
            this.col_IDCard,
            this.col_Address,
            this.col_Birthday,
            this.col_Career,
            this.col_Note});
            this.gridView_NguoiGT.GridControl = this.gridControl_NguoiGT;
            this.gridView_NguoiGT.Name = "gridView_NguoiGT";
            this.gridView_NguoiGT.NewItemRowText = "Thêm mới nhân viên sử dụng phần mềm";
            this.gridView_NguoiGT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_NguoiGT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_NguoiGT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_NguoiGT.OptionsView.ShowGroupPanel = false;
            this.gridView_NguoiGT.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_NguoiGT_InvalidRowException);
            this.gridView_NguoiGT.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_NguoiGT_ValidateRow);
            // 
            // col_IntroCode
            // 
            this.col_IntroCode.Caption = "Mã";
            this.col_IntroCode.FieldName = "IntroCode";
            this.col_IntroCode.Name = "col_IntroCode";
            this.col_IntroCode.OptionsColumn.AllowEdit = false;
            this.col_IntroCode.OptionsColumn.AllowFocus = false;
            this.col_IntroCode.OptionsColumn.ReadOnly = true;
            // 
            // col_IntroName
            // 
            this.col_IntroName.Caption = "Họ tên";
            this.col_IntroName.FieldName = "IntroName";
            this.col_IntroName.Name = "col_IntroName";
            this.col_IntroName.Visible = true;
            this.col_IntroName.VisibleIndex = 0;
            this.col_IntroName.Width = 150;
            // 
            // col_Sex
            // 
            this.col_Sex.AppearanceCell.Options.UseTextOptions = true;
            this.col_Sex.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sex.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sex.Caption = "Giới tính";
            this.col_Sex.ColumnEdit = this.ref_status_sex;
            this.col_Sex.FieldName = "Sex";
            this.col_Sex.Name = "col_Sex";
            this.col_Sex.Visible = true;
            this.col_Sex.VisibleIndex = 1;
            this.col_Sex.Width = 47;
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
            // col_Mobile
            // 
            this.col_Mobile.Caption = "Điện thoại";
            this.col_Mobile.FieldName = "Mobile";
            this.col_Mobile.Name = "col_Mobile";
            this.col_Mobile.Visible = true;
            this.col_Mobile.VisibleIndex = 2;
            this.col_Mobile.Width = 67;
            // 
            // col_IDCard
            // 
            this.col_IDCard.Caption = "TAX/CMND";
            this.col_IDCard.FieldName = "IDCard";
            this.col_IDCard.Name = "col_IDCard";
            this.col_IDCard.Visible = true;
            this.col_IDCard.VisibleIndex = 3;
            this.col_IDCard.Width = 67;
            // 
            // col_Address
            // 
            this.col_Address.Caption = "Địa chỉ";
            this.col_Address.FieldName = "Address";
            this.col_Address.Name = "col_Address";
            this.col_Address.Visible = true;
            this.col_Address.VisibleIndex = 4;
            this.col_Address.Width = 67;
            // 
            // col_Birthday
            // 
            this.col_Birthday.AppearanceCell.Options.UseTextOptions = true;
            this.col_Birthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Birthday.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Birthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Birthday.Caption = "Ngày sinh";
            this.col_Birthday.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_Birthday.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_Birthday.FieldName = "Birthday";
            this.col_Birthday.Name = "col_Birthday";
            this.col_Birthday.Visible = true;
            this.col_Birthday.VisibleIndex = 5;
            this.col_Birthday.Width = 67;
            // 
            // col_Career
            // 
            this.col_Career.Caption = "Nghề nghiệp";
            this.col_Career.ColumnEdit = this.ref_Career;
            this.col_Career.FieldName = "CareerCode";
            this.col_Career.Name = "col_Career";
            this.col_Career.Visible = true;
            this.col_Career.VisibleIndex = 6;
            // 
            // ref_Career
            // 
            this.ref_Career.AutoHeight = false;
            this.ref_Career.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Career.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CareerCode", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CareerName", "Nghề nghiệp")});
            this.ref_Career.Name = "ref_Career";
            this.ref_Career.NullText = "...";
            // 
            // col_Note
            // 
            this.col_Note.Caption = "Ghi chú";
            this.col_Note.FieldName = "Note";
            this.col_Note.Name = "col_Note";
            this.col_Note.Visible = true;
            this.col_Note.VisibleIndex = 7;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(706, 37);
            this.panelControl1.TabIndex = 4;
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(606, 5);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(97, 28);
            this.butPrint.TabIndex = 9;
            this.butPrint.Text = "In danh sách";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gridControl_NguoiGT);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 37);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(706, 444);
            this.panelControl2.TabIndex = 5;
            // 
            // frmNguoiGioiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 481);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNguoiGioiThieu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh sách đơn vị tính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNguoiGioiThieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_NguoiGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_NguoiGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_status_sex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Career)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_NguoiGT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_NguoiGT;
        private DevExpress.XtraGrid.Columns.GridColumn col_IntroCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_IntroName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sex;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_status_sex;
        private DevExpress.XtraGrid.Columns.GridColumn col_Mobile;
        private DevExpress.XtraGrid.Columns.GridColumn col_IDCard;
        private DevExpress.XtraGrid.Columns.GridColumn col_Address;
        private DevExpress.XtraGrid.Columns.GridColumn col_Birthday;
        private DevExpress.XtraGrid.Columns.GridColumn col_Career;
        private DevExpress.XtraGrid.Columns.GridColumn col_Note;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_Career;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.PanelControl panelControl2;

    }
}