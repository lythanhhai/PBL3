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
    public partial class TK_TK : Form
    {
        public TK_TK()
        {
            InitializeComponent();
            load();
            load_statistics();
            SetCBBSort();
        }
        public void load_statistics()
        {
            List<DTO_route> list = BLL_Route.Instance.getallRoute();
            bunifuDropdown1.Items.Add(new CBBitem
            {
                Text = "",
                Value = "0"
            });
            foreach (var i in list)
            {
                bunifuDropdown1.Items.Add(new CBBitem
                {
                    Value = i.id_route,
                    Text = i.departure + "-" + i.arrival
                });
            }
          //  bunifuDropdown1.SelectedIndex = 0;
            List<DTO_vehicle> list1 = BLL_vehicle.Instance.getallvehicle();
            bunifuDropdown2.Items.Add(new CBBitem
            {
                Text = "",
                Value = "0"
            });
            foreach (var i in list1)
            {
                bunifuDropdown2.Items.Add(new CBBitem
                {
                    Value = i.id_vehicle,
                    Text = i.name
                });
            }
          //  bunifuDropdown2.SelectedIndex = 0;
            List<DTO_DelRoute> list3 = BLL_delRoute.Instance.getallDetRoute();
            bunifuDropdown3.Items.Add(new CBBitem
            {
                Text = "",
                Value = "0"
            });
            foreach (var i in list3)
            {
                bunifuDropdown3.Items.Add(new CBBitem
                {
                    Value = i.id_delroute,
                    Text = i.date.ToShortDateString() + "--" + i.time_start
                });
            }
         //   bunifuDropdown3.SelectedIndex = 0;

        }
        public void SetCBBSort()
        {

            bunifuDropdown4.Items.Add("number_ticket");
            bunifuDropdown4.Items.Add("total_price");
            
            



        }
        public void load()
        {
            bunifuDataGridView1.DataSource = BLL_QLVX.Instance.getallQLVX();
        }
        public void Show1(string route, string vehicle, string date_route)
        {
            // dataGridView1.DataSource = BLL_QLVX.Instance.getQLVXBY(((CBBitem)comboBox1.SelectedItem).Value, ((CBBitem)comboBox2.SelectedItem).Value, ((CBBitem)comboBox3.SelectedItem).Value);
           // bunifuDataGridView1.DataSource = BLL_QLVX.Instance.getQLVXBY(route, vehicle, date_route);

        }
        public void Show2(string route, string vehicle, string date_route, string name_person)
        {

            bunifuDataGridView1.DataSource = BLL_QLVX.Instance.getQLVXBY1(route, vehicle, date_route, name_person);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {if(bunifuDropdown1.Text=="Route"|| bunifuDropdown2.Text == "Vehicle"|| bunifuDropdown3.Text == "Date")
                
            {
                MessageBox.Show("ban chua chon truong thich hop");
            }
        else {

                Show2(((CBBitem)bunifuDropdown1.SelectedItem).Text, ((CBBitem)bunifuDropdown2.SelectedItem).Text, ((CBBitem)bunifuDropdown3.SelectedItem).Text, bunifuTextBox1.Text);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.Text == "Route" || bunifuDropdown2.Text == "Vehicle" || bunifuDropdown3.Text == "Date")

            {
                MessageBox.Show("ban chua chon truong thich hop");
            }
            else
            {
                Show2(((CBBitem)bunifuDropdown1.SelectedItem).Text, ((CBBitem)bunifuDropdown2.SelectedItem).Text, ((CBBitem)bunifuDropdown3.SelectedItem).Text, bunifuTextBox1.Text);
                bunifuLabel3.Text = BLL_QLVX.Instance.tt(((CBBitem)bunifuDropdown1.SelectedItem).Text, ((CBBitem)bunifuDropdown2.SelectedItem).Text, ((CBBitem)bunifuDropdown3.SelectedItem).Text, bunifuTextBox1.Text).ToString();
                bunifuLabel4.Text = BLL_QLVX.Instance.tp(((CBBitem)bunifuDropdown1.SelectedItem).Text, ((CBBitem)bunifuDropdown2.SelectedItem).Text, ((CBBitem)bunifuDropdown3.SelectedItem).Text, bunifuTextBox1.Text).ToString();
            }
        }

        private void bunifuDropdown4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown1.Text == "Route" || bunifuDropdown2.Text == "Vehicle" || bunifuDropdown3.Text == "Date")

            {
                MessageBox.Show("ban chua chon truong thich hop");
            }
            else
            {
                if (bunifuDropdown4.SelectedItem.ToString() == "number_ticket")
                {
                    bunifuDataGridView1.DataSource = BLL_QLVX.Instance.sort(new BLL_QLVX.Compare(DTO_QLVX.comparenum), ((CBBitem)bunifuDropdown1.SelectedItem).Text, ((CBBitem)bunifuDropdown2.SelectedItem).Text, ((CBBitem)bunifuDropdown3.SelectedItem).Text, bunifuTextBox1.Text);
                }
                if (bunifuDropdown4.SelectedItem.ToString() == "total_price")
                {
                    bunifuDataGridView1.DataSource = BLL_QLVX.Instance.sort(new BLL_QLVX.Compare(DTO_QLVX.comparenpr), ((CBBitem)bunifuDropdown1.SelectedItem).Text, ((CBBitem)bunifuDropdown2.SelectedItem).Text, ((CBBitem)bunifuDropdown3.SelectedItem).Text, bunifuTextBox1.Text);

                }
            }
        }
    }
}
