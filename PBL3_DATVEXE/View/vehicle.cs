using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_DATVEXE.BLL;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.View
{
    public partial class vehicle : Form
    {
        public vehicle()
        {
            InitializeComponent();
            load();
            SetCBBSort();
        }

        public void load()
        {
            bunifuDataGridView1.DataSource = BLL_vehicle.Instance.getallvehicle();


        }
        public void SetCBBSort()
        {

            bunifuDropdown1.Items.Add("id_vehicle");
            bunifuDropdown1.Items.Add("name");
            bunifuDropdown1.Items.Add("type");
            bunifuDropdown1.Items.Add("number_seat");
            bunifuDropdown1.Items.Add("status_vehicle");
            bunifuDropdown1.SelectedIndex = 0;



        }

        

        private void bunifuDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            bunifuTextBox1.Text = bunifuDataGridView1.Rows[i].Cells[0].Value.ToString();
            bunifuTextBox2.Text = bunifuDataGridView1.Rows[i].Cells[1].Value.ToString();
            bunifuTextBox3.Text = bunifuDataGridView1.Rows[i].Cells[2].Value.ToString();
            bunifuTextBox4.Text = bunifuDataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            DTO_vehicle r = new DTO_vehicle();
            r.id_vehicle = bunifuTextBox1.Text;
            r.type = bunifuTextBox2.Text;
            r.name = bunifuTextBox3.Text;
            r.number_seat = Convert.ToInt32(bunifuTextBox4.Text);
            BLL_vehicle.Instance.add_vehicle(r);
            load();
        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            DTO_vehicle r = new DTO_vehicle();
            r.id_vehicle = bunifuTextBox1.Text;
            r.type = bunifuTextBox2.Text;
            r.name = bunifuTextBox3.Text;
            r.number_seat = Convert.ToInt32(bunifuTextBox4.Text);
            BLL_vehicle.Instance.edit(r);
            load();

        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            DTO_vehicle r = new DTO_vehicle();
            r.id_vehicle = bunifuTextBox1.Text;
            r.type = bunifuTextBox2.Text;
            r.name = bunifuTextBox3.Text;
            r.number_seat = Convert.ToInt32(bunifuTextBox4.Text);
            BLL_vehicle.Instance.deletevehicle(r.id_vehicle);
            load();
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            if (bunifuDropdown1.SelectedItem.ToString() == "id_vehicle")
            {
                bunifuDataGridView1.DataSource = BLL_vehicle.Instance.sort(new BLL_vehicle.Compare(DTO_vehicle.compareid));
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "name")
            {
                bunifuDataGridView1.DataSource = BLL_vehicle.Instance.sort(new BLL_vehicle.Compare(DTO_vehicle.comparename));
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "type")
            {
                bunifuDataGridView1.DataSource = BLL_vehicle.Instance.sort(new BLL_vehicle.Compare(DTO_vehicle.comparetype));
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "number_seat")
            {
                bunifuDataGridView1.DataSource = BLL_vehicle.Instance.sort(new BLL_vehicle.Compare(DTO_vehicle.comparenumber));
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "status_vehicle")
            {
                bunifuDataGridView1.DataSource = BLL_vehicle.Instance.sort(new BLL_vehicle.Compare(DTO_vehicle.Comparestatus));
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
        }
    }
}
