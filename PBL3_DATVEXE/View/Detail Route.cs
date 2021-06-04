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
using PBL3_DATVEXE.BLL;
using PBL3_DATVEXE.View;

namespace PBL3_DATVEXE
{
    public partial class Detail_Route : Form
    {
        public Detail_Route()
        {
            InitializeComponent();

            setCBBLSH();
            SetCBBSort();
        }
        public void SetCBBSort()
        {

            bunifuDropdown1.Items.Add("id_detail");
            bunifuDropdown1.Items.Add("route");
            bunifuDropdown1.Items.Add("vehicle");
            bunifuDropdown1.Items.Add("date");
            bunifuDropdown1.Items.Add("time_start");
            bunifuDropdown1.Items.Add("price");
            bunifuDropdown1.Items.Add("deleted");
            bunifuDropdown1.SelectedIndex = 0;



        }
        public void setCBBLSH()
        {
            List<DTO_route> list = BLL_Route.Instance.getallRoute();
            bunifuDropdown2.Items.Add(new CBBitem
            {
                Text = "All",
                Value = "0"
            });
            foreach (var i in list)
            {
                bunifuDropdown2.Items.Add(new CBBitem
                {
                    Value = i.id_route,
                    Text = i.departure + "-" + i.arrival
                });
            }
            bunifuDropdown2.SelectedIndex = 0;
        }
        public void Show1(string id_route, string name)
        {
            bunifuDataGridView1.DataSource = BLL_delRoute.Instance.getListdelroute_BLL(id_route, name);


        }


        
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Show1(((CBBitem)bunifuDropdown2.SelectedItem).Value, bunifuTextBox1.Text);
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            Add_detail f = new Add_detail(null);
            f.Show();
            f.d += new Add_detail.Mydel(Show1);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                string id_detroute = bunifuDataGridView1.SelectedRows[0].Cells["id_delroute"].Value.ToString();
                Add_detail f = new Add_detail(id_detroute);
                f.d += new Add_detail.Mydel(Show1);
                f.Show();
            }
        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            string id_detroute = bunifuDataGridView1.SelectedRows[0].Cells["id_delroute"].Value.ToString();
            BLL_delRoute.Instance.deleteSV_BLL(id_detroute);
            Show1(((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.SelectedItem.ToString() == "id_detail")
            {
                bunifuDataGridView1.DataSource = BLL_delRoute.Instance.sort(new BLL_delRoute.Compare(DTO_DelRoute.compareid), ((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "route")
            {
                bunifuDataGridView1.DataSource = BLL_delRoute.Instance.sort(new BLL_delRoute.Compare(DTO_DelRoute.compareroute), ((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "vehicle")
            {
                bunifuDataGridView1.DataSource = BLL_delRoute.Instance.sort(new BLL_delRoute.Compare(DTO_DelRoute.comparevehicle), ((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "date")
            {
                bunifuDataGridView1.DataSource = BLL_delRoute.Instance.sort(new BLL_delRoute.Compare(DTO_DelRoute.Comparedate), ((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "time_start")
            {
                bunifuDataGridView1.DataSource = BLL_delRoute.Instance.sort(new BLL_delRoute.Compare(DTO_DelRoute.comparetime), ((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "price")
            {
                bunifuDataGridView1.DataSource = BLL_delRoute.Instance.sort(new BLL_delRoute.Compare(DTO_DelRoute.comparenumber), ((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
            }
            if (bunifuDropdown1.SelectedItem.ToString() == "deleted")
            {
                bunifuDataGridView1.DataSource = BLL_delRoute.Instance.sort(new BLL_delRoute.Compare(DTO_DelRoute.Comparedele), ((CBBitem)bunifuDropdown1.SelectedItem).Value, bunifuTextBox1.Text);
            }
        }
    }
}
