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

namespace PBL3_DATVEXE
{
    public partial class Route : Form
    {
        public string id_route { get; internal set; }
        public string departure { get; internal set; }
        public bool deleted { get; internal set; }
        public string arrival { get; internal set; }

        public Route()
        {
            InitializeComponent();
            load();
            SetCBBSort();
        }
        public void load()
        {
            bunifuDataGridView1.DataSource = BLL_Route.Instance.getallRoute();
        }
        public void SetCBBSort()
        {

            bunifuDropdown1.Items.Add("id_route");
            bunifuDropdown1.Items.Add("departure");
            bunifuDropdown1.Items.Add("arrval");
            bunifuDropdown1.Items.Add("deleted");

            bunifuDropdown1.SelectedIndex = 0;



        }

        
        private void bunifuDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            bunifuTextBox1.Text = bunifuDataGridView1.Rows[i].Cells[0].Value.ToString();
            bunifuTextBox2.Text = bunifuDataGridView1.Rows[i].Cells[1].Value.ToString();
            bunifuTextBox3.Text = bunifuDataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            DTO_route r = new DTO_route();
            r.id_route = bunifuTextBox1.Text;
            r.departure = bunifuTextBox2.Text;
            r.arrival = bunifuTextBox3.Text;
            r.deleted = false;
            BLL_Route.Instance.add_route(r);
            load();
        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            DTO_route r = new DTO_route();
            r.id_route = bunifuTextBox1.Text;
            r.departure = bunifuTextBox2.Text;
            r.arrival = bunifuTextBox3.Text;
            r.deleted = false;
            BLL_Route.Instance.edit(r);
            load();
        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            DTO_route r = new DTO_route();
            r.id_route = bunifuTextBox1.Text;
            r.departure = bunifuTextBox2.Text;
            r.arrival = bunifuTextBox3.Text;
            r.deleted = false;
            BLL_Route.Instance.deleteRoute(r.id_route);
            load();
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            if (bunifuDropdown1.SelectedItem.ToString() == "id_route")
            {
                bunifuDataGridView1.DataSource = BLL_Route.Instance.sort(new BLL_Route.Compare(DTO_route.compareid));
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "departure")
            {
                bunifuDataGridView1.DataSource = BLL_Route.Instance.sort(new BLL_Route.Compare(DTO_route.compareid1));
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "arrival")
            {
                bunifuDataGridView1.DataSource = BLL_Route.Instance.sort(new BLL_Route.Compare(DTO_route.compareid2));
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "deleted")
            {
                bunifuDataGridView1.DataSource = BLL_Route.Instance.sort(new BLL_Route.Compare(DTO_route.Comparedele));
            }
        }
    }
}
