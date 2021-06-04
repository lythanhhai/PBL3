using Bunifu.UI.WinForms;
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
    public partial class confirm : Form
    {
        private static int count = 0;
        // khai báo delegate để chuyển đổi dữ liệu từ form detailschedule sang confirm
        public delegate double getGia();
        public getGia d { get; set; }


        // khai báo delegate lấy id_route and it_vehicle từ detailschedule sang confirm
        public delegate string getIdRoute_Vehicle();
        public getIdRoute_Vehicle d2 { get; set; }
        public getIdRoute_Vehicle d3 { get; set; }
        private static int count1 = 0;

        public confirm()
        {
            InitializeComponent();
            
        }
        // lấy danh sách các tên ghế mà đã chọn
        public List<string> listNameGhe = new List<string>();

        public List<string> getNameGhe()
        {
            return listNameGhe;
        }

        //
        
        public void algorithmChooseSeat(object sender)
        {
            // bunifuImageButton
            List<orderSeat> listOrderSeats = BLL_TKVX.Instance.getAllOrderSeat_BLL();
            List<Seat> listSeats = new List<Seat>();
            // lấy ghế của xe đã chọn
            foreach (Seat i in BLL_TKVX.Instance.getAllGhe_BLL())
            {
                if (i.id_vehicle == d3())
                {
                    listSeats.Add(i);
                }
            }
            BunifuImageButton t = (BunifuImageButton)sender;
           
            // so sánh 
            if(algorithmCompareImage((Bitmap)t.Image) == true)
            {
                
                //t.Image = System.Drawing.Bitmap.FromFile(@"D:\image\Seat icon\Chua.png");
                t.Image = global::PBL3_DATVEXE.Properties.Resources.Chua;
                count--;

                lbPrice.Text = Convert.ToString(count * d());
                try
                {
                    // kiểm tra xem loại xe nào
                    if(getTypevehicle() == "10 chỗ")
                    {
                        listNameGhe.Remove(t.Name.ToString());
                    }
                    else if(getTypevehicle() == "20 chỗ")
                    {
                        listNameGhe.Remove(t.Name.Split('_')[0].ToString());
                    }   
                    else
                    {

                    }                        

                    count1--;
                    if (count1 == 0)
                    {
                        lbGhe.Text = "";
                    }
                    else if (count1 == 1)
                    {
                        lbGhe.Text = lbGhe.Text.Split(',')[0].ToString();
                    }
                    else
                    {

                        string[] arr = lbGhe.Text.Split(',');
                        string str = "";
                        for (int m = 0; m < arr.Length - 1; m++)
                        {
                            if (m != arr.Length - 2)
                            {
                                str += arr[m] + ", ";
                            }
                            else
                            {
                                str += arr[m];
                            }

                        }
                        lbGhe.Text = str;
                    }

                }
                catch (Exception r)
                {
                    MessageBox.Show(r.ToString());
                }


            }
            else
            {
                t.Image = global::PBL3_DATVEXE.Properties.Resources.image1;
                count++;
                lbPrice.Text = Convert.ToString(count * d());

                // kiểm tra xem loại xe nào
                if (getTypevehicle() == "10 chỗ")
                {
                    listNameGhe.Add(t.Name.ToString());
                }
                else if (getTypevehicle() == "20 chỗ")
                {
                    listNameGhe.Add(t.Name.Split('_')[0].ToString());
                }
                else
                {

                }

                count1++;
                if (count1 == 1)
                {
                    lbGhe.Text += t.Name.Split('_')[0].ToString();
                }
                else
                {
                    lbGhe.Text += ", " + t.Name.Split('_')[0].ToString();
                }

            }
        }

        public bool algorithmCompareImage(Bitmap bmp1)
        {
            string img_1, img_2;
            Bitmap bmp2;
            //lấy một hình đã có sẳn trong Resources gán cho bmp2
            bmp2 = global::PBL3_DATVEXE.Properties.Resources.image1;
            //Cuối cùng là bước so sánh:
            if (bmp1.Width == bmp2.Width && bmp1.Height == bmp2.Height)
            {
                for (int i = 0; i < bmp1.Width; i++)
                    for (int j = 0; j < bmp1.Height; j++)
                    {
                        img_1 = bmp1.GetPixel(i, j).ToString();
                        img_2 = bmp2.GetPixel(i, j).ToString();
                        if (img_1 != img_2) return false;
                    }
                return true;
            }
            else return false;
        }
        private void But_seat_Click(object sender, EventArgs e)
        {

            algorithmChooseSeat(sender);
           

        }

        // hàm lấy id_route and id_vehicle 
        public string getIdDetRoute()
        {
            return d2();
        }
        public string getIdVehicle()
        {
            return d3();
        }
        private void But_tiep_Click(object sender, EventArgs e)
        {
            datVe dv = new datVe(count,count*d());
            dv.getGhe += new datVe.getNameGhe(getNameGhe);
            dv.getRoute += new datVe.getIdRouteAndVehicle(getIdDetRoute);
            dv.getVehicle += new datVe.getIdRouteAndVehicle(getIdVehicle);
            if (count <= 0)
            {
                MessageBox.Show("Ban chua chon ghe");
            }
            else
            {
                dv.Show();
                this.Close();
            }


        }

        private void confirm_FormClosed(object sender, FormClosedEventArgs e)
        {
            count = 0;
            
        }
        public List<BunifuImageButton> getButtonInForm0()
        {
            List<BunifuImageButton> list = new List<BunifuImageButton>();
            list.Add(Seat1);
            list.Add(Seat2);
            list.Add(Seat3);
            list.Add(Seat4);
            list.Add(Seat5);
            list.Add(Seat6);
            list.Add(Seat7);
            list.Add(Seat8);
            list.Add(Seat9);
            list.Add(Seat10);
            return list;
        }
        public List<BunifuImageButton> getButtonInForm1()
        {
            List<BunifuImageButton> list = new List<BunifuImageButton>();
            list.Add(Seat1_1);
            list.Add(Seat2_1);
            list.Add(Seat3_1);
            list.Add(Seat4_1);
            list.Add(Seat5_1);
            list.Add(Seat6_1);
            list.Add(Seat7_1);
            list.Add(Seat8_1);
            list.Add(Seat9_1);
            list.Add(Seat10_1);
            list.Add(Seat11_1);
            list.Add(Seat12_1);
            list.Add(Seat13_1);
            list.Add(Seat14_1);
            list.Add(Seat15_1);
            list.Add(Seat16_1);
            list.Add(Seat17_1);
            list.Add(Seat18_1);
            list.Add(Seat19_1);
            list.Add(Seat20_1);
            return list;
        }
        
        // lấy loại xe
        public string getTypevehicle()
        {
            string type = "";

            foreach (Vehicle j in BLL_TKVX.Instance.getAllXe_BLL())
            {
                if (d3() == j.id_vehicle)
                {
                    type = j.type;
                    break;
                }
            }
            return type;
        }
        private void confirm_Load(object sender, EventArgs e)
        {    
            if(getTypevehicle() == "10 chỗ")
            {
                bunifuPanel2.BringToFront();
                bunifuPanel3.SendToBack();
            List<orderSeat> list = BLL_TKVX.Instance.getAllOrderSeat_BLL();
            foreach(BunifuImageButton i in getButtonInForm0())
            {
                foreach (orderSeat j in list)
                {
                    if ((j.id_detRoute == d2()) && (j.status == true) && (String.Compare(j.id_seat, i.Name[i.Name.Length - 1].ToString()) == 0))
                    {
                        i.Image = global::PBL3_DATVEXE.Properties.Resources.DatRoi;
                        i.Cursor = Cursors.No;
                        i.Enabled = false;
                    }
                }
            }
 
            }   
            else if(getTypevehicle() == "20 chỗ")
            {
                bunifuPanel3.BringToFront();
                bunifuPanel2.SendToBack();    
                List<orderSeat> list = BLL_TKVX.Instance.getAllOrderSeat_BLL();
                // list chứa name_seat 
                List<string> listName = new List<string>();
                foreach (orderSeat j in list)
                {
                    if ((j.id_detRoute == d2()) && (j.status == true))
                    {
                        foreach (Seat m in BLL_TKVX.Instance.getAllGhe_BLL())
                        {
                            //if(String.Compare(j.id_seat, i.Name[i.Name.Length - 1].ToString()) == 0)
                            if (j.id_seat == m.id_seat)
                            {
                                listName.Add(m.name_seat);
                            }
                        }
                        

                    }
                }
                foreach (BunifuImageButton i in getButtonInForm1())
                {
                    foreach(string j in listName)
                    {
                        if (i.Name.Split('_')[0].ToString() == j)
                        {
                            i.Image = global::PBL3_DATVEXE.Properties.Resources.DatRoi;
                            i.Cursor = Cursors.No;
                            i.Enabled = false;
                        }    
                            
                    }    
                    
                }
            }   
            else
            {

            }                
  
 
        }


    }
}
