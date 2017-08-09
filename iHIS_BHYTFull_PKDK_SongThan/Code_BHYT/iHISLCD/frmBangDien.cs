using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using ClinicBLL;
using ClinicModel;
using ClinicLibrary;

namespace iHISLCD
{
    public partial class frmBangDien : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tableDepartment = new DataTable();        
        private int x, y;
        private int soDong = 1; int i;
        private DateTime dtimeWorking = new DateTime();
        private string departmentCode = string.Empty;
        public frmBangDien(DataTable _tableDepartment)
        {
            this.tableDepartment = _tableDepartment;
            InitializeComponent();
        }
        internal static decimal RoundFactor(int places)
        {
            decimal factor = 1m;
            if (places < 0)
            {
                places = -places;
                for (int i = 0; i < places; i++)
                    factor /= 10m;
            }
            else
            {
                for (int i = 0; i < places; i++)
                    factor *= 10m;
            }
            return factor;
        }
        public static decimal RoundDown(decimal number, int places)
        {
            decimal factor = RoundFactor(places);
            number *= factor;
            number = Math.Floor(number);
            number /= factor;
            return number;
        }
        private void LoadData()
        {
            DataTable tablePatient = new DataTable();
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(500);
            if (objSys != null && objSys.RowID > 0)
            {
                tablePatient = PatientReceiveBLL.TablePatientWaiting(this.dtimeWorking, this.dtimeWorking, 0, 1, string.Empty, objSys.Values, string.Empty);
            }
            foreach (DataRow row in this.tableDepartment.Rows)
            {
                if (tablePatient.Rows.Count > 0 && tablePatient != null)
                {
                    if (tablePatient.Select("DepartmentCode='" + row["DepartmentCode"].ToString() + "'").Length > 0)
                    {
                        DataTable tableTemp = tablePatient.Select("DepartmentCode='" + row["DepartmentCode"].ToString() + "'").CopyToDataTable();
                        List<PatientInfo> lst = new List<PatientInfo>();
                        foreach (DataRow row1 in tableTemp.Rows)
                        {
                            PatientInfo info = new PatientInfo { PatientCode = row1["PatientCode"].ToString(), PatientName = row1["PatientName"].ToString(), PatientBirthyear = row1["PatientBirthyear"].ToString(), SerialNumber = row1["STT"].ToString() };
                            lst.Add(info);
                        }
                        ControlLCD control = new ControlLCD(lst, row["DepartmentName"].ToString(), this.Height, this.Width, i, soDong, lst.Count);
                        if (x + control.Width > this.Width)
                        {
                            x = 0;
                            y = (y + (this.Height - 30) / soDong - 5);
                        }
                        control.Location = new Point(x, y);
                        x += control.Width;
                        this.Controls.Add(control);
                    }
                    else
                    {
                        List<PatientInfo> lst = new List<PatientInfo>();
                        PatientInfo info = new PatientInfo();
                        lst.Add(info);
                        ControlLCD control = new ControlLCD(lst, row["DepartmentName"].ToString(), this.Height, this.Width, i, soDong, lst.Count);
                        if (x + control.Width > this.Width)
                        {
                            x = 0;
                            y = (y + (this.Height - 30) / soDong - 5);
                        }
                        control.Location = new Point(x, y);
                        x += control.Width;
                        this.Controls.Add(control);
                    }
                }
                else
                {
                    List<PatientInfo> lst = new List<PatientInfo>();
                    //PatientInfo info = new PatientInfo();
                    //lst.Add(info);
                    ControlLCD control = new ControlLCD(lst, row["DepartmentName"].ToString(), this.Height, this.Width, i, soDong, lst.Count);
                    if (x + control.Width > this.Width)
                    {
                        x = 0;
                        y = (y + (this.Height - 30) / soDong - 5);
                    }
                    control.Location = new Point(x, y);
                    x += control.Width;
                    this.Controls.Add(control);
                }
            }
            
        }

        private void frmBangDien_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeWorking = Utils.DateServer();
                this.Init();
                this.LoadData();
                GC.Collect();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.ToString(), "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Init()
        {
            x = 0; y = 0;
            tm_load.Interval = 120000;
            tm_load.Start();
            this.Controls.Clear();
            i = this.tableDepartment.Rows.Count;
            if (i == 4)
                soDong = 2;
            else if (i == 3)
                soDong = 1;
            else if (i % 3 == 0)
                soDong = i / 3;
            else soDong = int.Parse((RoundDown(i / 3, 0) + 1).ToString());
        }
        public static void Clear(Control ctrl)
        {
            while (ctrl.Controls.Count > 0) ctrl.Controls[0].Dispose();
        }
        private void tm_load_Tick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                Clear(c);
            //this.Init();
            this.frmBangDien_Load(sender, e);
        }
    }
}