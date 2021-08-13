using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_DATVEXE.BLL;
using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.View
{
    public partial class Payment : Form
    {   
        int second = -1;
        int minute = 0;
        int ms = 0;
        private string id_login {get; set;}
        private string id_person { get; set; }
        private string id_order { get; set; }
       
        public Payment(string id_login,string id_person,string id_order,string s,string ND)
        {
            InitializeComponent();
            setCountdown();
            this.id_login = id_login;
            this.id_person =id_person;
            this.id_order = id_order;
            lbid_order.Text = id_order;
            lb_STK.Text = s;
            lbUpND.Text = ND;
        }
        public void setCountdown()
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ms++;
            if (ms == 10)
            {
                second++;
                labelcountdown.Text = minute.ToString() + " : " + second.ToString();
                if (second == 59)
                {
                    second = -1;
                    minute++;
                }
                if (minute == 30)
                {
                    BLL_Payment.Instance.DeletePayment(id_order,id_person);
                    timer1.Enabled = false;
                    MessageBox.Show("Giao dịch đã hủy, cảm ơn quý khách!");
                }
                if (second == 30)
                {
                    
                    if (BLL_Payment.Instance.CheckPayment(id_login,id_person)==true)
                    { 
                        MessageBox.Show("Giao dịch thành công. Cảm ơn quý khách !");
                        this.Close();
                    }
                }
                ms = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL_Payment.Instance.DeletePayment(id_order, id_person);
            timer1.Enabled = false;
            MessageBox.Show("Giao dịch đã hủy. Cảm ơn quý khách!");
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
