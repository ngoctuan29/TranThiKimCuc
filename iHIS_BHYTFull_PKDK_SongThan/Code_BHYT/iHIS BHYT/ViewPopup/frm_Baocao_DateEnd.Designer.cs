namespace Ps.Clinic.ViewPopup
{
    partial class frm_Baocao_DateEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Baocao_DateEnd));
            this.lkupKho = new DevExpress.XtraEditors.LookUpEdit();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butCount = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl_DateEnd = new DevExpress.XtraGrid.GridControl();
            this.gridView_DateEnd = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UsageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RepositoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Shipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lkupKho
            // 
            this.lkupKho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupKho.Location = new System.Drawing.Point(40, 24);
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
            this.lkupKho.Size = new System.Drawing.Size(135, 20);
            this.lkupKho.TabIndex = 12;
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(116, 46);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(59, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butCount
            // 
            this.butCount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butCount.Image = ((System.Drawing.Image)(resources.GetObject("butCount.Image")));
            this.butCount.Location = new System.Drawing.Point(40, 46);
            this.butCount.Name = "butCount";
            this.butCount.Size = new System.Drawing.Size(75, 23);
            this.butCount.TabIndex = 4;
            this.butCount.Text = "Tổng hợp";
            this.butCount.Click += new System.EventHandler(this.butCount_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(10, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Kho :";
            // 
            // gridControl_DateEnd
            // 
            this.gridControl_DateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DateEnd.Location = new System.Drawing.Point(2, 20);
            this.gridControl_DateEnd.MainView = this.gridView_DateEnd;
            this.gridControl_DateEnd.Name = "gridControl_DateEnd";
            this.gridControl_DateEnd.Size = new System.Drawing.Size(893, 393);
            this.gridControl_DateEnd.TabIndex = 1;
            this.gridControl_DateEnd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DateEnd});
            // 
            // gridView_DateEnd
            // 
            this.gridView_DateEnd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ItemCategoryName,
            this.col_ItemCode,
            this.col_ItemName,
            this.col_UsageName,
            this.col_UnitOfMeasureName,
            this.col_DateEnd,
            this.col_RepositoryName,
            this.col_GroupName,
            this.col_Shipment});
            this.gridView_DateEnd.GridControl = this.gridControl_DateEnd;
            this.gridView_DateEnd.GroupPanelText = "Nhóm dữ liệu";
            this.gridView_DateEnd.Name = "gridView_DateEnd";
            this.gridView_DateEnd.OptionsFind.AlwaysVisible = true;
            this.gridView_DateEnd.OptionsFind.FindFilterColumns = "ItemName";
            this.gridView_DateEnd.OptionsView.ColumnAutoWidth = false;
            this.gridView_DateEnd.OptionsView.ShowFooter = true;
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.Caption = "Phân loại";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.OptionsColumn.AllowEdit = false;
            this.col_ItemCategoryName.OptionsColumn.ReadOnly = true;
            this.col_ItemCategoryName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 1;
            this.col_ItemCategoryName.Width = 195;
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.Caption = "Mã";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.OptionsColumn.AllowEdit = false;
            this.col_ItemCode.OptionsColumn.ReadOnly = true;
            this.col_ItemCode.Visible = true;
            this.col_ItemCode.VisibleIndex = 2;
            // 
            // col_ItemName
            // 
            this.col_ItemName.Caption = "Tên";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.OptionsColumn.AllowEdit = false;
            this.col_ItemName.OptionsColumn.ReadOnly = true;
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 3;
            this.col_ItemName.Width = 242;
            // 
            // col_UsageName
            // 
            this.col_UsageName.Caption = "Đường dùng";
            this.col_UsageName.FieldName = "UsageName";
            this.col_UsageName.Name = "col_UsageName";
            this.col_UsageName.OptionsColumn.AllowEdit = false;
            this.col_UsageName.OptionsColumn.ReadOnly = true;
            this.col_UsageName.Visible = true;
            this.col_UsageName.VisibleIndex = 4;
            this.col_UsageName.Width = 102;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.Caption = "Đơn vị tính";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.OptionsColumn.AllowEdit = false;
            this.col_UnitOfMeasureName.OptionsColumn.ReadOnly = true;
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 5;
            this.col_UnitOfMeasureName.Width = 86;
            // 
            // col_DateEnd
            // 
            this.col_DateEnd.Caption = "Hạn dùng";
            this.col_DateEnd.DisplayFormat.FormatString = "MM/yyyy";
            this.col_DateEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_DateEnd.FieldName = "DateEnd";
            this.col_DateEnd.Name = "col_DateEnd";
            this.col_DateEnd.OptionsColumn.AllowEdit = false;
            this.col_DateEnd.OptionsColumn.ReadOnly = true;
            this.col_DateEnd.Visible = true;
            this.col_DateEnd.VisibleIndex = 6;
            this.col_DateEnd.Width = 102;
            // 
            // col_RepositoryName
            // 
            this.col_RepositoryName.Caption = "Kho";
            this.col_RepositoryName.FieldName = "RepositoryName";
            this.col_RepositoryName.Name = "col_RepositoryName";
            this.col_RepositoryName.OptionsColumn.AllowEdit = false;
            this.col_RepositoryName.OptionsColumn.ReadOnly = true;
            this.col_RepositoryName.Visible = true;
            this.col_RepositoryName.VisibleIndex = 8;
            this.col_RepositoryName.Width = 121;
            // 
            // col_GroupName
            // 
            this.col_GroupName.Caption = "Nhóm";
            this.col_GroupName.FieldName = "GroupName";
            this.col_GroupName.Name = "col_GroupName";
            this.col_GroupName.OptionsColumn.AllowEdit = false;
            this.col_GroupName.OptionsColumn.AllowFocus = false;
            this.col_GroupName.OptionsColumn.ReadOnly = true;
            this.col_GroupName.Visible = true;
            this.col_GroupName.VisibleIndex = 0;
            this.col_GroupName.Width = 239;
            // 
            // col_Shipment
            // 
            this.col_Shipment.Caption = "Lô SX";
            this.col_Shipment.FieldName = "Shipment";
            this.col_Shipment.Name = "col_Shipment";
            this.col_Shipment.OptionsColumn.AllowEdit = false;
            this.col_Shipment.OptionsColumn.AllowFocus = false;
            this.col_Shipment.OptionsColumn.ReadOnly = true;
            this.col_Shipment.Visible = true;
            this.col_Shipment.VisibleIndex = 7;
            this.col_Shipment.Width = 94;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1082, 415);
            this.splitContainerControl1.SplitterPosition = 180;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lkupKho);
            this.groupControl2.Controls.Add(this.butPrint);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.butCount);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(180, 415);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Thông số";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl_DateEnd);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(897, 415);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Dữ liệu";
            // 
            // frm_Baocao_DateEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 415);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Baocao_DateEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cảnh báo thuốc gần hết hạn sử dụng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.lkupKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_DateEnd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DateEnd;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butCount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UsageName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateEnd;
        private DevExpress.XtraEditors.LookUpEdit lkupKho;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn col_RepositoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Shipment;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}