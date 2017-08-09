namespace Ps.Clinic.Master
{
    partial class frmVP_DMNhomIn
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
            this.gridControl_nhomIn = new DevExpress.XtraGrid.GridControl();
            this.gridView_nhomIn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_print_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_print_TenNhomIn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_nhomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_nhomIn)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_nhomIn
            // 
            this.gridControl_nhomIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_nhomIn.Location = new System.Drawing.Point(0, 0);
            this.gridControl_nhomIn.MainView = this.gridView_nhomIn;
            this.gridControl_nhomIn.Name = "gridControl_nhomIn";
            this.gridControl_nhomIn.Size = new System.Drawing.Size(1127, 576);
            this.gridControl_nhomIn.TabIndex = 0;
            this.gridControl_nhomIn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_nhomIn});
            this.gridControl_nhomIn.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_nhomIn_ProcessGridKey);
            // 
            // gridView_nhomIn
            // 
            this.gridView_nhomIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_print_ID,
            this.col_print_TenNhomIn});
            this.gridView_nhomIn.GridControl = this.gridControl_nhomIn;
            this.gridView_nhomIn.Name = "gridView_nhomIn";
            this.gridView_nhomIn.NewItemRowText = "Thêm mới danh mục nhóm in";
            this.gridView_nhomIn.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_nhomIn.OptionsView.ShowGroupPanel = false;
            this.gridView_nhomIn.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_nhomIn_ValidateRow);
            // 
            // col_print_ID
            // 
            this.col_print_ID.AppearanceCell.Options.UseTextOptions = true;
            this.col_print_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_print_ID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_print_ID.AppearanceHeader.Options.UseFont = true;
            this.col_print_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_print_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_print_ID.Caption = "ID";
            this.col_print_ID.FieldName = "ID";
            this.col_print_ID.Name = "col_print_ID";
            this.col_print_ID.OptionsColumn.AllowEdit = false;
            this.col_print_ID.OptionsColumn.AllowFocus = false;
            this.col_print_ID.OptionsColumn.ReadOnly = true;
            this.col_print_ID.Visible = true;
            this.col_print_ID.VisibleIndex = 0;
            this.col_print_ID.Width = 97;
            // 
            // col_print_TenNhomIn
            // 
            this.col_print_TenNhomIn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_print_TenNhomIn.AppearanceHeader.Options.UseFont = true;
            this.col_print_TenNhomIn.AppearanceHeader.Options.UseTextOptions = true;
            this.col_print_TenNhomIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_print_TenNhomIn.Caption = "Tên nhóm in";
            this.col_print_TenNhomIn.FieldName = "GroupName";
            this.col_print_TenNhomIn.Name = "col_print_TenNhomIn";
            this.col_print_TenNhomIn.Visible = true;
            this.col_print_TenNhomIn.VisibleIndex = 1;
            this.col_print_TenNhomIn.Width = 1012;
            // 
            // frmDMNhomIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 576);
            this.Controls.Add(this.gridControl_nhomIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDMNhomIn";
            this.Text = "frmDMNhomIn";
            this.Load += new System.EventHandler(this.frmVP_DMNhomIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_nhomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_nhomIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_nhomIn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_nhomIn;
        private DevExpress.XtraGrid.Columns.GridColumn col_print_ID;
        private DevExpress.XtraGrid.Columns.GridColumn col_print_TenNhomIn;
    }
}