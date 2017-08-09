namespace Ps.Clinic.Master
{
    partial class frmNhomVienPhiBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhomVienPhiBHYT));
            this.gridControl_ServiceGroup = new DevExpress.XtraGrid.GridControl();
            this.gridView_ServiceGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_GroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_Abbreviations = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_ServiceModule = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ServiceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ServiceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceModule)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ServiceGroup
            // 
            this.gridControl_ServiceGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_ServiceGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ServiceGroup.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ServiceGroup.MainView = this.gridView_ServiceGroup;
            this.gridControl_ServiceGroup.Name = "gridControl_ServiceGroup";
            this.gridControl_ServiceGroup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_ServiceModule,
            this.rep_Hide});
            this.gridControl_ServiceGroup.Size = new System.Drawing.Size(1024, 600);
            this.gridControl_ServiceGroup.TabIndex = 1;
            this.gridControl_ServiceGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ServiceGroup});
            this.gridControl_ServiceGroup.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_ServiceGroup_ProcessGridKey);
            // 
            // gridView_ServiceGroup
            // 
            this.gridView_ServiceGroup.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_ServiceGroup.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_ServiceGroup.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_ServiceGroup.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_ServiceGroup.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_ServiceGroup.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_ServiceGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_GroupID,
            this.col_STT,
            this.col_GroupName,
            this.col_Hide,
            this.col_Abbreviations,
            this.col_IDate});
            this.gridView_ServiceGroup.GridControl = this.gridControl_ServiceGroup;
            this.gridView_ServiceGroup.Name = "gridView_ServiceGroup";
            this.gridView_ServiceGroup.NewItemRowText = "Thêm mới nhóm BHYT ...";
            this.gridView_ServiceGroup.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_ServiceGroup.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_ServiceGroup.OptionsView.ShowFooter = true;
            this.gridView_ServiceGroup.OptionsView.ShowGroupPanel = false;
            this.gridView_ServiceGroup.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ServiceGroup_ValidateRow);
            // 
            // col_GroupID
            // 
            this.col_GroupID.AppearanceCell.Options.UseTextOptions = true;
            this.col_GroupID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GroupID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_GroupID.AppearanceHeader.Options.UseFont = true;
            this.col_GroupID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GroupID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GroupID.Caption = "Mã nhóm";
            this.col_GroupID.FieldName = "GroupID";
            this.col_GroupID.Name = "col_GroupID";
            this.col_GroupID.OptionsColumn.ReadOnly = true;
            this.col_GroupID.Visible = true;
            this.col_GroupID.VisibleIndex = 0;
            this.col_GroupID.Width = 64;
            // 
            // col_STT
            // 
            this.col_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_STT.AppearanceHeader.Options.UseFont = true;
            this.col_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.Caption = "STT";
            this.col_STT.FieldName = "STT";
            this.col_STT.Name = "col_STT";
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 3;
            this.col_STT.Width = 34;
            // 
            // col_GroupName
            // 
            this.col_GroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_GroupName.AppearanceHeader.Options.UseFont = true;
            this.col_GroupName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GroupName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GroupName.Caption = "Tên nhóm";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 1;
            this.col_GroupName.Width = 704;
            // 
            // col_Hide
            // 
            this.col_Hide.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Hide.AppearanceHeader.Options.UseFont = true;
            this.col_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.Caption = "Khóa";
            this.col_Hide.ColumnEdit = this.rep_Hide;
            this.col_Hide.FieldName = "Hide";
            this.col_Hide.Name = "col_Hide";
            this.col_Hide.Visible = true;
            this.col_Hide.VisibleIndex = 4;
            this.col_Hide.Width = 49;
            // 
            // rep_Hide
            // 
            this.rep_Hide.AutoHeight = false;
            this.rep_Hide.DisplayValueChecked = "1";
            this.rep_Hide.DisplayValueGrayed = "0";
            this.rep_Hide.DisplayValueUnchecked = "0";
            this.rep_Hide.Name = "rep_Hide";
            this.rep_Hide.ValueChecked = 1;
            this.rep_Hide.ValueGrayed = 0;
            this.rep_Hide.ValueUnchecked = 0;
            // 
            // col_Abbreviations
            // 
            this.col_Abbreviations.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Abbreviations.AppearanceHeader.Options.UseFont = true;
            this.col_Abbreviations.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Abbreviations.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Abbreviations.Caption = "Viết tắt";
            this.col_Abbreviations.FieldName = "Abbreviations";
            this.col_Abbreviations.Name = "col_Abbreviations";
            this.col_Abbreviations.Visible = true;
            this.col_Abbreviations.VisibleIndex = 2;
            this.col_Abbreviations.Width = 155;
            // 
            // col_IDate
            // 
            this.col_IDate.Caption = "IDate";
            this.col_IDate.FieldName = "IDate";
            this.col_IDate.Name = "col_IDate";
            // 
            // rep_ServiceModule
            // 
            this.rep_ServiceModule.AutoHeight = false;
            this.rep_ServiceModule.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_ServiceModule.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceModuleCode", "Mã Phân hệ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceModuleName", "Tên phân hệ")});
            this.rep_ServiceModule.Name = "rep_ServiceModule";
            this.rep_ServiceModule.NullText = "...";
            // 
            // frmNhomVienPhiBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.gridControl_ServiceGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhomVienPhiBHYT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục nhóm viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhomVienPhiBHYT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ServiceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ServiceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ServiceGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ServiceGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_ServiceModule;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupID;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_Hide;
        private DevExpress.XtraGrid.Columns.GridColumn col_Abbreviations;
        private DevExpress.XtraGrid.Columns.GridColumn col_IDate;
    }
}