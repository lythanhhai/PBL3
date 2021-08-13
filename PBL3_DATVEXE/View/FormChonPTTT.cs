using PBL3_DATVEXE.BLL;
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
    public partial class FormChonPTTT : Form
    {
        private string id_login { get; set; }
        private string id_person { get; set; }
        private string id_order { get; set; }
        public FormChonPTTT(string ID_LOGIN, string ID_PERSON,string ID_ORDER)
        {
            InitializeComponent();
            this.id_login = ID_LOGIN;
            this.id_person = ID_PERSON;
            this.id_order = ID_ORDER;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label2.Text = "Thanh toán bằng MoMo";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label2.Text = "Thanh toán bằng Ngân Hàng";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label2.Text == "Thanh toán bằng MoMo")
            {
                Payment pm = new Payment(id_login,id_person,id_order,"0889287686", "Mời bạn gửi tiền vào TK dưới đây bằng MoMo");
                pm.Show();
            }
            else
            {

                Payment pm = new Payment(id_login, id_person, id_order, "4005205315400", "Mời bạn gửi tiền vào TK, ngân hàng Agribank");
                pm.Show();
            }
               

        }

        private void but_trove_Click(object sender, EventArgs e)
        {
            BLL_Payment.Instance.DeletePayment(this.id_order, this.id_person);
            this.Hide();
            Form frm = Application.OpenForms["datVe"];
            frm.Show();
        }
    }
}
