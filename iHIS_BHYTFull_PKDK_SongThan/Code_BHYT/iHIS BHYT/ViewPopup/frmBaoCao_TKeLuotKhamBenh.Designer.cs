namespace Ps.Clinic.ViewPopup
{
    partial class frmBaoCao_TKeLuotKhamBenh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao_TKeLuotKhamBenh));
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_PatientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientBirthyear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PatientMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.pnHeader = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_result
            // 
            this.gridControl_result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_result.Location = new System.Drawing.Point(2, 54);
            this.gridControl_result.MainView = this.gridView_result;
            this.gridControl_result.Name = "gridControl_result";
            this.gridControl_result.Size = new System.Drawing.Size(1003, 482);
            this.gridControl_result.TabIndex = 0;
            this.gridControl_result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_result});
            // 
            // gridView_result
            // 
            this.gridView_result.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.gridView_result.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.gridView_result.Appearance.Row.Options.UseFont = true;
            this.gridView_result.Appearance.Row.Options.UseForeColor = true;
            this.gridView_result.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView_result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_PatientCode,
            this.col_PatientName,
            this.col_PatientGender,
            this.col_PatientBirthyear,
            this.col_PatientAddress,
            this.col_PatientMobile,
            this.col_Quantity});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu !";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsView.ShowFooter = true;
            this.gridView_result.OptionsView.ShowGroupPanel = false;
            // 
            // col_PatientCode
            // 
            this.col_PatientCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_PatientCode.AppearanceHeader.Options.UseFont = true;
            this.col_PatientCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientCode.Caption = "Mã BN";
            this.col_PatientCode.FieldName = "PatientCode";
            this.col_PatientCode.Name = "col_PatientCode";
            this.col_PatientCode.OptionsColumn.AllowEdit = false;
            this.col_PatientCode.OptionsColumn.AllowFocus = false;
            this.col_PatientCode.OptionsColumn.ReadOnly = true;
            this.col_PatientCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_PatientCode.Visible = true;
            this.col_PatientCode.VisibleIndex = 0;
            this.col_PatientCode.Width = 79;
            // 
            // col_PatientName
            // 
            this.col_PatientName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_PatientName.AppearanceHeader.Options.UseFont = true;
            this.col_PatientName.Caption = "Tên bệnh nhân";
            this.col_PatientName.FieldName = "PatientName";
            this.col_PatientName.Name = "col_PatientName";
            this.col_PatientName.OptionsColumn.AllowEdit = false;
            this.col_PatientName.OptionsColumn.AllowFocus = false;
            this.col_PatientName.OptionsColumn.ReadOnly = true;
            this.col_PatientName.Visible = true;
            this.col_PatientName.VisibleIndex = 1;
            this.col_PatientName.Width = 148;
            // 
            // col_PatientGender
            // 
            this.col_PatientGender.AppearanceCell.Options.UseTextOptions = true;
            this.col_PatientGender.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientGender.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_PatientGender.AppearanceHeader.Options.UseFont = true;
            this.col_PatientGender.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientGender.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientGender.Caption = "Giới tính";
            this.col_PatientGender.FieldName = "PatientGender";
            this.col_PatientGender.Name = "col_PatientGender";
            this.col_PatientGender.OptionsColumn.AllowEdit = false;
            this.col_PatientGender.OptionsColumn.AllowFocus = false;
            this.col_PatientGender.OptionsColumn.ReadOnly = true;
            this.col_PatientGender.Visible = true;
            this.col_PatientGender.VisibleIndex = 2;
            this.col_PatientGender.Width = 54;
            // 
            // col_PatientBirthyear
            // 
            this.col_PatientBirthyear.AppearanceCell.Options.UseTextOptions = true;
            this.col_PatientBirthyear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientBirthyear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_PatientBirthyear.AppearanceHeader.Options.UseFont = true;
            this.col_PatientBirthyear.AppearanceHeader.Options.UseTextOptions = true;
            this.col_PatientBirthyear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_PatientBirthyear.Caption = "N.Sinh";
            this.col_PatientBirthyear.FieldName = "PatientBirthyear";
            this.col_PatientBirthyear.Name = "col_PatientBirthyear";
            this.col_PatientBirthyear.OptionsColumn.AllowEdit = false;
            this.col_PatientBirthyear.OptionsColumn.AllowFocus = false;
            this.col_PatientBirthyear.OptionsColumn.ReadOnly = true;
            this.col_PatientBirthyear.Visible = true;
            this.col_PatientBirthyear.VisibleIndex = 3;
            this.col_PatientBirthyear.Width = 52;
            // 
            // col_PatientAddress
            // 
            this.col_PatientAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_PatientAddress.AppearanceHeader.Options.UseFont = true;
            this.col_PatientAddress.Caption = "Địa chỉ";
            this.col_PatientAddress.FieldName = "PatientAddress";
            this.col_PatientAddress.Name = "col_PatientAddress";
            this.col_PatientAddress.OptionsColumn.AllowEdit = false;
            this.col_PatientAddress.OptionsColumn.AllowFocus = false;
            this.col_PatientAddress.OptionsColumn.ReadOnly = true;
            this.col_PatientAddress.Visible = true;
            this.col_PatientAddress.VisibleIndex = 4;
            this.col_PatientAddress.Width = 176;
            // 
            // col_PatientMobile
            // 
            this.col_PatientMobile.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_PatientMobile.AppearanceHeader.Options.UseFont = true;
            this.col_PatientMobile.Caption = "Mobile";
            this.col_PatientMobile.FieldName = "PatientMobile";
            this.col_PatientMobile.Name = "col_PatientMobile";
            this.col_PatientMobile.OptionsColumn.AllowEdit = false;
            this.col_PatientMobile.OptionsColumn.AllowFocus = false;
            this.col_PatientMobile.OptionsColumn.ReadOnly = true;
            this.col_PatientMobile.Visible = true;
            this.col_PatientMobile.VisibleIndex = 5;
            this.col_PatientMobile.Width = 76;
            // 
            // col_Quantity
            // 
            this.col_Quantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Quantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Quantity.AppearanceHeader.Options.UseFont = true;
            this.col_Quantity.Caption = "Lượt khám (tái khám)";
            this.col_Quantity.FieldName = "Quantity";
            this.col_Quantity.Name = "col_Quantity";
            this.col_Quantity.OptionsColumn.AllowEdit = false;
            this.col_Quantity.OptionsColumn.AllowFocus = false;
            this.col_Quantity.OptionsColumn.ReadOnly = true;
            this.col_Quantity.Visible = true;
            this.col_Quantity.VisibleIndex = 6;
            this.col_Quantity.Width = 117;
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butPrint.Appearance.Options.UseFont = true;
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(923, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(75, 25);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.butOK.Appearance.Options.UseFont = true;
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(837, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(85, 25);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl_result);
            this.groupControl2.Controls.Add(this.pnHeader);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1007, 538);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Danh sách bệnh nhân khám (tái khám)";
            // 
            // pnHeader
            // 
            this.pnHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnHeader.Controls.Add(this.butOK);
            this.pnHeader.Controls.Add(this.butPrint);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(2, 20);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1003, 34);
            this.pnHeader.TabIndex = 6;
            // 
            // frmBaoCao_TKeLuotKhamBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 538);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao_TKeLuotKhamBenh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê bệnh nhân khám chữa bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaoCao_TKeLuotKhamBenh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientGender;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientBirthyear;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_PatientMobile;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl pnHeader;
        private DevExpress.XtraGrid.Columns.GridColumn col_Quantity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
    }
}