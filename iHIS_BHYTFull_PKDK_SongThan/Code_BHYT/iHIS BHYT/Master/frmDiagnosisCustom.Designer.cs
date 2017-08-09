namespace Ps.Clinic.Master
{
    partial class frmDiagnosisCustom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiagnosisCustom));
            this.gridControl_List = new DevExpress.XtraGrid.GridControl();
            this.gridView_List = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DiagnosisName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_List
            // 
            this.gridControl_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_List.Location = new System.Drawing.Point(0, 0);
            this.gridControl_List.MainView = this.gridView_List;
            this.gridControl_List.Name = "gridControl_List";
            this.gridControl_List.Size = new System.Drawing.Size(738, 506);
            this.gridControl_List.TabIndex = 2;
            this.gridControl_List.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_List});
            this.gridControl_List.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_List_ProcessGridKey);
            // 
            // gridView_List
            // 
            this.gridView_List.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_List.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_List.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_List.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_List.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_List.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_List.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_List.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_DiagnosisName});
            this.gridView_List.GridControl = this.gridControl_List;
            this.gridView_List.Name = "gridView_List";
            this.gridView_List.NewItemRowText = "Thêm chẩn đoán bệnh";
            this.gridView_List.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_List.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_List.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_List.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_List.OptionsView.ShowFooter = true;
            this.gridView_List.OptionsView.ShowGroupPanel = false;
            this.gridView_List.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_List_InvalidRowException);
            this.gridView_List.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_List_ValidateRow);
            // 
            // col_RowID
            // 
            this.col_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.Caption = "Mã";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.AllowEdit = false;
            this.col_RowID.OptionsColumn.AllowSize = false;
            this.col_RowID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CareerCode", "Count: {0:#,#}")});
            this.col_RowID.Visible = true;
            this.col_RowID.VisibleIndex = 0;
            this.col_RowID.Width = 84;
            // 
            // col_DiagnosisName
            // 
            this.col_DiagnosisName.Caption = "Tên chẩn đoán";
            this.col_DiagnosisName.FieldName = "DiagnosisName";
            this.col_DiagnosisName.Name = "col_DiagnosisName";
            this.col_DiagnosisName.Visible = true;
            this.col_DiagnosisName.VisibleIndex = 1;
            this.col_DiagnosisName.Width = 922;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(738, 37);
            this.panelControl1.TabIndex = 3;
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butPrint.Appearance.Options.UseForeColor = true;
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(638, 5);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(97, 28);
            this.butPrint.TabIndex = 9;
            this.butPrint.Text = "In danh sách";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gridControl_List);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 37);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(738, 506);
            this.panelControl2.TabIndex = 4;
            // 
            // frmDiagnosisCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 543);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiagnosisCustom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh sách đơn vị tính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDiagnosisCustom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_List;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_List;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_DiagnosisName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton butPrint;
    }
}