using PBL3_DATVEXE.BLL;
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
    public partial class infoTicket : Form
    {
        public infoTicket(string id_detRoute,string id_vehicle,double gia)
        {
            InitializeComponent();
            this.id_detRoute = id_detRoute;
            this.id_vehicle = id_vehicle;
            this.gia = gia;
        }
        public string id_detRoute { get; set; }
        public string id_vehicle { get; set; }
        public double gia { get; set; }
        private void infoTicket_Load(object sender, EventArgs e)
        {
            List<Detail> list = BLL_TKVX.Instance.getALLDetailSchedule_BLL("QT", "DN", DateTime.Now.Date);
            string nameXe = "";
            string Ngay = "";
            foreach (Vehicle j in BLL_TKVX.Instance.getAllXe_BLL())
            {
                if (this.id_vehicle == j.id_vehicle)
                {
                    nameXe = j.name;
                    break;
                }
            }
            foreach (Detail i in list)
            {
                if (i.id_detRoute == this.id_detRoute)
                {
                    lbDiemDi.Text = i.departure;
                    lbDiemDen.Text = i.arrival;
                    lbNgay.Text = Convert.ToString(DateTime.Now.Date);
                    lbTongGia.Text = this.gia.ToString();
                    lbName.Text = nameXe;
                    lbTime.Text = i.time_start;
                    break;
                }
            }
        }
    }
}
