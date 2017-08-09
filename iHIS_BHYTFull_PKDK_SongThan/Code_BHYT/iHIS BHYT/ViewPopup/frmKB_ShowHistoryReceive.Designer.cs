namespace Ps.Clinic.ViewPopup
{
    partial class frmKB_ShowHistoryReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKB_ShowHistoryReceive));
            this.groupInfo = new DevExpress.XtraEditors.GroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl_History = new DevExpress.XtraGrid.GridControl();
            this.gridView_History = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHistory_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistory_Title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistory_Info = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistory_RefID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistory_OutDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistory_EmployeeNameDoctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistory_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repchk_Status = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNote_Content = new DevExpress.XtraEditors.LabelControl();
            this.lbNote = new DevExpress.XtraEditors.LabelControl();
            this.butClosed = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).BeginInit();
            this.groupInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_Status)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInfo
            // 
            this.groupInfo.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupInfo.CaptionImage")));
            this.groupInfo.Controls.Add(this.panel2);
            this.groupInfo.Controls.Add(this.panel1);
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInfo.Location = new System.Drawing.Point(0, 0);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(694, 323);
            this.groupInfo.TabIndex = 1016;
            this.groupInfo.Text = "Bệnh Nhân Tiếp Nhận Nhiều Lần Trong Ngày:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl_History);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 234);
            this.panel2.TabIndex = 1016;
            // 
            // gridControl_History
            // 
            this.gridControl_History.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_History.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_History.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.gridControl_History.Location = new System.Drawing.Point(0, 0);
            this.gridControl_History.MainView = this.gridView_History;
            this.gridControl_History.Name = "gridControl_History";
            this.gridControl_History.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repchk_Status});
            this.gridControl_History.Size = new System.Drawing.Size(690, 234);
            this.gridControl_History.TabIndex = 41;
            this.gridControl_History.TabStop = false;
            this.gridControl_History.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_History});
            // 
            // gridView_History
            // 
            this.gridView_History.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHistory_PatientCode,
            this.colHistory_Title,
            this.colHistory_Info,
            this.colHistory_RefID,
            this.colHistory_OutDate,
            this.colHistory_EmployeeNameDoctor,
            this.colHistory_Status});
            this.gridView_History.GridControl = this.gridControl_History;
            this.gridView_History.Name = "gridView_History";
            this.gridView_History.NewItemRowText = "Chọn dịch vụ chỉ định";
            this.gridView_History.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_History.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_History.OptionsBehavior.Editable = false;
            this.gridView_History.OptionsCustomization.AllowSort = false;
            this.gridView_History.OptionsFind.ShowFindButton = false;
            this.gridView_History.OptionsView.ShowGroupPanel = false;
            this.gridView_History.OptionsView.ShowIndicator = false;
            this.gridView_History.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_History_RowStyle);
            this.gridView_History.DoubleClick += new System.EventHandler(this.gridView_History_DoubleClick);
            // 
            // colHistory_PatientCode
            // 
            this.colHistory_PatientCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHistory_PatientCode.AppearanceHeader.Options.UseFont = true;
            this.colHistory_PatientCode.Caption = "PatientCode";
            this.colHistory_PatientCode.FieldName = "PatientCode";
            this.colHistory_PatientCode.Name = "colHistory_PatientCode";
            this.colHistory_PatientCode.OptionsColumn.AllowEdit = false;
            this.colHistory_PatientCode.OptionsColumn.AllowFocus = false;
            this.colHistory_PatientCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colHistory_PatientCode.OptionsColumn.AllowMove = false;
            this.colHistory_PatientCode.OptionsColumn.ReadOnly = true;
            this.colHistory_PatientCode.OptionsColumn.TabStop = false;
            this.colHistory_PatientCode.OptionsFilter.AllowAutoFilter = false;
            this.colHistory_PatientCode.OptionsFilter.AllowFilter = false;
            this.colHistory_PatientCode.Width = 320;
            // 
            // colHistory_Title
            // 
            this.colHistory_Title.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHistory_Title.AppearanceHeader.Options.UseFont = true;
            this.colHistory_Title.Caption = "Ngày vào";
            this.colHistory_Title.FieldName = "Title";
            this.colHistory_Title.Name = "colHistory_Title";
            this.colHistory_Title.OptionsColumn.AllowEdit = false;
            this.colHistory_Title.OptionsColumn.AllowFocus = false;
            this.colHistory_Title.OptionsColumn.ReadOnly = true;
            this.colHistory_Title.OptionsColumn.TabStop = false;
            this.colHistory_Title.Visible = true;
            this.colHistory_Title.VisibleIndex = 0;
            this.colHistory_Title.Width = 152;
            // 
            // colHistory_Info
            // 
            this.colHistory_Info.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHistory_Info.AppearanceHeader.Options.UseFont = true;
            this.colHistory_Info.Caption = "Phòng khám";
            this.colHistory_Info.FieldName = "Info";
            this.colHistory_Info.Name = "colHistory_Info";
            this.colHistory_Info.OptionsColumn.AllowEdit = false;
            this.colHistory_Info.OptionsColumn.AllowFocus = false;
            this.colHistory_Info.OptionsColumn.AllowMove = false;
            this.colHistory_Info.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colHistory_Info.OptionsColumn.FixedWidth = true;
            this.colHistory_Info.OptionsColumn.ReadOnly = true;
            this.colHistory_Info.OptionsColumn.TabStop = false;
            this.colHistory_Info.OptionsFilter.AllowAutoFilter = false;
            this.colHistory_Info.OptionsFilter.AllowFilter = false;
            this.colHistory_Info.Visible = true;
            this.colHistory_Info.VisibleIndex = 1;
            this.colHistory_Info.Width = 168;
            // 
            // colHistory_RefID
            // 
            this.colHistory_RefID.Caption = "RefID";
            this.colHistory_RefID.FieldName = "RefID";
            this.colHistory_RefID.Name = "colHistory_RefID";
            // 
            // colHistory_OutDate
            // 
            this.colHistory_OutDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHistory_OutDate.AppearanceHeader.Options.UseFont = true;
            this.colHistory_OutDate.Caption = "Ngày Ra";
            this.colHistory_OutDate.FieldName = "OutDate";
            this.colHistory_OutDate.Name = "colHistory_OutDate";
            this.colHistory_OutDate.OptionsColumn.AllowEdit = false;
            this.colHistory_OutDate.OptionsColumn.AllowFocus = false;
            this.colHistory_OutDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colHistory_OutDate.OptionsColumn.FixedWidth = true;
            this.colHistory_OutDate.OptionsColumn.ReadOnly = true;
            this.colHistory_OutDate.OptionsColumn.TabStop = false;
            this.colHistory_OutDate.OptionsFilter.AllowAutoFilter = false;
            this.colHistory_OutDate.OptionsFilter.AllowFilter = false;
            this.colHistory_OutDate.Visible = true;
            this.colHistory_OutDate.VisibleIndex = 3;
            this.colHistory_OutDate.Width = 118;
            // 
            // colHistory_EmployeeNameDoctor
            // 
            this.colHistory_EmployeeNameDoctor.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHistory_EmployeeNameDoctor.AppearanceHeader.Options.UseFont = true;
            this.colHistory_EmployeeNameDoctor.Caption = "BS. Khám";
            this.colHistory_EmployeeNameDoctor.FieldName = "EmployeeNameDoctor";
            this.colHistory_EmployeeNameDoctor.Name = "colHistory_EmployeeNameDoctor";
            this.colHistory_EmployeeNameDoctor.OptionsColumn.AllowEdit = false;
            this.colHistory_EmployeeNameDoctor.OptionsColumn.AllowFocus = false;
            this.colHistory_EmployeeNameDoctor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colHistory_EmployeeNameDoctor.OptionsColumn.FixedWidth = true;
            this.colHistory_EmployeeNameDoctor.OptionsColumn.ReadOnly = true;
            this.colHistory_EmployeeNameDoctor.OptionsColumn.TabStop = false;
            this.colHistory_EmployeeNameDoctor.Visible = true;
            this.colHistory_EmployeeNameDoctor.VisibleIndex = 2;
            this.colHistory_EmployeeNameDoctor.Width = 189;
            // 
            // colHistory_Status
            // 
            this.colHistory_Status.AppearanceCell.Options.UseTextOptions = true;
            this.colHistory_Status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHistory_Status.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHistory_Status.AppearanceHeader.Options.UseFont = true;
            this.colHistory_Status.AppearanceHeader.Options.UseTextOptions = true;
            this.colHistory_Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHistory_Status.Caption = "Kết H.Sơ";
            this.colHistory_Status.ColumnEdit = this.repchk_Status;
            this.colHistory_Status.FieldName = "Status";
            this.colHistory_Status.Name = "colHistory_Status";
            this.colHistory_Status.OptionsColumn.AllowEdit = false;
            this.colHistory_Status.OptionsColumn.AllowFocus = false;
            this.colHistory_Status.OptionsColumn.ReadOnly = true;
            this.colHistory_Status.Visible = true;
            this.colHistory_Status.VisibleIndex = 4;
            this.colHistory_Status.Width = 61;
            // 
            // repchk_Status
            // 
            this.repchk_Status.AutoHeight = false;
            this.repchk_Status.DisplayValueChecked = "1";
            this.repchk_Status.DisplayValueGrayed = "0";
            this.repchk_Status.DisplayValueUnchecked = "0";
            this.repchk_Status.Name = "repchk_Status";
            this.repchk_Status.ValueChecked = 1;
            this.repchk_Status.ValueGrayed = 0;
            this.repchk_Status.ValueUnchecked = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbNote_Content);
            this.panel1.Controls.Add(this.lbNote);
            this.panel1.Controls.Add(this.butClosed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 64);
            this.panel1.TabIndex = 1015;
            // 
            // lbNote_Content
            // 
            this.lbNote_Content.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbNote_Content.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lbNote_Content.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lbNote_Content.Location = new System.Drawing.Point(61, 14);
            this.lbNote_Content.Name = "lbNote_Content";
            this.lbNote_Content.Size = new System.Drawing.Size(420, 17);
            this.lbNote_Content.TabIndex = 1015;
            this.lbNote_Content.Text = "Có thể chọn lại đợt điều trị tiếp tục khám chữa bệnh cho bệnh nhân.";
            // 
            // lbNote
            // 
            this.lbNote.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbNote.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbNote.Location = new System.Drawing.Point(7, 13);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(48, 19);
            this.lbNote.TabIndex = 1015;
            this.lbNote.Text = "Lưu Ý:";
            // 
            // butClosed
            // 
            this.butClosed.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butClosed.Image = ((System.Drawing.Image)(resources.GetObject("butClosed.Image")));
            this.butClosed.Location = new System.Drawing.Point(596, 28);
            this.butClosed.Name = "butClosed";
            this.butClosed.Size = new System.Drawing.Size(82, 31);
            this.butClosed.TabIndex = 4;
            this.butClosed.Text = "Thoát";
            this.butClosed.Click += new System.EventHandler(this.butClosed_Click);
            // 
            // frmKB_ShowHistoryReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 323);
            this.Controls.Add(this.groupInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKB_ShowHistoryReceive";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phòng khám.";
            this.Load += new System.EventHandler(this.frmKB_ShowHistoryReceive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).EndInit();
            this.groupInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_Status)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton butClosed;
        private DevExpress.XtraEditors.GroupControl groupInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl_History;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_History;
        private DevExpress.XtraGrid.Columns.GridColumn colHistory_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn colHistory_Title;
        private DevExpress.XtraGrid.Columns.GridColumn colHistory_Info;
        private DevExpress.XtraGrid.Columns.GridColumn colHistory_RefID;
        private DevExpress.XtraGrid.Columns.GridColumn colHistory_OutDate;
        private DevExpress.XtraGrid.Columns.GridColumn colHistory_EmployeeNameDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn colHistory_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repchk_Status;
        private DevExpress.XtraEditors.LabelControl lbNote_Content;
        private DevExpress.XtraEditors.LabelControl lbNote;
    }
}