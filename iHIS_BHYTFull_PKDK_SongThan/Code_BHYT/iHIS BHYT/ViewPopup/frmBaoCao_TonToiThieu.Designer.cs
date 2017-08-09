namespace Ps.Clinic.ViewPopup
{
    partial class frmBaoCao_TonToiThieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao_TonToiThieu));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkWarning = new DevExpress.XtraEditors.CheckEdit();
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Safety = new DevExpress.XtraGrid.GridControl();
            this.gridView_Safety = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UsageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SafelyQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AmountDisparity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RepositoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWarning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Safety)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Safety)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkWarning);
            this.panelControl1.Controls.Add(this.lkupKho);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Controls.Add(this.butCount);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1075, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // chkWarning
            // 
            this.chkWarning.Location = new System.Drawing.Point(346, 8);
            this.chkWarning.Name = "chkWarning";
            this.chkWarning.Properties.Caption = "Tồn < Hạn mức tồn";
            this.chkWarning.Size = new System.Drawing.Size(118, 19);
            this.chkWarning.TabIndex = 1043;
            // 
            // lkupKho
            // 
            this.lkupKho.EditValue = "";
            this.lkupKho.Location = new System.Drawing.Point(44, 8);
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
            this.lkupKho.Size = new System.Drawing.Size(296, 20);
            this.lkupKho.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Kho :";
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(542, 6);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(75, 23);
            this.butPrint.TabIndex = 1;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butCount
            // 
            this.butCount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(466, 6);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(75, 23);
            this.butCount.TabIndex = 0;
            this.butCount.Text = "Tổng hợp";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // gridControl_Safety
            // 
            this.gridControl_Safety.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Safety.Location = new System.Drawing.Point(0, 33);
            this.gridControl_Safety.MainView = this.gridView_Safety;
            this.gridControl_Safety.Name = "gridControl_Safety";
            this.gridControl_Safety.Size = new System.Drawing.Size(1075, 381);
            this.gridControl_Safety.TabIndex = 1;
            this.gridControl_Safety.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Safety});
            // 
            // gridView_Safety
            // 
            this.gridView_Safety.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemCategoryName,
            this.col_ItemCode,
            this.col_ItemName,
            this.col_UsageName,
            this.col_UnitOfMeasureName,
            this.col_AmountEnd,
            this.col_SafelyQuantity,
            this.col_AmountDisparity,
            this.col_RepositoryName,
            this.col_GroupName});
            this.gridView_Safety.GridControl = this.gridControl_Safety;
            this.gridView_Safety.GroupPanelText = "Nhóm dữ liệu";
            this.gridView_Safety.Name = "gridView_Safety";
            this.gridView_Safety.OptionsBehavior.Editable = false;
            this.gridView_Safety.OptionsView.ColumnAutoWidth = false;
            this.gridView_Safety.OptionsView.ShowFooter = true;
            this.gridView_Safety.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_Safety_RowStyle);
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemCategoryName.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCategoryName.Caption = "Loại thuốc";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 0;
            this.col_ItemCategoryName.Width = 165;
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemCode.AppearanceHeader.Options.UseFont = true;
            this.col_ItemCode.Caption = "Mã thuốc";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.Visible = true;
            this.col_ItemCode.VisibleIndex = 1;
            this.col_ItemCode.Width = 126;
            // 
            // col_ItemName
            // 
            this.col_ItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ItemName.AppearanceHeader.Options.UseFont = true;
            this.col_ItemName.Caption = "Tên thuốc";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 2;
            this.col_ItemName.Width = 253;
            // 
            // col_UsageName
            // 
            this.col_UsageName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UsageName.AppearanceHeader.Options.UseFont = true;
            this.col_UsageName.Caption = "Đường dùng";
            this.col_UsageName.FieldName = "UsageName";
            this.col_UsageName.Name = "col_UsageName";
            this.col_UsageName.Visible = true;
            this.col_UsageName.VisibleIndex = 3;
            this.col_UsageName.Width = 154;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseFont = true;
            this.col_UnitOfMeasureName.Caption = "Đơn vị tính";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 4;
            this.col_UnitOfMeasureName.Width = 77;
            // 
            // col_AmountEnd
            // 
            this.col_AmountEnd.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_AmountEnd.AppearanceHeader.Options.UseFont = true;
            this.col_AmountEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountEnd.Caption = "Tồn cuối";
            this.col_AmountEnd.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountEnd.FieldName = "AmountEnd";
            this.col_AmountEnd.Name = "col_AmountEnd";
            this.col_AmountEnd.Visible = true;
            this.col_AmountEnd.VisibleIndex = 5;
            this.col_AmountEnd.Width = 96;
            // 
            // col_SafelyQuantity
            // 
            this.col_SafelyQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_SafelyQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SafelyQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SafelyQuantity.AppearanceHeader.Options.UseFont = true;
            this.col_SafelyQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SafelyQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SafelyQuantity.Caption = "Tối thiểu";
            this.col_SafelyQuantity.DisplayFormat.FormatString = "#,#.##";
            this.col_SafelyQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SafelyQuantity.FieldName = "SafelyQuantity";
            this.col_SafelyQuantity.Name = "col_SafelyQuantity";
            this.col_SafelyQuantity.Visible = true;
            this.col_SafelyQuantity.VisibleIndex = 6;
            this.col_SafelyQuantity.Width = 95;
            // 
            // col_AmountDisparity
            // 
            this.col_AmountDisparity.AppearanceCell.Options.UseTextOptions = true;
            this.col_AmountDisparity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountDisparity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_AmountDisparity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_AmountDisparity.Caption = "Chênh lệch";
            this.col_AmountDisparity.DisplayFormat.FormatString = "#,#.##";
            this.col_AmountDisparity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_AmountDisparity.FieldName = "AmountDisparity";
            this.col_AmountDisparity.Name = "col_AmountDisparity";
            this.col_AmountDisparity.UnboundExpression = "[Ton] - [TonToiThieu]";
            this.col_AmountDisparity.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_AmountDisparity.Width = 83;
            // 
            // col_RepositoryName
            // 
            this.col_RepositoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RepositoryName.AppearanceHeader.Options.UseFont = true;
            this.col_RepositoryName.Caption = "Kho";
            this.col_RepositoryName.FieldName = "RepositoryName";
            this.col_RepositoryName.Name = "col_RepositoryName";
            this.col_RepositoryName.Visible = true;
            this.col_RepositoryName.VisibleIndex = 7;
            this.col_RepositoryName.Width = 111;
            // 
            // col_GroupName
            // 
            this.col_GroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_GroupName.AppearanceHeader.Options.UseFont = true;
            this.col_GroupName.Caption = "Nhóm thuốc";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 8;
            this.col_GroupName.Width = 216;
            // 
            // frmBaoCao_TonToiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 414);
            this.Controls.Add(this.gridControl_Safety);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao_TonToiThieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cảnh báo hạn mức tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWarning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Safety)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Safety)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_Safety;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Safety;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UsageName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountEnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_SafelyQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_AmountDisparity;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositoryName;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraEditors.CheckEdit chkWarning;
    }
}