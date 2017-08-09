namespace Ps.Clinic.Master
{
    partial class frmRang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRang));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_tooth = new DevExpress.XtraGrid.GridControl();
            this.gridView_tooth = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_tooth_rowid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tooth_Tooth_Category_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tooth_Tooth_Category_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_tooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_tooth)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.gridControl_tooth);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(1008, 562);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh sách mô tả hàm răng";
            // 
            // gridControl_tooth
            // 
            this.gridControl_tooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_tooth.Location = new System.Drawing.Point(2, 20);
            this.gridControl_tooth.MainView = this.gridView_tooth;
            this.gridControl_tooth.Name = "gridControl_tooth";
            this.gridControl_tooth.Size = new System.Drawing.Size(1004, 540);
            this.gridControl_tooth.TabIndex = 0;
            this.gridControl_tooth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_tooth});
            // 
            // gridView_tooth
            // 
            this.gridView_tooth.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_tooth_rowid,
            this.col_tooth_Tooth_Category_Code,
            this.col_tooth_Tooth_Category_Name});
            this.gridView_tooth.GridControl = this.gridControl_tooth;
            this.gridView_tooth.Name = "gridView_tooth";
            this.gridView_tooth.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_tooth.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_tooth.OptionsView.ShowFooter = true;
            this.gridView_tooth.OptionsView.ShowGroupPanel = false;
            this.gridView_tooth.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_tooth_BeforeLeaveRow);
            // 
            // col_tooth_rowid
            // 
            this.col_tooth_rowid.Caption = "RowID";
            this.col_tooth_rowid.FieldName = "RowID";
            this.col_tooth_rowid.Name = "col_tooth_rowid";
            // 
            // col_tooth_Tooth_Category_Code
            // 
            this.col_tooth_Tooth_Category_Code.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_tooth_Tooth_Category_Code.AppearanceCell.Options.UseFont = true;
            this.col_tooth_Tooth_Category_Code.AppearanceCell.Options.UseTextOptions = true;
            this.col_tooth_Tooth_Category_Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_tooth_Tooth_Category_Code.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_tooth_Tooth_Category_Code.AppearanceHeader.Options.UseFont = true;
            this.col_tooth_Tooth_Category_Code.AppearanceHeader.Options.UseTextOptions = true;
            this.col_tooth_Tooth_Category_Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_tooth_Tooth_Category_Code.Caption = "Số thứ tự răng";
            this.col_tooth_Tooth_Category_Code.FieldName = "Tooth_Category_Code";
            this.col_tooth_Tooth_Category_Code.Name = "col_tooth_Tooth_Category_Code";
            this.col_tooth_Tooth_Category_Code.OptionsColumn.AllowEdit = false;
            this.col_tooth_Tooth_Category_Code.OptionsColumn.AllowFocus = false;
            this.col_tooth_Tooth_Category_Code.OptionsColumn.ReadOnly = true;
            this.col_tooth_Tooth_Category_Code.Visible = true;
            this.col_tooth_Tooth_Category_Code.VisibleIndex = 0;
            this.col_tooth_Tooth_Category_Code.Width = 134;
            // 
            // col_tooth_Tooth_Category_Name
            // 
            this.col_tooth_Tooth_Category_Name.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_tooth_Tooth_Category_Name.AppearanceCell.Options.UseFont = true;
            this.col_tooth_Tooth_Category_Name.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_tooth_Tooth_Category_Name.AppearanceHeader.Options.UseFont = true;
            this.col_tooth_Tooth_Category_Name.Caption = "Tên mô tả răng";
            this.col_tooth_Tooth_Category_Name.FieldName = "Tooth_Category_Name";
            this.col_tooth_Tooth_Category_Name.Name = "col_tooth_Tooth_Category_Name";
            this.col_tooth_Tooth_Category_Name.Visible = true;
            this.col_tooth_Tooth_Category_Name.VisibleIndex = 1;
            this.col_tooth_Tooth_Category_Name.Width = 854;
            // 
            // frmRang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách mô rả hàm răng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_tooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_tooth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_tooth;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_tooth;
        private DevExpress.XtraGrid.Columns.GridColumn col_tooth_rowid;
        private DevExpress.XtraGrid.Columns.GridColumn col_tooth_Tooth_Category_Code;
        private DevExpress.XtraGrid.Columns.GridColumn col_tooth_Tooth_Category_Name;
    }
}