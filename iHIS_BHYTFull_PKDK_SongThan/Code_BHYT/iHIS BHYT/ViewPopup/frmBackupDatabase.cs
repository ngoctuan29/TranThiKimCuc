using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Threading;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmBackupDatabase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sEmployeeCode = string.Empty;
        private string path_Databasebackup = "D:\\PsClinic\\database";
        private string sDatabaseName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".bak";
        
        public frmBackupDatabase(string _EmployeeCode)
        {
            InitializeComponent();
            this.sEmployeeCode = _EmployeeCode;
        }

        private void frmBackupDatabase_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path_Databasebackup))
                Directory.CreateDirectory(path_Databasebackup);
            //marqueeProgress.Properties.Stopped = true;
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Caramel";
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            //progressBarControl1.Properties.Step = 1;
            //progressBarControl1.Properties.PercentView = true;
            //progressBarControl1.Properties.Maximum = 50;
            //progressBarControl1.Properties.Minimum = 0;
            //System.Threading.Thread.Sleep(5000);

            if (Utils.BackupDataBase(txtPath.Text.Trim()))
            {
                XtraMessageBox.Show(" Backup CSDL thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK);
                return;
                //progressBarControl1.PerformStep();
                //progressBarControl1.Update();
            }
            else
            {
                XtraMessageBox.Show(" Backup CSDL không thành công. Có lỗi phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK);
                butPath.Focus();
                //progressBarControl1.PerformStep();
                //progressBarControl1.Update();
            }
        }

        private void butCANCEL_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        
        private void butPath_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "File database|*.bak";
                saveFileDialog1.Title = "Backup CSDL";
                DialogResult r = saveFileDialog1.ShowDialog();
                if (r == DialogResult.OK)
                    this.txtPath.Text = saveFileDialog1.FileName;
                if (txtPath.Text == "")
                {
                    XtraMessageBox.Show(" Chưa chọn đường dẫn lưu trữ CSDL! \n Hệ thống sẽ lấy đường dẫn mặc định.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPath.Text = path_Databasebackup + "\\" + sDatabaseName;
                }
            }
            catch { }
        }
    }
}