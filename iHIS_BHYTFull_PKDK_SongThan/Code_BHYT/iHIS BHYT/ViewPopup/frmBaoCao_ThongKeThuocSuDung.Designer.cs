namespace Ps.Clinic.ViewPopup
{
    partial class frmBaoCao_ThongKeThuocSuDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao_ThongKeThuocSuDung));
            this.gridControl_result = new DevExpress.XtraGrid.GridControl();
            this.gridView_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_DateApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitOfMeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TotalQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refItemCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.refUOM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.refItem = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butOk = new DevExpress.XtraEditors.SimpleButton();
            this.txtTo = new DevExpress.XtraEditors.DateEdit();
            this.txtFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refItemCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_result
            // 
            this.gridControl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_result.Location = new System.Drawing.Point(2, 20);
            this.gridControl_result.MainView = this.gridView_result;
            this.gridControl_result.Name = "gridControl_result";
            this.gridControl_result.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refItemCategory,
            this.refUOM,
            this.refItem});
            this.gridControl_result.Size = new System.Drawing.Size(798, 573);
            this.gridControl_result.TabIndex = 2;
            this.gridControl_result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_result});
            // 
            // gridView_result
            // 
            this.gridView_result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_DateApproved,
            this.col_ItemCategoryName,
            this.col_ItemCode,
            this.col_UnitOfMeasureName,
            this.col_UnitPrice,
            this.col_TotalQuantity,
            this.col_ItemName});
            this.gridView_result.GridControl = this.gridControl_result;
            this.gridView_result.GroupPanelText = "Nhóm dữ liệu !";
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.OptionsView.ShowFooter = true;
            // 
            // col_DateApproved
            // 
            this.col_DateApproved.AppearanceCell.Options.UseTextOptions = true;
            this.col_DateApproved.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DateApproved.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DateApproved.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DateApproved.Caption = "Ngày cấp";
            this.col_DateApproved.FieldName = "DateApproved";
            this.col_DateApproved.Name = "col_DateApproved";
            this.col_DateApproved.Visible = true;
            this.col_DateApproved.VisibleIndex = 0;
            this.col_DateApproved.Width = 107;
            // 
            // col_ItemCategoryName
            // 
            this.col_ItemCategoryName.Caption = "Phân loại";
            this.col_ItemCategoryName.FieldName = "ItemCategoryName";
            this.col_ItemCategoryName.Name = "col_ItemCategoryName";
            this.col_ItemCategoryName.Visible = true;
            this.col_ItemCategoryName.VisibleIndex = 6;
            this.col_ItemCategoryName.Width = 112;
            // 
            // col_ItemCode
            // 
            this.col_ItemCode.Caption = "Mã thuốc";
            this.col_ItemCode.FieldName = "ItemCode";
            this.col_ItemCode.Name = "col_ItemCode";
            this.col_ItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_ItemCode.Visible = true;
            this.col_ItemCode.VisibleIndex = 1;
            this.col_ItemCode.Width = 84;
            // 
            // col_UnitOfMeasureName
            // 
            this.col_UnitOfMeasureName.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitOfMeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_UnitOfMeasureName.Caption = "ĐVT";
            this.col_UnitOfMeasureName.FieldName = "UnitOfMeasureName";
            this.col_UnitOfMeasureName.Name = "col_UnitOfMeasureName";
            this.col_UnitOfMeasureName.Visible = true;
            this.col_UnitOfMeasureName.VisibleIndex = 3;
            this.col_UnitOfMeasureName.Width = 65;
            // 
            // col_UnitPrice
            // 
            this.col_UnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.col_UnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_UnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_UnitPrice.Caption = "Đơn giá";
            this.col_UnitPrice.DisplayFormat.FormatString = "#,#";
            this.col_UnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_UnitPrice.FieldName = "UnitPrice";
            this.col_UnitPrice.Name = "col_UnitPrice";
            this.col_UnitPrice.Visible = true;
            this.col_UnitPrice.VisibleIndex = 4;
            this.col_UnitPrice.Width = 108;
            // 
            // col_TotalQuantity
            // 
            this.col_TotalQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.col_TotalQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_TotalQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TotalQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_TotalQuantity.Caption = "Số lượng";
            this.col_TotalQuantity.DisplayFormat.FormatString = "#,#";
            this.col_TotalQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_TotalQuantity.FieldName = "TotalQuantity";
            this.col_TotalQuantity.Name = "col_TotalQuantity";
            this.col_TotalQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:c0}")});
            this.col_TotalQuantity.Visible = true;
            this.col_TotalQuantity.VisibleIndex = 5;
            this.col_TotalQuantity.Width = 82;
            // 
            // col_ItemName
            // 
            this.col_ItemName.Caption = "Tên thuốc";
            this.col_ItemName.FieldName = "ItemName";
            this.col_ItemName.Name = "col_ItemName";
            this.col_ItemName.Visible = true;
            this.col_ItemName.VisibleIndex = 2;
            this.col_ItemName.Width = 99;
            // 
            // refItemCategory
            // 
            this.refItemCategory.AutoHeight = false;
            this.refItemCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.refItemCategory.Name = "refItemCategory";
            this.refItemCategory.NullText = "...";
            // 
            // refUOM
            // 
            this.refUOM.AutoHeight = false;
            this.refUOM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.refUOM.Name = "refUOM";
            this.refUOM.NullText = "...";
            // 
            // refItem
            // 
            this.refItem.AutoHeight = false;
            this.refItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.refItem.Name = "refItem";
            this.refItem.NullText = "...";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.butPrint);
            this.groupControl1.Controls.Add(this.butOk);
            this.groupControl1.Controls.Add(this.txtTo);
            this.groupControl1.Controls.Add(this.txtFrom);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(218, 595);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Thông số";
            // 
            // butPrint
            // 
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(154, 81);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(58, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.Location = new System.Drawing.Point(65, 81);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(85, 23);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "Lấy số liệu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // txtTo
            // 
            this.txtTo.EditValue = null;
            this.txtTo.Location = new System.Drawing.Point(65, 55);
            this.txtTo.Name = "txtTo";
            this.txtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTo.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtTo.Size = new System.Drawing.Size(147, 20);
            this.txtTo.TabIndex = 3;
            // 
            // txtFrom
            // 
            this.txtFrom.EditValue = null;
            this.txtFrom.Location = new System.Drawing.Point(65, 33);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFrom.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtFrom.Size = new System.Drawing.Size(147, 20);
            this.txtFrom.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Dến ngày :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày :";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl_result);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(802, 595);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Dữ liệu";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1025, 595);
            this.splitContainerControl1.SplitterPosition = 218;
            this.splitContainerControl1.TabIndex = 7;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmBaoCao_ThongKeThuocSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 595);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao_ThongKeThuocSuDung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê tình hình sử dụng thuốc.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaoCao_ThongKeThuocSuDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refItemCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_result;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitOfMeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn col_UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_TotalQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCategoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit refItemCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit refItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit refUOM;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_DateApproved;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtTo;
        private DevExpress.XtraEditors.DateEdit txtFrom;
        private DevExpress.XtraEditors.SimpleButton butOk;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraGrid.Columns.GridColumn col_ItemName;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}