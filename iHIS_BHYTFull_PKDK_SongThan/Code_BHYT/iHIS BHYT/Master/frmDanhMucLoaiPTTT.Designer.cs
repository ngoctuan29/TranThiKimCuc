namespace Ps.Clinic.Master
{
    partial class frmDanhMucLoaiPTTT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucLoaiPTTT));
            this.gridControl_Advice = new DevExpress.XtraGrid.GridControl();
            this.gridView_Advice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaPT_TT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpcheck_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Advice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Advice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpcheck_Hide)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Advice
            // 
            this.gridControl_Advice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Advice.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Advice.MainView = this.gridView_Advice;
            this.gridControl_Advice.Name = "gridControl_Advice";
            this.gridControl_Advice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpcheck_Hide});
            this.gridControl_Advice.Size = new System.Drawing.Size(612, 289);
            this.gridControl_Advice.TabIndex = 2;
            this.gridControl_Advice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Advice});
            // 
            // gridView_Advice
            // 
            this.gridView_Advice.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Advice.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.gridView_Advice.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Advice.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView_Advice.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Advice.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Advice.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Advice.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Advice.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Advice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaPT_TT,
            this.col_Ten,
            this.col_IDate,
            this.col_Hide});
            this.gridView_Advice.GridControl = this.gridControl_Advice;
            this.gridView_Advice.Name = "gridView_Advice";
            this.gridView_Advice.NewItemRowText = "Nhập thêm mới loại TT-PT ...";
            this.gridView_Advice.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Advice.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Advice.OptionsView.ShowFooter = true;
            this.gridView_Advice.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaPT_TT
            // 
            this.col_MaPT_TT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MaPT_TT.AppearanceHeader.Options.UseFont = true;
            this.col_MaPT_TT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_MaPT_TT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_MaPT_TT.Caption = "Mã PT - TT";
            this.col_MaPT_TT.FieldName = "MaPT_TT";
            this.col_MaPT_TT.Name = "col_MaPT_TT";
            this.col_MaPT_TT.Visible = true;
            this.col_MaPT_TT.VisibleIndex = 0;
            this.col_MaPT_TT.Width = 79;
            // 
            // col_Ten
            // 
            this.col_Ten.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Ten.AppearanceHeader.Options.UseFont = true;
            this.col_Ten.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Ten.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Ten.Caption = "Tên loại TT - PT";
            this.col_Ten.FieldName = "Ten";
            this.col_Ten.Name = "col_Ten";
            this.col_Ten.Visible = true;
            this.col_Ten.VisibleIndex = 1;
            this.col_Ten.Width = 467;
            // 
            // col_IDate
            // 
            this.col_IDate.Caption = "IDate";
            this.col_IDate.FieldName = "IDate";
            this.col_IDate.Name = "col_IDate";
            // 
            // col_Hide
            // 
            this.col_Hide.AppearanceCell.Options.UseTextOptions = true;
            this.col_Hide.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Hide.AppearanceHeader.Options.UseFont = true;
            this.col_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.Caption = "Khóa";
            this.col_Hide.ColumnEdit = this.rpcheck_Hide;
            this.col_Hide.FieldName = "Hide";
            this.col_Hide.Name = "col_Hide";
            this.col_Hide.Visible = true;
            this.col_Hide.VisibleIndex = 2;
            this.col_Hide.Width = 50;
            // 
            // rpcheck_Hide
            // 
            this.rpcheck_Hide.AutoHeight = false;
            this.rpcheck_Hide.DisplayValueChecked = "1";
            this.rpcheck_Hide.DisplayValueGrayed = "0";
            this.rpcheck_Hide.DisplayValueUnchecked = "0";
            this.rpcheck_Hide.Name = "rpcheck_Hide";
            this.rpcheck_Hide.ValueChecked = 1;
            this.rpcheck_Hide.ValueGrayed = 0;
            this.rpcheck_Hide.ValueUnchecked = 0;
            // 
            // frmDanhMucLoaiPTTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 289);
            this.Controls.Add(this.gridControl_Advice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucLoaiPTTT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh mục lời dặn bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhMucLoaiPTTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Advice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Advice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpcheck_Hide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Advice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Advice;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaPT_TT;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ten;
        private DevExpress.XtraGrid.Columns.GridColumn col_IDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpcheck_Hide;
    }
}