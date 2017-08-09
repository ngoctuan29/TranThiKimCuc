namespace Ps.Clinic.Master
{
    partial class frmVungRang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVungRang));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Area_Tooth = new DevExpress.XtraGrid.GridControl();
            this.gridView_Area_Tooth = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Area_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Area_Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_Color = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Area_Tooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Area_Tooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Color)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.gridControl_Area_Tooth);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(1008, 562);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh sách khai báo vùng răng";
            // 
            // gridControl_Area_Tooth
            // 
            this.gridControl_Area_Tooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Area_Tooth.Location = new System.Drawing.Point(2, 20);
            this.gridControl_Area_Tooth.MainView = this.gridView_Area_Tooth;
            this.gridControl_Area_Tooth.Name = "gridControl_Area_Tooth";
            this.gridControl_Area_Tooth.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_Color});
            this.gridControl_Area_Tooth.Size = new System.Drawing.Size(1004, 540);
            this.gridControl_Area_Tooth.TabIndex = 0;
            this.gridControl_Area_Tooth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Area_Tooth});
            // 
            // gridView_Area_Tooth
            // 
            this.gridView_Area_Tooth.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Area_Name,
            this.col_Area_Color});
            this.gridView_Area_Tooth.GridControl = this.gridControl_Area_Tooth;
            this.gridView_Area_Tooth.Name = "gridView_Area_Tooth";
            this.gridView_Area_Tooth.NewItemRowText = "Nhập thêm mới vùng mô tả răng!";
            this.gridView_Area_Tooth.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Area_Tooth.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Area_Tooth.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Area_Tooth.OptionsView.ShowFooter = true;
            this.gridView_Area_Tooth.OptionsView.ShowGroupPanel = false;
            this.gridView_Area_Tooth.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_Area_Tooth_BeforeLeaveRow);
            // 
            // col_Area_Name
            // 
            this.col_Area_Name.Caption = "Mô tả vùng răng";
            this.col_Area_Name.FieldName = "Area_Name";
            this.col_Area_Name.Name = "col_Area_Name";
            this.col_Area_Name.Visible = true;
            this.col_Area_Name.VisibleIndex = 0;
            // 
            // col_Area_Color
            // 
            this.col_Area_Color.Caption = "Chỉ thị màu";
            this.col_Area_Color.ColumnEdit = this.ref_Color;
            this.col_Area_Color.FieldName = "Color";
            this.col_Area_Color.Name = "col_Area_Color";
            this.col_Area_Color.Visible = true;
            this.col_Area_Color.VisibleIndex = 1;
            this.col_Area_Color.Width = 353;
            // 
            // ref_Color
            // 
            this.ref_Color.AutoHeight = false;
            this.ref_Color.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_Color.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ref_Color.Name = "ref_Color";
            this.ref_Color.StoreColorAsInteger = true;
            // 
            // frmVungRang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVungRang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Mô tả vùng răng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVungRang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Area_Tooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Area_Tooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_Color)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Area_Tooth;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Area_Tooth;
        private DevExpress.XtraGrid.Columns.GridColumn col_Area_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_Area_Color;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit ref_Color;
    }
}