using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iHISLCD
{
    public partial class ControlLCD : DevExpress.XtraEditors.XtraUserControl
    {
        public static int verticalScrollValue = 0;
        private int w, h, x, soDong, p, point = 3;
        private int count = 0;
        private void ControlLCD_Load(object sender, EventArgs e)
        {
            this.pnlDanhSach.VerticalScroll.Value = verticalScrollValue;
            this.tmCuon.Interval = 10000;
            this.tmCuon.Start();
        }

        public ControlLCD(List<PatientInfo> lst, String _departmentName, int _h, int _w, int _i, int _soDong, int _p)
        {
            InitializeComponent();
            try
            {
                h = _h; w = _w - 18; x = _i; soDong = _soDong; p = _p;
                if (x <= 3)
                    this.Size = new Size(w / x, (h - 35) / soDong - 8);
                else if (x == 4)
                    this.Size = new Size(w / 2, (h - 35) / soDong - 8);
                else
                    this.Size = new Size(w / 3, (h - 35) / soDong - 8);
                this.count = _i;
                List<PatientInfo> List = new List<PatientInfo>();
                List = lst;
                this.lblTenPK.Text = _departmentName.ToUpper();
                int i = this.Width;
                int y = this.Height;
                this.pnlDanhSach.AutoScroll = true;
                this.AddListPatient(List);
            }
            catch(Exception ex) {
                XtraMessageBox.Show("ControlLCD: " + ex.ToString(), "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddListPatient(List<PatientInfo> lst)
        {
            try
            {
                float fontsize = 0, fontsizeTitle = 0;
                int row_height = 0, row_heightTitle = 0;
                if (this.count == 1)
                {
                    row_height = (this.Width * 17) / 90;
                    row_heightTitle = ((this.Width * 8) / 100) + 10;
                    fontsize = float.Parse((this.Width * 0.3).ToString());
                    fontsizeTitle = float.Parse((this.Width * 0.07).ToString());
                }
                else
                {
                    fontsize = row_height = (this.Width * this.count) / (18 + this.count);
                    fontsize = fontsize / 2;
                    //fontsize = (this.Width * (this.count + 20)) / (100);
                }
                ////Tieu de
                //Label lb = new Label();
                //lb.Text = "Mã BN";
                //lb.Font = new Font("Arial", this.Width * 3 / 100, FontStyle.Bold);
                //lb.Location = new Point(this.Width * 1 / 100, 3);
                //lb.TextAlign = ContentAlignment.MiddleLeft;
                //lb.Width = this.Width * 29 / 100;
                //lb.Height = 50;
                //this.pnlTieuDeCot.Controls.Add(lb);

                //Label lb1 = new Label();
                //lb1.Text = "HỌ TÊN";
                //lb1.Font = new Font("Arial", fontsize);
                //lb1.ForeColor = Color.Red;
                //lb1.Location = new Point(this.Width / 100, point);
                //lb1.Width = this.Width * 77 / 100;
                ////lb1.TextAlign = ContentAlignment.TopLeft;
                //lb1.Height = row_height;
                //this.pnlTieuDeCot.Controls.Add(lb1);

                Label lb2 = new Label();
                lb2.Text = "STT";
                lb2.Font = new Font("Arial", fontsizeTitle);
                lb2.ForeColor = Color.Red;
                //lb2.Location = new Point(lb1.Width, point);
                lb2.Location = new Point(this.Width / 100, point);
                //lb2.Width = this.Width * 23 / 100;
                lb2.Width = this.Width * 97 / 100;
                lb2.TextAlign = ContentAlignment.TopCenter;
                lb2.Height = row_heightTitle;
                this.pnlTieuDeCot.Controls.Add(lb2);

                //set size panel
                //panel ten pk
                this.lblTenPK.Font = new Font("Arial", fontsizeTitle);
                this.pnlTenPk.Size = new Size(this.Width, row_heightTitle);
                this.pnlTenPk.Location = new Point(0, 0);
                this.pnlTenPk.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                //panel tieu de
                this.pnlTieuDeCot.Size = new Size(this.Width, row_heightTitle);
                this.pnlTieuDeCot.Location = new Point(0, this.pnlTenPk.Height);
                this.pnlTieuDeCot.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                //panel danh sach
                //this.pnlDanhSach.Size = new Size(this.Width, this.Height - this.pnlTenPk.Height - this.pnlTieuDeCot.Height + 8);
                this.pnlDanhSach.Size = new Size(this.Width, this.Height);
                this.pnlDanhSach.Location = new Point(0, this.pnlTieuDeCot.Height + this.pnlTenPk.Height);
                this.pnlDanhSach.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

                Font f = new Font("Arial", fontsize);
                foreach (var row in lst)
                {
                    string patientName = row.PatientName.ToUpper();
                    //Label lb3 = new Label();
                    //lb3.Text = row.PatientCode;
                    //lb3.Font = f;
                    //lb3.Location = new Point(this.Width * 1 / 105, point);
                    //lb3.TextAlign = ContentAlignment.MiddleLeft;
                    //lb3.Width = this.Width * 29 / 100;
                    //lb3.Height = 50;
                    //this.pnlDanhSach.Controls.Add(lb3);               

                    //LabelControl lb4 = new LabelControl();
                    //lb4.Text = patientName;
                    //lb4.Font = f;
                    //lb4.ForeColor = Color.Black;
                    //lb4.Location = new Point(this.Width / 100, point);
                    //lb4.Width = this.Width * 75 / 100;
                    ////lb4.Height = row_height;
                    //lb4.AutoSizeMode = LabelAutoSizeMode.Vertical;
                    //this.pnlDanhSach.Controls.Add(lb4);

                    LabelControl lb5 = new LabelControl();
                    lb5.Text = row.SerialNumber;
                    lb5.Font = f;
                    //lb5.Location = new Point(lb4.Width, point - 1);
                    lb5.Location = new Point(this.Width / 100, point - 1);
                    lb5.AutoSizeMode = LabelAutoSizeMode.Vertical;
                    lb5.ForeColor = Color.Black;
                    //lb5.Width = this.Width * 23 / 100;
                    lb5.Width = this.Width * 97 / 100;
                    lb5.Height = row_height;
                    //lb5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                    lb5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //lb5.LineLocation = LineLocation.Bottom;
                    //lb5.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    this.pnlDanhSach.Controls.Add(lb5);

                    PanelControl pnLine = new PanelControl();
                    //pnLine.Location = new Point(this.Width / 100, lb4.Height + point);
                    pnLine.Location = new Point(this.Width / 100, lb5.Height + point);
                    pnLine.Height = 3;
                    //pnLine.Width = lb4.Width + lb5.Width - 70;
                    pnLine.Width = lb5.Width - 70;
                    pnLine.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    this.pnlDanhSach.Controls.Add(pnLine);

                    //point += lb4.Height + pnLine.Height;
                    point += lb5.Height + pnLine.Height;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddListPatient: " + ex.ToString(), "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmCuon_Tick(object sender, EventArgs e)
        {
            try
            {
                #region Create panel scroll 
                //int i = this.pnlDanhSach.VerticalScroll.Maximum / p;
                //if (this.pnlDanhSach.VerticalScroll.Value + pnlDanhSach.Height < this.pnlDanhSach.VerticalScroll.Maximum)
                //{
                //    pnlDanhSach.VerticalScroll.Value += i;
                //    verticalScrollValue = pnlDanhSach.VerticalScroll.Value;
                //}
                //else
                //{
                //    this.pnlDanhSach.VerticalScroll.Value = 0;
                //    verticalScrollValue = 0;
                //}
                #endregion

                #region set position x,y (0,0)
                this.pnlDanhSach.VerticalScroll.Value = 0;
                verticalScrollValue = 0;
                #endregion

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("tmCuon_Tick: " + ex.ToString(), "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
