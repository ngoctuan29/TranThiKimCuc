namespace Ps.Clinic.Statistics
{
    partial class frmBangKeThuocTuTruc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangKeThuocTuTruc));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            this.toDate = new DevExpress.XtraEditors.DateEdit();
            this.frmDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tab01 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tab02 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_ResultDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView_ResultDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tab01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            this.tab02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ResultDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ResultDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.butPrint);
            this.grMain.Controls.Add(this.butCount);
            this.grMain.Controls.Add(this.toDate);
            this.grMain.Controls.Add(this.frmDate);
            this.grMain.Controls.Add(this.labelControl3);
            this.grMain.Controls.Add(this.lkupKho);
            this.grMain.Controls.Add(this.labelControl1);
            this.grMain.Controls.Add(this.labelControl2);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(220, 526);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Bảng kê chi tiết thuốc bệnh nhân";
            // 
            // butPrint
            // 
            this.butPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.butPrint.Appearance.Options.UseForeColor = true;
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(150, 94);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(68, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "Excel";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butCount
            // 
            this.butCount.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.butCount.Appearance.Options.UseForeColor = true;
            this.butCount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(62, 94);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(82, 23);
            this.butCount.TabIndex = 4;
            this.butCount.Text = "Lấy dữ liệu";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // toDate
            // 
            this.toDate.EditValue = null;
            this.toDate.Location = new System.Drawing.Point(62, 68);
            this.toDate.Name = "toDate";
            this.toDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.toDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDate.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.toDate.Size = new System.Drawing.Size(156, 20);
            this.toDate.TabIndex = 11;
            // 
            // frmDate
            // 
            this.frmDate.EditValue = null;
            this.frmDate.Location = new System.Drawing.Point(62, 46);
            this.frmDate.Name = "frmDate";
            this.frmDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.frmDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.frmDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.frmDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.frmDate.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.frmDate.Size = new System.Drawing.Size(156, 20);
            this.frmDate.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl3.Location = new System.Drawing.Point(5, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Đến ngày :";
            // 
            // lkupKho
            // 
            this.lkupKho.Location = new System.Drawing.Point(62, 24);
            this.lkupKho.Name = "lkupKho";
            this.lkupKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupKho.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryCode", "Mã kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryName", "Tên kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Hide", "Hide", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepositoryGroupCode", "GroupCode", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lkupKho.Properties.NullText = "Chọn Kho";
            this.lkupKho.Size = new System.Drawing.Size(156, 20);
            this.lkupKho.TabIndex = 10;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Location = new System.Drawing.Point(35, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kho :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.Location = new System.Drawing.Point(12, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Từ ngày :";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tab01;
            this.tabMain.Size = new System.Drawing.Size(774, 526);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tab01,
            this.tab02});
            // 
            // tab01
            // 
            this.tab01.Controls.Add(this.gridControl_Result);
            this.tab01.Name = "tab01";
            this.tab01.Size = new System.Drawing.Size(768, 498);
            this.tab01.Text = "Thống kê tổng hợp";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Result.MainView = this.gridView_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(768, 498);
            this.gridControl_Result.TabIndex = 1;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Result});
            // 
            // gridView_Result
            // 
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsFind.AlwaysVisible = true;
            this.gridView_Result.OptionsFind.FindFilterColumns = "PatientCode";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            // 
            // tab02
            // 
            this.tab02.Controls.Add(this.gridControl_ResultDetail);
            this.tab02.Name = "tab02";
            this.tab02.Size = new System.Drawing.Size(768, 498);
            this.tab02.Text = "Thống kê chi tiết thuốc";
            // 
            // gridControl_ResultDetail
            // 
            this.gridControl_ResultDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ResultDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ResultDetail.MainView = this.gridView_ResultDetail;
            this.gridControl_ResultDetail.Name = "gridControl_ResultDetail";
            this.gridControl_ResultDetail.Size = new System.Drawing.Size(768, 498);
            this.gridControl_ResultDetail.TabIndex = 0;
            this.gridControl_ResultDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ResultDetail});
            // 
            // gridView_ResultDetail
            // 
            this.gridView_ResultDetail.GridControl = this.gridControl_ResultDetail;
            this.gridView_ResultDetail.Name = "gridView_ResultDetail";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grMain);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tabMain);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(999, 526);
            this.splitContainerControl1.SplitterPosition = 220;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmBangKeThuocTuTruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 526);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBangKeThuocTuTruc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo nhập xuất tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBangKeThuocTuTruc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tab01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            this.tab02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ResultDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ResultDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit frmDate;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tab01;
        private DevExpress.XtraTab.XtraTabPage tab02;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraEditors.DateEdit toDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gridControl_ResultDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ResultDetail;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}