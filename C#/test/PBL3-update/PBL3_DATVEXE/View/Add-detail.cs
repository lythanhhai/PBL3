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
    public partial class Add_detail : Form
    {
        public delegate void Mydel(string id, string name);
        public Mydel d { get; set; }
        public string id_detroute { get; set; }

        public Add_detail(string m)
        {
            InitializeComponent();
            id_detroute = m;
            setGui();
        }
        public void setGui()
        {
            List<DTO_route> list = BLL_Route.Instance.getallRoute();
            foreach (var i in list)
            {
                bunifuDropdown1.Items.Add(new CBBitem
                {
                    Value = i.id_route,
                    Text = i.departure + "-" + i.arrival


                });

            }
            List<DTO_vehicle> list1 = BLL_vehicle.Instance.getallvehicle();
            foreach (var i in list1)
            {
                bunifuDropdown2.Items.Add(new CBBitem
                {
                    Value = i.id_vehicle,
                    Text = i.name


                });

            }
            if (BLL_delRoute.Instance.GetsvByid_detroute(id_detroute) != null)
            {
                DTO_delRoute_xl dd = new DTO_delRoute_xl();
                dd = BLL_delRoute.Instance.GetsvByid_detroute(id_detroute);
                bunifuTextBox1.Text = dd.id_delroute;
                bunifuTextBox2.Text = dd.time_start.ToLongTimeString();
                bunifuTextBox3.Text = dd.price.ToString();
                bunifuDatePicker1.Value = dd.date;
                bunifuDropdown1.SelectedIndex = Convert.ToInt32(dd.id_route) - 1;
                bunifuDropdown2.SelectedIndex = Convert.ToInt32(dd.id_vehicle) - 1;
                if (bunifuTextBox1.Text != "")
                {
                    bunifuTextBox1.ReadOnly = true;

                }
                bunifuDropdown1.DropDownStyle = ComboBoxStyle.DropDownList;
                bunifuDropdown2.DropDownStyle = ComboBoxStyle.DropDownList;

            }

        }

        

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            DTO_delRoute_xl s = new DTO_delRoute_xl();
            s.id_delroute = bunifuTextBox1.Text;
            s.id_route = ((CBBitem)bunifuDropdown1.SelectedItem).Value;
            s.id_vehicle = ((CBBitem)bunifuDropdown2.SelectedItem).Value;
            s.time_start = Convert.ToDateTime(bunifuTextBox2.Text);
            s.price = Convert.ToDouble(bunifuTextBox3.Text);
            s.date = bunifuDatePicker1.Value;
            BLL_delRoute.Instance.execute(s);

            d(((CBBitem)bunifuDropdown1.SelectedItem).Value, "");
        }
    }
}
