using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_DATVEXE.View
{
    public partial class seeRoute : UserControl
    {
        private string _tenXe;
        private string _loaiXe;
        private string _diemDi;
        private string _diemDen;
        private string _thoiGian;
        private string _gia;
        private string _gheTrong;
        private string _id_vehicle;
        private string _id_detRoute;

        public string id_vehicle
        {
            get
            {
                return _id_vehicle;
            }
            set
            {
                _id_vehicle = value;
            }
        }



        public string tenXe
        {
            get
            {
                return lbName.Text;
            }
            set
            {
                lbName.Text = value;
            }
        }
        public string loaiXe
        {
            get
            {
                return lbType.Text;
            }
            set
            {
                lbType.Text = value;
            }
        }
        public string diemDi
        {
            get
            {
                return lbDiemDi.Text;
            }
            set
            {
                lbDiemDi.Text = value;
            }
        }
        public string diemDen
        {
            get
            {
                return lbDiemDen.Text;
            }
            set
            {
                lbDiemDen.Text = value;
            }
        }
        public string thoiGian
        {
            get
            {
                return lbTime.Text;
            }
            set
            {
                lbTime.Text = value;
            }
        }
        public string gia
        {
            get
            {
                return lbGia.Text.ToString();
            }
            set
            {
                lbGia.Text = value;
            }
        }

        public string gheTrong
        {
            get
            {
                return lbGheTrong.Text;
            }
            set
            {
                lbGheTrong.Text = value;
            }
        }

        public string Id_detRoute 
        { 
            get
            {
                return _id_detRoute;
            }
            set
            {
                _id_detRoute = value;
            }

        }


        public double getGia()
        {
            string gia = "";
            for(int i = 0; i < this.gia.Length - 1; i++)
            {
                gia += this.gia[i];
            }    
            return Convert.ToDouble(gia);
        }
        public string getId_detRoute()
        {
            return this.Id_detRoute;
        }
        public string getId_Vehicle()
        {
            return this.id_vehicle;
        }

        public seeRoute()
        {
            InitializeComponent();

        }
       

        
        private void seeRoute_Click(object sender, EventArgs e)
        {
           // string id_detRoute1 = this.Id_detRoute;
            //confirm cf = new confirm();
            //cf.d += new confirm.getGia(getGia);
            //cf.d2 += new confirm.getIdRoute_Vehicle(getId_detRoute);
            //cf.d3 += new confirm.getIdRoute_Vehicle(getId_Vehicle);
            //cf.Show();
        }

        private void But_chonTuyen_Click(object sender, EventArgs e)
        {
            confirm cf = new confirm();
            cf.d += new confirm.getGia(getGia);
            cf.d2 += new confirm.getIdRoute_Vehicle(getId_detRoute);
            cf.d3 += new confirm.getIdRoute_Vehicle(getId_Vehicle);
            cf.Show();

        }

        //[DllImport("user32.dll")]
        //static extern IntPtr GetWindowDC(IntPtr hWnd);
        //[DllImport("User32.dll")]
        //static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_NCPAINT = 133;
        //    if (m.Msg == WM_NCPAINT)
        //    {
        //        IntPtr hdc = GetWindowDC(m.HWnd);
        //        Graphics g = Graphics.FromHdc(hdc);
        //        //this.Width - 1 this.Height - 1
        //        Rectangle rDraw = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        //        Pen pBottom = new Pen(Color.Gainsboro, 3);
        //        Pen pTop = new Pen(Color.Gainsboro, 3);
        //        g.DrawRectangle(pBottom, rDraw);
        //        Point[] pts = new Point[3];

        //        pts[0] = new Point(0, this.Height - 1);
        //        pts[1] = new Point(0, 0);
        //        pts[2] = new Point(this.Width - 1, 0);


        //        g.DrawLines(pTop, pts);
        //        ReleaseDC(this.Handle, hdc);
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}

        private void ParentPaint(object sender, PaintEventArgs e)
        {
            Graphics g = this.Parent.CreateGraphics();
            Matrix mx = new Matrix(1F, 0, 0, 1F, 4, 4);
            Rectangle rdraw = new Rectangle(this.Left - 7, this.Top, this.Width + 7, this.Height + 2);
            g.Transform = mx;
            g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.FromArgb(170,170,170))), rdraw);
            g.Dispose();
        }

        private void seeRoute_MouseHover(object sender, EventArgs e)
        {
            //bunifuTransition1.ShowSync(bunifuPanel1);
            //this.BorderStyle = BorderStyle.FixedSingle;
            //this.Paint += ParentPaint;
            //this.Invalidate();//
            //this.Paint += ParentPaint;
            // MessageBox.Show("ngu");
        }

        private void bunifuPanel1_MouseHover(object sender, EventArgs e)
        {
            bunifuTransition1.ShowSync(bunifuPanel1);
          //  bunifuPanel1.BorderStyle = BorderStyle.Fixed3D;
            //this.Paint += ParentPaint;
            //this.Invalidate();//
        }

        private void bunifuPanel1_MouseLeave(object sender, EventArgs e)
        {
            //bunifuTransition1.HideSync(bunifuPanel1);
            //bunifuPanel1.BorderStyle = BorderStyle.FixedSingle;
            //this.Paint -= ParentPaint;
            //this.Refresh();
            //this.Invalidate();
           // MessageBox.Show("ngu");
        }
    }
}
