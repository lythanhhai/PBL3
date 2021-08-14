using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.View
{
    public partial class SearchRout : UserControl
    {
       
        private string depature { get; set; }

        public string arrival { get; set; }

        public DateTime date { get; set; }
        public SearchRout()
        {
            InitializeComponent();
            setCombobox();


        }
        public void Reset()
        {
           
            bunifuDatePicker1.Visible = false;
        }
        void setCombobox()
        {
            comboBox1.Items.Add("Đà Nẵng");
            comboBox1.Items.Add("Quảng Trị");
            comboBox1.Items.Add("Hà Nội");
            comboBox1.Items.Add("Điện Biên");
            comboBox1.Items.Add("Lai Châu");
            comboBox1.Items.Add("Thanh Hóa");
            comboBox1.Items.Add("Hồ Chí Minh");
            comboBox1.Items.Add("Nghệ An");
            comboBox1.Items.Add("Bình Phước");
            comboBox1.Items.Add("Phú Quốc");
            comboBox1.Items.Add("Cà Mau");
            // bat dau
            comboBox2.Items.Add("Đà Nẵng");
            comboBox2.Items.Add("Quảng Trị");
            comboBox2.Items.Add("Hà Nội");
            comboBox2.Items.Add("Điện Biên");
            comboBox2.Items.Add("Lai Châu");
            comboBox2.Items.Add("Thanh Hóa");
            comboBox2.Items.Add("Hồ Chí Minh");
            comboBox2.Items.Add("Nghệ An");
            comboBox2.Items.Add("Bình Phước");
            comboBox2.Items.Add("Phú Quốc");
            comboBox2.Items.Add("Cà Mau");
            // ket thuc
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string convert;
            convert = comboBox1.Text;
            comboBox1.Text = comboBox2.Text;
            comboBox2.Text= convert;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.DeepSkyBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

       

        private void bunifuTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

            bunifuDatePicker1.Visible = true;
            
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            Reset();
            textBoxDay.Text = bunifuDatePicker1.Value.ToString().Split(' ')[0];
        }

      

     

        private void SearchRout_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public ViewSearchRoute GetSearchRoute()
        {
            ViewSearchRoute Obj = new ViewSearchRoute {
                StartPoint = comboBox1.Text,
                EndPoint = comboBox1.Text,
                StartTime = bunifuDatePicker1.Value
            };
            
            return Obj;
        }

        // chuyển dữ liệu từ search route sang detail

        private void but_timChuyen_Click(object sender, EventArgs e)
        {
            
            
            DetailSchedule ds = new DetailSchedule(comboBox1.Text,comboBox2.Text,Convert.ToDateTime(bunifuDatePicker1.Value.ToString()).Date);
            ds.Show();

            ((Form)this.TopLevelControl).Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bunifuDatePicker1.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text==comboBox2.Text)
            {
                MessageBox.Show("Trùng điểm đi");
                comboBox1.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("Trùng điểm đến");
                comboBox2.Text = "";
            }
        }

       
    }
}
