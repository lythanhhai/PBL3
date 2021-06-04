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
    public partial class datVe : Form
    {
        // delegate lấy số vé và tổng giá
        public delegate void getVeAndTongGia(int soVe,double tongGia);

        public getVeAndTongGia d1 { get; set; }

        // lấy id_route and id_vehicle từ confirm sang datVe
        public delegate string getIdRouteAndVehicle();

        public getIdRouteAndVehicle getRoute { get; set; }
        public getIdRouteAndVehicle getVehicle { get; set; }

        // lấy tên ghế từ form confirm sang form datVe.
        public delegate List<string> getNameGhe();

        public getNameGhe getGhe { get; set; }
        public int soVe { get; set; }
        public double tongGia { get; set; }

        public string id_detRoute { get; set; }

        public string id_vehicle { get; set; }
        public datVe(int soVe,double tongGia)
        {
            InitializeComponent();
            // giá và số vé
            this.soVe = soVe;
            this.tongGia = tongGia;
            lbTen.ForeColor = Color.FromArgb(78, 184, 206);
            bunifuPanel1.BackgroundColor = Color.FromArgb(78, 184, 206);
            txtName.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void But_xacnhan_Click(object sender, EventArgs e)
        {

            // thêm thông tin người dùng
            string id_person = Convert.ToString(Convert.ToInt32(BLL_TKVX.Instance.getMaxIdPerson_BLL()) + 1);
            BLL_TKVX.Instance.addPerson_BLL(id_person,Properties.Settings.Default.id_login, txtName.Text, txtPhone.Text, txtNote.Text, txtEmail.Text);

            // id_order
            string id_order = Convert.ToString(Convert.ToInt32(BLL_TKVX.Instance.getMaxIdOrder_BLL()) + 1);

            // lấy số vé and tổng giá cho thuộc tính 
            this.id_detRoute = getRoute();// id tuyến
            this.id_vehicle = getVehicle();// id xe

            //lấy danh sách tên ghế đã chọn 
            List<string> listGheDaChon = getGhe(); // list danh sách tên ghế

            // lấy id_seat của các ghế đã chọn
            List<string> listId_seat = new List<string>();
            foreach (string i in listGheDaChon)
            {
                foreach (Seat j in BLL_TKVX.Instance.getAllGhe_BLL())
                {
                    if (i == j.name_seat && j.id_vehicle == this.id_vehicle)
                    {
                        listId_seat.Add(j.id_seat);
                    }
                }
            }

            // lấy danh sách tất cả order_seat
            List<int> listOrderSeat = new List<int>();
            foreach (orderSeat i in BLL_TKVX.Instance.getAllOrderSeat_BLL())
            {
                foreach (string j in listId_seat)
                {
                    if (i.id_detRoute == this.id_detRoute &&  j == i.id_seat)//i.id_vehicle == this.id_vehicle &&
                    {
                        listOrderSeat.Add(i.id_orderSeat);
                    }
                }

            }

            // có so vé , có tổng giá ,có id_route 
            // cần tìm id_seat dựa vào id_vehicle được lấy từ form detailschedule
            // thêm đơn order theo ghế đã chọn
            if (listOrderSeat.Count > 0)
            {
                //BLL_TKVX.Instance.addOrder_BLL(id_order, this.id_detRoute, id_person, this.soVe, this.tongGia, DateTime.Now);
              BLL_TKVX.Instance.addOrder_BLL(id_order, id_person, this.soVe, this.tongGia, DateTime.Now);
                for (int i = 0; i < listOrderSeat.Count; i++)
                {
                    BLL_TKVX.Instance.updateOrderSeat_BLL(listOrderSeat[i], id_order);
                }
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("Ban chua chon ghe");
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
        //    txtName.Clear();
            lbTen.ForeColor = Color.FromArgb(78, 184, 206);
            bunifuPanel1.BackgroundColor = Color.FromArgb(78, 184, 206);
            txtName.ForeColor = Color.FromArgb(78, 184, 206);

            lbSoDT.ForeColor = Color.White;
            bunifuPanel2.BackgroundColor = Color.White;
            txtPhone.ForeColor = Color.White;

            lbEmail.ForeColor = Color.White;
            bunifuPanel3.BackgroundColor = Color.White;
            txtEmail.ForeColor = Color.White;

            lbNote.ForeColor = Color.White;
            bunifuPanel4.BackgroundColor = Color.White;
            txtNote.ForeColor = Color.White;
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
          //  txtPhone.Clear();
            lbSoDT.ForeColor = Color.FromArgb(78, 184, 206);
            bunifuPanel2.BackgroundColor = Color.FromArgb(78, 184, 206);
            txtPhone.ForeColor = Color.FromArgb(78, 184, 206);

            lbTen.ForeColor = Color.White;
            bunifuPanel1.BackgroundColor = Color.White;
            txtName.ForeColor = Color.White;

            lbEmail.ForeColor = Color.White;
            bunifuPanel3.BackgroundColor = Color.White;
            txtEmail.ForeColor = Color.White;

            lbNote.ForeColor = Color.White;
            bunifuPanel4.BackgroundColor = Color.White;
            txtNote.ForeColor = Color.White;
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
           // txtEmail.Clear();
            lbEmail.ForeColor = Color.FromArgb(78, 184, 206);
            bunifuPanel3.BackgroundColor = Color.FromArgb(78, 184, 206);
            txtEmail.ForeColor = Color.FromArgb(78, 184, 206);

            lbSoDT.ForeColor = Color.White;
            bunifuPanel2.BackgroundColor = Color.White;
            txtPhone.ForeColor = Color.White;

            lbTen.ForeColor = Color.White;
            bunifuPanel1.BackgroundColor = Color.White;
            txtName.ForeColor = Color.White;

            lbNote.ForeColor = Color.White;
            bunifuPanel4.BackgroundColor = Color.White;
            txtNote.ForeColor = Color.White;
        }

        private void txtNote_Click(object sender, EventArgs e)
        {
         //   txtNote.Clear();
            lbNote.ForeColor = Color.FromArgb(78, 184, 206);
            bunifuPanel4.BackgroundColor = Color.FromArgb(78, 184, 206);
            txtNote.ForeColor = Color.FromArgb(78, 184, 206);
            

            lbSoDT.ForeColor = Color.White;
            bunifuPanel2.BackgroundColor = Color.White;
            txtPhone.ForeColor = Color.White;

            lbEmail.ForeColor = Color.White;
            bunifuPanel3.BackgroundColor = Color.White;
            txtEmail.ForeColor = Color.White;

            lbTen.ForeColor = Color.White;
            bunifuPanel1.BackgroundColor = Color.White;
            txtName.ForeColor = Color.White;
        }

        private void But_xemthongtin_Click(object sender, EventArgs e)
        {
            // showNameSeat();
            panelMain.Hide();
            OpenChildForm(new infoTicket(this.id_detRoute,this.id_vehicle,this.tongGia));
        }
        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            //panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            panelMain.Text = childForm.Text;
        }
        //public void showNameSeat()
        //{
        //    List<string> listName = getGhe();
        //    //List<seeTicket> list = new List<seeTicket>();
        //    seeTicket[] list = new seeTicket[listName.Count];
        //    int count1 = 0;
        //    foreach(seeTicket i in list)
        //    {

        //        flowLayoutPanel1.Controls.Add(new seeTicket
        //        {
        //             NameGhe = listName[count1],
        //             Gia = (this.tongGia / this.soVe).ToString(),
        //        });
        //        count1++;
        //    }    
        //}
    }
}
