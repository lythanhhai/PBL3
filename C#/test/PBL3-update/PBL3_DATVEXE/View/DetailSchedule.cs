using PBL3_DATVEXE.BLL;
using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_DATVEXE.View
{
    public partial class DetailSchedule : Form
    {
        confirm cf = new confirm();

        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime date { get; set; }
        public DetailSchedule(string departure, string arrival, DateTime date)
        {
            InitializeComponent();
            this.departure = departure;
            this.arrival = arrival;
            this.date = date;

            showDetailRoute(this.departure, this.arrival, this.date);//"Quảng Trị","Đà Nẵng", DateTime.Now

            //List<DetailRoute> list = BLL_TKVX.Instance.getAllChiTietTuyen_BLL();
            //foreach (DetailRoute i in list)
            //{

            //    //if ((DateTime.Compare(DateTime.Now.Date, i.date) > 0))
            //    if ((DateTime.Compare(DateTime.Now.Date, i.date) > 0))// || (DateTime.Compare(Convert.ToDateTime(DateTime.Now.Hour),Convert.ToDateTime(i.time_start)) > 0))
            //    {
            //        BLL_TKVX.Instance.updateDetailRoute_BLL(i.id_delRoute);
            //    }
            //}
        }



        //public void setSort()
        //{
        //    cbbsapXep.Items.AddRange(new string[]
        //    {
        //        "price",
        //        "time_start"
        //    });
        //    cbbsapXep.SelectedIndex = 0;
        //}
        //public void ShowXe()
        //{

        //    dgw1.DataSource = BLL_TKVX.Instance.getALLDetailSchedule_BLL("QT","DN",DateTime.Now.Date);
        //    dgw1.Columns["id_detRoute"].Visible = false;
        //    dgw1.Columns["id_vehicle"].Visible = false;

        //}

        // hàm tham chiếu của delegate
        //public double getGia()
        //{
        //    DataGridViewSelectedRowCollection data = dgw1.SelectedRows;
        //    if(data.Count == 1)
        //    {
        //        //foreach(Detail i in BLL_TKVX.Instance.getALLDetailSchedule_BLL("QT","DN",DateTime.Now.Date))
        //        //{
        //        //    if(i.id_detRoute == )
        //        //}    
        //        //return ;
        //        return Convert.ToDouble(data[0].Cells["price"].Value.ToString());
        //    }   
        //    else
        //    {
        //        return 0;
        //    }                
        //}

        //// lấy id_route and id_vehicle
        //public string getIdDetRoute()
        //{
        //    return dgw1.SelectedRows[0].Cells["id_detRoute"].Value.ToString(); 
        //}
        //public string getIdVehicle()
        //{
        //    return dgw1.SelectedRows[0].Cells["id_vehicle"].Value.ToString();

        //}


        //private void But_chon_Click(object sender, EventArgs e)
        //{
        //    DataGridViewSelectedRowCollection data = dgw1.SelectedRows;

        //    //flowLayoutPanel1.Controls.Count
        //    if (data.Count == 1)
        //    {
        //        cf = new confirm();
        //        cf.d += new confirm.getGia(getGia);
        //        cf.d2 += new confirm.getIdRoute_Vehicle(getIdDetRoute);
        //        cf.d3 += new confirm.getIdRoute_Vehicle(getIdVehicle);
        //        cf.Show();  
        //    }   
        //    else
        //    {
        //        MessageBox.Show("bạn chỉ được chọn 1 chuyến tại 1 thời điểm");
        //    }                
        //}


        // trước khi mở form xem các chi tiết tuyến nếu quá giờ thì tự động xóa

        private void DetailSchedule_Load(object sender, EventArgs e)
        {

            //List<DetailRoute> list = BLL_TKVX.Instance.getAllChiTietTuyen_BLL();
            //foreach (DetailRoute i in list)
            //{

            //    //if ((DateTime.Compare(DateTime.Now.Date, i.date) > 0))
            //    if ((DateTime.Compare(DateTime.Now.Date, i.date) > 0))// || (DateTime.Compare(Convert.ToDateTime(DateTime.Now.Hour),Convert.ToDateTime(i.time_start)) > 0))
            //    {
            //        BLL_TKVX.Instance.updateDetailRoute_BLL(i.id_delRoute);
            //    }
            //}
        }

        public void showDetailRoute(string departure, string arrival, DateTime date)
        {
            List<Detail> listDetail = BLL_TKVX.Instance.getALLDetailSchedule_BLL(departure, arrival, date.Date);
            int count = listDetail.Count;
            seeRoute[] list = new seeRoute[count];
            int count1 = 0;
            foreach (seeRoute i in list)
            {

                flowLayoutPanel1.Controls.Add(new seeRoute
                {
                    id_vehicle = listDetail[count1].id_vehicle,
                    Id_detRoute = listDetail[count1].id_detRoute,
                    tenXe = listDetail[count1].name.ToString(),
                    loaiXe = listDetail[count1].type.ToString(),
                    diemDi = listDetail[count1].departure.ToString(),
                    diemDen = listDetail[count1].arrival.ToString(),
                    thoiGian = listDetail[count1].time_start.ToString(),
                    gia = listDetail[count1].price.ToString() + "đ",
                    gheTrong = listDetail[count1].empty_seat.ToString() + " ghế" + " trống"
                });
                count1++;
            }
        }

        private void showDatailRoute1(List<Detail> listDetail, string departure, string arrival, DateTime date)

        {

            seeRoute[] list = new seeRoute[listDetail.Count];
            int count1 = 0;
            flowLayoutPanel1.Controls.Clear();

            foreach (seeRoute i in list)
            {

                flowLayoutPanel1.Controls.Add(new seeRoute
                {
                    id_vehicle = listDetail[count1].id_vehicle,
                    Id_detRoute = listDetail[count1].id_detRoute,
                    tenXe = listDetail[count1].name.ToString(),
                    loaiXe = listDetail[count1].type.ToString(),
                    diemDi = listDetail[count1].departure.ToString(),
                    diemDen = listDetail[count1].arrival.ToString(),
                    thoiGian = listDetail[count1].time_start.ToString(),
                    gia = listDetail[count1].price.ToString() + "đ",
                    gheTrong = listDetail[count1].empty_seat.ToString() + " ghế" + " trống"
                });
                count1++;
            }
        }

        private void lbGioSomNhat_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            if (pnGioSomNhat.Controls.Contains(lb))
            {
                lb.ForeColor = Color.White;
                pnGioSomNhat.BackColor = Color.FromArgb(0, 96, 196);
                lbGioMuonNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioMuonNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaThapNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaThapNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaCaoNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaCaoNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.CompareTimeIncre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                //pnGioSomNhat.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (pnGioMuonNhat.Controls.Contains(lb))
            {
                lb.ForeColor = Color.White;
                pnGioMuonNhat.BackColor = Color.FromArgb(0, 96, 196);
                lbGioSomNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioSomNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaThapNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaThapNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaCaoNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaCaoNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.CompareTimeDecre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                // pnGioMuonNhat.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (pnGiaThapNhat.Controls.Contains(lb))
            {
                lb.ForeColor = Color.White;
                pnGiaThapNhat.BackColor = Color.FromArgb(0, 96, 196);
                lbGioMuonNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioMuonNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGioSomNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioSomNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaCaoNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaCaoNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.ComparePriceIncre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                // pnGiaThapNhat.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                lb.ForeColor = Color.White;
                pnGiaCaoNhat.BackColor = Color.FromArgb(0, 96, 196);
                lbGioMuonNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioMuonNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaThapNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaThapNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGioSomNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioSomNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.ComparePriceDecre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                // pnGiaCaoNhat.BorderStyle = BorderStyle.FixedSingle;
            }

        }

        private void pnGioSomNhat_Click(object sender, EventArgs e)
        {
            Panel pn = (Panel)sender;

            if (pn.Controls.Contains(lbGioSomNhat))
            {
                lbGioSomNhat.ForeColor = Color.White;
                pn.BackColor = Color.FromArgb(0, 96, 196);
                lbGioMuonNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioMuonNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaThapNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaThapNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaCaoNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaCaoNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.CompareTimeIncre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                //pnGioSomNhat.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (pn.Controls.Contains(lbGioMuonNhat))
            {
                lbGioMuonNhat.ForeColor = Color.White;
                pn.BackColor = Color.FromArgb(0, 96, 196);
                lbGioSomNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioSomNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaThapNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaThapNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaCaoNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaCaoNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.CompareTimeDecre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                // pnGioMuonNhat.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (pn.Controls.Contains(lbGiaThapNhat))
            {
                lbGiaThapNhat.ForeColor = Color.White;
                pn.BackColor = Color.FromArgb(0, 96, 196);
                lbGioMuonNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioMuonNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGioSomNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioSomNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaCaoNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaCaoNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.ComparePriceIncre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                // pnGiaThapNhat.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                lbGiaCaoNhat.ForeColor = Color.White;
                pn.BackColor = Color.FromArgb(0, 96, 196);
                lbGioMuonNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioMuonNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGiaThapNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGiaThapNhat.BackColor = Color.FromArgb(240, 240, 240);
                lbGioSomNhat.ForeColor = Color.FromArgb(0, 0, 0);
                pnGioSomNhat.BackColor = Color.FromArgb(240, 240, 240);
                showDatailRoute1(BLL_TKVX.Instance.Sort_BLL(new DAL_TKVX.myDel(Detail.ComparePriceDecre), this.departure, this.arrival, this.date), this.departure, this.arrival, this.date);
                // pnGiaCaoNhat.BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}
