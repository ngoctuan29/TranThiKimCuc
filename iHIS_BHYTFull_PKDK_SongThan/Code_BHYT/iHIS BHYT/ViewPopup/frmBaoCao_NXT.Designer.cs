namespace Ps.Clinic.ViewPopup
{
    partial class frmBaoCao_NXT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao_NXT));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.txtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            this.txtToDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Item_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Item_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Unit_Of_Measure_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DauKi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Nhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Xuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CuoiKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.txtFromDate);
            this.grMain.Controls.Add(this.labelControl1);
            this.grMain.Controls.Add(this.butPrint);
            this.grMain.Controls.Add(this.butCount);
            this.grMain.Controls.Add(this.txtToDate);
            this.grMain.Controls.Add(this.labelControl2);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(213, 526);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Thông số";
            // 
            // txtFromDate
            // 
            this.txtFromDate.EditValue = null;
            this.txtFromDate.Location = new System.Drawing.Point(67, 24);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFromDate.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtFromDate.Size = new System.Drawing.Size(141, 20);
            this.txtFromDate.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày :";
            // 
            // butPrint
            // 
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(163, 76);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(45, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butCount
            // 
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(67, 76);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(90, 23);
            this.butCount.TabIndex = 4;
            this.butCount.Text = "Lấy dữ liệu";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // txtToDate
            // 
            this.txtToDate.EditValue = null;
            this.txtToDate.Location = new System.Drawing.Point(67, 50);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtToDate.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtToDate.Size = new System.Drawing.Size(141, 20);
            this.txtToDate.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Đến ngày :";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(2, 20);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(777, 504);
            this.gridControl_Result.TabIndex = 1;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Item_Code,
            this.col_Item_Name,
            this.col_Unit_Of_Measure_Name,
            this.col_DauKi,
            this.col_Nhap,
            this.col_Xuat,
            this.col_CuoiKy});
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsView.ShowFooter = true;
            // 
            // col_Item_Code
            // 
            this.col_Item_Code.Caption = "Mã thuốc";
            this.col_Item_Code.FieldName = "Item Code";
            this.col_Item_Code.Name = "col_Item_Code";
            this.col_Item_Code.Visible = true;
            this.col_Item_Code.VisibleIndex = 0;
            this.col_Item_Code.Width = 73;
            // 
            // col_Item_Name
            // 
            this.col_Item_Name.Caption = "Tên thuốc - vtyt";
            this.col_Item_Name.FieldName = "Item Name";
            this.col_Item_Name.Name = "col_Item_Name";
            this.col_Item_Name.Visible = true;
            this.col_Item_Name.VisibleIndex = 1;
            this.col_Item_Name.Width = 412;
            // 
            // col_Unit_Of_Measure_Name
            // 
            this.col_Unit_Of_Measure_Name.AppearanceCell.Options.UseTextOptions = true;
            this.col_Unit_Of_Measure_Name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Unit_Of_Measure_Name.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Unit_Of_Measure_Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Unit_Of_Measure_Name.Caption = "ĐVT";
            this.col_Unit_Of_Measure_Name.FieldName = "Unit Of Measure Name";
            this.col_Unit_Of_Measure_Name.Name = "col_Unit_Of_Measure_Name";
            this.col_Unit_Of_Measure_Name.Visible = true;
            this.col_Unit_Of_Measure_Name.VisibleIndex = 2;
            this.col_Unit_Of_Measure_Name.Width = 73;
            // 
            // col_DauKi
            // 
            this.col_DauKi.AppearanceCell.Options.UseTextOptions = true;
            this.col_DauKi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_DauKi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DauKi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_DauKi.Caption = "Tồn đầu";
            this.col_DauKi.DisplayFormat.FormatString = "#,#";
            this.col_DauKi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_DauKi.FieldName = "DauKi";
            this.col_DauKi.Name = "col_DauKi";
            this.col_DauKi.Visible = true;
            this.col_DauKi.VisibleIndex = 3;
            this.col_DauKi.Width = 115;
            // 
            // col_Nhap
            // 
            this.col_Nhap.AppearanceCell.Options.UseTextOptions = true;
            this.col_Nhap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Nhap.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Nhap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Nhap.Caption = "Nhập";
            this.col_Nhap.DisplayFormat.FormatString = "#,#";
            this.col_Nhap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Nhap.FieldName = "Nhap";
            this.col_Nhap.Name = "col_Nhap";
            this.col_Nhap.Visible = true;
            this.col_Nhap.VisibleIndex = 4;
            this.col_Nhap.Width = 105;
            // 
            // col_Xuat
            // 
            this.col_Xuat.AppearanceCell.Options.UseTextOptions = true;
            this.col_Xuat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Xuat.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Xuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Xuat.Caption = "Xuất";
            this.col_Xuat.DisplayFormat.FormatString = "#,#";
            this.col_Xuat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Xuat.FieldName = "Xuat";
            this.col_Xuat.Name = "col_Xuat";
            this.col_Xuat.Visible = true;
            this.col_Xuat.VisibleIndex = 5;
            this.col_Xuat.Width = 92;
            // 
            // col_CuoiKy
            // 
            this.col_CuoiKy.AppearanceCell.Options.UseTextOptions = true;
            this.col_CuoiKy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_CuoiKy.AppearanceHeader.Options.UseTextOptions = true;
            this.col_CuoiKy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_CuoiKy.Caption = "Tồn cuối";
            this.col_CuoiKy.DisplayFormat.FormatString = "#,#";
            this.col_CuoiKy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_CuoiKy.FieldName = "CuoiKy";
            this.col_CuoiKy.Name = "col_CuoiKy";
            this.col_CuoiKy.UnboundExpression = "[DauKi] + [Nhap] - [Xuat]";
            this.col_CuoiKy.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_CuoiKy.Visible = true;
            this.col_CuoiKy.VisibleIndex = 6;
            this.col_CuoiKy.Width = 109;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grMain);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(999, 526);
            this.splitContainerControl1.SplitterPosition = 213;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl_Result);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(781, 526);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Dữ liệu";
            // 
            // frmBaoCao_NXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 526);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao_NXT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo nhập xuất tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtToDate;
        private DevExpress.XtraEditors.DateEdit txtFromDate;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraGrid.Columns.GridColumn col_Item_Code;
        private DevExpress.XtraGrid.Columns.GridColumn col_Item_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_Unit_Of_Measure_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_DauKi;
        private DevExpress.XtraGrid.Columns.GridColumn col_Nhap;
        private DevExpress.XtraGrid.Columns.GridColumn col_Xuat;
        private DevExpress.XtraGrid.Columns.GridColumn col_CuoiKy;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}