namespace Ps.Clinic.Entry
{
    partial class frmBangDienInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangDienInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Result_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_DepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repchk_Result_Chon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_Result_Chon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 32);
            this.panel1.TabIndex = 1;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(145, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(104, 23);
            this.btnShow.TabIndex = 1019;
            this.btnShow.TabStop = false;
            this.btnShow.Text = "Màn Hình LCD";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl_Data);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 254);
            this.panel2.TabIndex = 2;
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repchk_Result_Chon});
            this.gridControl_Data.Size = new System.Drawing.Size(377, 254);
            this.gridControl_Data.TabIndex = 1;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            // 
            // gridView_Data
            // 
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Result_DepartmentName,
            this.col_Result_DepartmentCode,
            this.col_Result_Chon});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            // 
            // col_Result_DepartmentName
            // 
            this.col_Result_DepartmentName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Result_DepartmentName.AppearanceHeader.Options.UseFont = true;
            this.col_Result_DepartmentName.Caption = "Phòng khám";
            this.col_Result_DepartmentName.FieldName = "DepartmentName";
            this.col_Result_DepartmentName.Name = "col_Result_DepartmentName";
            this.col_Result_DepartmentName.OptionsColumn.AllowEdit = false;
            this.col_Result_DepartmentName.OptionsColumn.AllowFocus = false;
            this.col_Result_DepartmentName.OptionsColumn.ReadOnly = true;
            this.col_Result_DepartmentName.Visible = true;
            this.col_Result_DepartmentName.VisibleIndex = 0;
            this.col_Result_DepartmentName.Width = 315;
            // 
            // col_Result_DepartmentCode
            // 
            this.col_Result_DepartmentCode.Caption = "DepartmentCode";
            this.col_Result_DepartmentCode.FieldName = "DepartmentCode";
            this.col_Result_DepartmentCode.Name = "col_Result_DepartmentCode";
            // 
            // col_Result_Chon
            // 
            this.col_Result_Chon.AppearanceCell.Options.UseTextOptions = true;
            this.col_Result_Chon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Result_Chon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Result_Chon.AppearanceHeader.Options.UseFont = true;
            this.col_Result_Chon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Result_Chon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Result_Chon.Caption = "Chọn";
            this.col_Result_Chon.ColumnEdit = this.repchk_Result_Chon;
            this.col_Result_Chon.FieldName = "Chon";
            this.col_Result_Chon.Name = "col_Result_Chon";
            this.col_Result_Chon.Visible = true;
            this.col_Result_Chon.VisibleIndex = 1;
            this.col_Result_Chon.Width = 55;
            // 
            // repchk_Result_Chon
            // 
            this.repchk_Result_Chon.AutoHeight = false;
            this.repchk_Result_Chon.DisplayValueChecked = "1";
            this.repchk_Result_Chon.DisplayValueGrayed = "0";
            this.repchk_Result_Chon.DisplayValueUnchecked = "0";
            this.repchk_Result_Chon.Name = "repchk_Result_Chon";
            this.repchk_Result_Chon.ValueChecked = 1;
            this.repchk_Result_Chon.ValueGrayed = 0;
            this.repchk_Result_Chon.ValueUnchecked = 0;
            // 
            // frmBangDienInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 286);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBangDienInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Phòng Khám Hiển Thị";
            this.Load += new System.EventHandler(this.frmBangDienInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchk_Result_Chon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_DepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_DepartmentCode;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result_Chon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repchk_Result_Chon;
    }
}