namespace Ps.Clinic.Statistics
{
    partial class frm_BM05_YTTN_SKSS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BM05_YTTN_SKSS));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridVIew_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowIDTemplate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TargetName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LaMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LaMa_Detail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Check_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.lkupBM05 = new DevExpress.XtraEditors.LookUpEdit();
            this.butContinues = new DevExpress.XtraEditors.SimpleButton();
            this.controlDatetime = new UserControlDateTimes.UserControlDateTimes();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupBM05.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.Controls.Add(this.gridControl_Result);
            this.grMain.Controls.Add(this.panelControl3);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(1114, 420);
            this.grMain.TabIndex = 6;
            this.grMain.Text = "Hoạt Động Sức Khoẻ Sinh Sản";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(2, 60);
            this.gridControl_Result.MainView = this.gridVIew_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(1110, 358);
            this.gridControl_Result.TabIndex = 6;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVIew_Result});
            // 
            // gridVIew_Result
            // 
            this.gridVIew_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowIDTemplate,
            this.col_TargetName,
            this.col_Result,
            this.col_LaMa,
            this.col_LaMa_Detail,
            this.col_RowID,
            this.col_Check_});
            this.gridVIew_Result.GridControl = this.gridControl_Result;
            this.gridVIew_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridVIew_Result.Name = "gridVIew_Result";
            this.gridVIew_Result.OptionsFind.FindFilterColumns = "ItemName";
            this.gridVIew_Result.OptionsView.ShowFooter = true;
            this.gridVIew_Result.OptionsView.ShowGroupPanel = false;
            this.gridVIew_Result.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridVIew_Result_RowStyle);
            // 
            // col_RowIDTemplate
            // 
            this.col_RowIDTemplate.Caption = "RowIDTemplate";
            this.col_RowIDTemplate.FieldName = "RowIDTemplate";
            this.col_RowIDTemplate.Name = "col_RowIDTemplate";
            // 
            // col_TargetName
            // 
            this.col_TargetName.AppearanceCell.Options.UseTextOptions = true;
            this.col_TargetName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_TargetName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_TargetName.AppearanceHeader.Options.UseFont = true;
            this.col_TargetName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TargetName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TargetName.Caption = "Chỉ tiêu";
            this.col_TargetName.FieldName = "TargetName";
            this.col_TargetName.Name = "col_TargetName";
            this.col_TargetName.OptionsColumn.AllowEdit = false;
            this.col_TargetName.OptionsColumn.AllowFocus = false;
            this.col_TargetName.OptionsColumn.ReadOnly = true;
            this.col_TargetName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "TNTTName", "{0:#,#}")});
            this.col_TargetName.Visible = true;
            this.col_TargetName.VisibleIndex = 2;
            this.col_TargetName.Width = 510;
            // 
            // col_Result
            // 
            this.col_Result.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Result.AppearanceHeader.Options.UseFont = true;
            this.col_Result.Caption = "Số lượng";
            this.col_Result.DisplayFormat.FormatString = "{0:#,#}";
            this.col_Result.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Result.FieldName = "Result";
            this.col_Result.Name = "col_Result";
            this.col_Result.Visible = true;
            this.col_Result.VisibleIndex = 3;
            this.col_Result.Width = 432;
            // 
            // col_LaMa
            // 
            this.col_LaMa.AppearanceCell.Options.UseTextOptions = true;
            this.col_LaMa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LaMa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_LaMa.AppearanceHeader.Options.UseFont = true;
            this.col_LaMa.AppearanceHeader.Options.UseTextOptions = true;
            this.col_LaMa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LaMa.Caption = "Mục";
            this.col_LaMa.FieldName = "LaMa";
            this.col_LaMa.Name = "col_LaMa";
            this.col_LaMa.OptionsColumn.AllowEdit = false;
            this.col_LaMa.OptionsColumn.AllowFocus = false;
            this.col_LaMa.OptionsColumn.ReadOnly = true;
            this.col_LaMa.Visible = true;
            this.col_LaMa.VisibleIndex = 0;
            this.col_LaMa.Width = 44;
            // 
            // col_LaMa_Detail
            // 
            this.col_LaMa_Detail.AppearanceCell.Options.UseTextOptions = true;
            this.col_LaMa_Detail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LaMa_Detail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_LaMa_Detail.AppearanceHeader.Options.UseFont = true;
            this.col_LaMa_Detail.AppearanceHeader.Options.UseTextOptions = true;
            this.col_LaMa_Detail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LaMa_Detail.Caption = "STT";
            this.col_LaMa_Detail.FieldName = "LaMa_Detail";
            this.col_LaMa_Detail.Name = "col_LaMa_Detail";
            this.col_LaMa_Detail.OptionsColumn.AllowEdit = false;
            this.col_LaMa_Detail.OptionsColumn.AllowFocus = false;
            this.col_LaMa_Detail.OptionsColumn.ReadOnly = true;
            this.col_LaMa_Detail.Visible = true;
            this.col_LaMa_Detail.VisibleIndex = 1;
            this.col_LaMa_Detail.Width = 52;
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "RowID";
            this.col_RowID.FieldName = "RowID_BM05";
            this.col_RowID.Name = "col_RowID";
            // 
            // col_Check_
            // 
            this.col_Check_.Caption = "Check";
            this.col_Check_.FieldName = "Check_";
            this.col_Check_.Name = "col_Check_";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnGetData);
            this.panelControl3.Controls.Add(this.lkupBM05);
            this.panelControl3.Controls.Add(this.butContinues);
            this.panelControl3.Controls.Add(this.controlDatetime);
            this.panelControl3.Controls.Add(this.butPrint);
            this.panelControl3.Controls.Add(this.btnCancel);
            this.panelControl3.Controls.Add(this.butSave);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 20);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1110, 40);
            this.panelControl3.TabIndex = 5;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(852, 7);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(81, 23);
            this.btnGetData.TabIndex = 9;
            this.btnGetData.Text = "Lấy dữ liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lkupBM05
            // 
            this.lkupBM05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkupBM05.Location = new System.Drawing.Point(644, 9);
            this.lkupBM05.Name = "lkupBM05";
            this.lkupBM05.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupBM05.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowID", "RowID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FromDate", "FromDate", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ToDate", "ToDate", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BM05Name", 150, "Ngày báo cáo")});
            this.lkupBM05.Properties.NullText = "";
            this.lkupBM05.Size = new System.Drawing.Size(131, 20);
            this.lkupBM05.TabIndex = 8;
            this.lkupBM05.EditValueChanged += new System.EventHandler(this.lkupBM05_EditValueChanged);
            // 
            // butContinues
            // 
            this.butContinues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butContinues.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butContinues.Image = ((System.Drawing.Image)(resources.GetObject("butContinues.Image")));
            this.butContinues.Location = new System.Drawing.Point(781, 7);
            this.butContinues.Name = "butContinues";
            this.butContinues.Size = new System.Drawing.Size(71, 23);
            this.butContinues.TabIndex = 7;
            this.butContinues.Text = "Tạo mới";
            this.butContinues.Click += new System.EventHandler(this.butContinues_Click);
            // 
            // controlDatetime
            // 
            this.controlDatetime.Location = new System.Drawing.Point(3, 6);
            this.controlDatetime.Name = "controlDatetime";
            this.controlDatetime.Size = new System.Drawing.Size(635, 25);
            this.controlDatetime.TabIndex = 6;
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(1051, 7);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(55, 23);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(992, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Huỷ";
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.Location = new System.Drawing.Point(933, 7);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(59, 23);
            this.butSave.TabIndex = 4;
            this.butSave.Text = "Lưu";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // frm_BM05_YTTN_SKSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 420);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_BM05_YTTN_SKSS";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiêm vaccin dịch vụ ngoài CT.TCMR quốc gia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BM05_YTTN_SKSS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkupBM05.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVIew_Result;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private UserControlDateTimes.UserControlDateTimes controlDatetime;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowIDTemplate;
        private DevExpress.XtraGrid.Columns.GridColumn col_TargetName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Result;
        private DevExpress.XtraEditors.SimpleButton butContinues;
        private DevExpress.XtraGrid.Columns.GridColumn col_LaMa;
        private DevExpress.XtraGrid.Columns.GridColumn col_LaMa_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraEditors.LookUpEdit lkupBM05;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraGrid.Columns.GridColumn col_Check_;
    }
}