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
        private string convert;
        private string depature { get; set; }

        public string arrival { get; set; }

        public DateTime date { get; set; }
        public SearchRout()
        {
            InitializeComponent();
            
        }
        public void Reset()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            bunifuDatePicker1.Visible = false;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            if (((Label)sender).Text != txtKt.Text)
                txtBd.Text = ((Label)sender).Text;
        }

        private void label22_Click(object sender, EventArgs e)
        {
            if (((Label)sender).Text != txtBd.Text)
                txtKt.Text = ((Label)sender).Text;
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            convert = txtBd.Text;
            txtBd.Text = txtKt.Text;
            txtKt.Text = convert;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.DeepSkyBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
        }

        private void bunifuTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

            panel1.Visible = false;
            panel2.Visible = false;
            bunifuDatePicker1.Visible = true;
            
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            Reset();
            txtCalendar.Text = bunifuDatePicker1.Value.ToString().Split(' ')[0];
        }

      

        private void txtKt_MouseDown(object sender, MouseEventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void txtBd_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void SearchRout_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public ViewSearchRoute GetSearchRoute()
        {
            ViewSearchRoute Obj = new ViewSearchRoute {
                StartPoint = txtBd.Text,
                EndPoint = txtKt.Text,
                StartTime = bunifuDatePicker1.Value
            };
            
            return Obj;
        }

        // chuyển dữ liệu từ search route sang detail

        private void but_timChuyen_Click(object sender, EventArgs e)
        {
            
            
            DetailSchedule ds = new DetailSchedule(txtBd.Text,txtKt.Text,Convert.ToDateTime(bunifuDatePicker1.Value.ToString()).Date);
            //MessageBox.Show(txtBd.Text);
            //MessageBox.Show(txtKt.Text);
            //MessageBox.Show(Convert.ToDateTime(bunifuDatePicker1.Value.ToString()).Date.ToString());
            ds.Show();

        }
    }
}
