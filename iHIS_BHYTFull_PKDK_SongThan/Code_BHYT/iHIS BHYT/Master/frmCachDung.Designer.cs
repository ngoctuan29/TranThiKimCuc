namespace Ps.Clinic.Master
{
    partial class frmCachDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCachDung));
            this.gridControl_Instruction = new DevExpress.XtraGrid.GridControl();
            this.gridView_Instruction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_InstructionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Instruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Instruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Instruction
            // 
            this.gridControl_Instruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Instruction.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Instruction.MainView = this.gridView_Instruction;
            this.gridControl_Instruction.Name = "gridControl_Instruction";
            this.gridControl_Instruction.Size = new System.Drawing.Size(513, 350);
            this.gridControl_Instruction.TabIndex = 2;
            this.gridControl_Instruction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Instruction});
            this.gridControl_Instruction.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Instruction_ProcessGridKey);
            // 
            // gridView_Instruction
            // 
            this.gridView_Instruction.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Instruction.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Instruction.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Instruction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_InstructionName,
            this.col_RowID});
            this.gridView_Instruction.GridControl = this.gridControl_Instruction;
            this.gridView_Instruction.Name = "gridView_Instruction";
            this.gridView_Instruction.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Cách sử dụng thuốc).";
            this.gridView_Instruction.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Instruction.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Instruction.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Instruction.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Instruction.OptionsView.ShowFooter = true;
            this.gridView_Instruction.OptionsView.ShowGroupPanel = false;
            this.gridView_Instruction.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Instruction_InvalidRowException);
            this.gridView_Instruction.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Instruction_ValidateRow);
            // 
            // col_InstructionName
            // 
            this.col_InstructionName.Caption = "Tên diễn giải";
            this.col_InstructionName.FieldName = "InstructionName";
            this.col_InstructionName.Name = "col_InstructionName";
            this.col_InstructionName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_InstructionName.Visible = true;
            this.col_InstructionName.VisibleIndex = 0;
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "RowID";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.gridControl_Instruction);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(517, 375);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh mục - Cách dùng thuốc";
            // 
            // frmCachDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 375);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCachDung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo hướng dẫn dùng thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCachDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Instruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Instruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Instruction;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Instruction;
        private DevExpress.XtraGrid.Columns.GridColumn col_InstructionName;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}