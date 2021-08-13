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
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.View
{
    public partial class thanhtoan : Form
    {
        public thanhtoan()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            bunifuDataGridView1.DataSource = BLL_TKVX.Instance.showinformation_order();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            bunifuDataGridView1.DataSource = BLL_TKVX.Instance.getallorder1(txt_Search.Text);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                string id_order = bunifuDataGridView1.SelectedRows[0].Cells["id_order"].Value.ToString();
                string id_person = BLL_TKVX.Instance.getid(id_order);
                try
                {
                    BLL_Person.Instance.update(id_person);
                    MessageBox.Show("Thành công");
                    load();
                }
                catch(Exception l)
                {
                    MessageBox.Show("Thất bại");
                }
            }
            }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            bunifuDataGridView1.DataSource = BLL_TKVX.Instance.showinformation_ordersearch(txt_Search.Text);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuDataGridView1.DataSource = BLL_TKVX.Instance.showinformation_order();
        }
        private void label3_Click(object sender, EventArgs e)
        {   
            switch(lb_TD_update.Text)
            {
                case "Đang Bật":
                    {
                        lb_TD_update.Text = "Đã Tắt";
                        timer1.Enabled = false;
                        break;
                    }
                case "Đã Tắt":
                    {
                        lb_TD_update.Text = "Đang Bật";
                        timer1.Enabled = true;
                        break;
                    }
            }    
        }
        public int ms;
        int second = -1;
        int minute = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
                ms++;
                if (ms == 10)
                {
                    second++;
                    if (second == 59)
                    {
                        second = 0;
                        minute++;
                    }
                    if (minute == 2)
                    {
                        minute = 0;
                        load();
                    }

                    ms = 0;
                }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void thanhtoan_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tb_day1.Text=dateTimePicker1.Value.ToString().Split(' ')[0];
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tb_day2.Text = dateTimePicker2.Value.ToString().Split(' ')[0];
        }

        private void bt_search_Day_Click(object sender, EventArgs e)
        {
            string day1 = tb_day1.Text;
            string day2 = tb_day2.Text;
            
            bunifuDataGridView1.DataSource = BLL_TKVX.Instance.Search_information_Day(day1,day2);
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn không!","Thông báo", MessageBoxButtons.OKCancel) ;
            if(dialogResult==DialogResult.OK)
            {
                string id_order = bunifuDataGridView1.SelectedRows[0].Cells["id_order"].Value.ToString();
                BLL_Payment.Instance.DeletePayment(id_order,BLL_TKVX.Instance.getid(id_order));
                load();
            }    
        }
    }

}
