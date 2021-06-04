using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using PBL3_DATVEXE.BLL;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.View
{
    public partial class AccountInformaition : UserControl
    {
        private Panel panelll;
        private BunifuDataGridView dataGridVieww;
        public AccountInformaition()
        {
            InitializeComponent();
            Person obj = new Person();
            obj = BLL_Person.Instance.GetPerson("11");//IdUser
            txtBHovaten.Text = obj.name;
            txtBSDT.Text = obj.phone;
            txtBemail.Text = obj.email;
            txtBAdress.Text = obj.address;
        }
        private string IdUser=null;
        public void SetIdUser(string Id)
        {
            IdUser = Id;
        }
        public String GetIdUser()
        {
            return IdUser;
        }
        private DataTable ListTicket { get; set; }
        private void bunifuRadioButton1_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {

        }
        public void Reset()
        {   
            if(panelll!= null)
            {
                Controls.Remove(panelll);
            }
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            if(panel1.Visible==false)
            panel1.Visible = true;
           

        }
        private void label1_Click(object sender, EventArgs e)
        {
            Reset();
            label1.ForeColor = Color.DodgerBlue;
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            panel1.Visible = false;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.DodgerBlue;
            //ListTicket = new DataTable();
            //ListTicket.Columns.Add("Mã thanh toán", typeof(string));
            //ListTicket.Columns.Add("Số vé", typeof(int));
            //ListTicket.Columns.Add("Tổng", typeof(float));
            //ListTicket.Columns.Add("Ngày", typeof(DateTime));
            //foreach(Order i in BLL_Order.Instance.GetHistory("11"))//IdUser
            //{
            //    DataRow dr = ListTicket.NewRow();
            //    dr["Mã thanh toán"] = i.id_order;
            //    dr["Số vé"] = i.numberTicket;
            //    dr["Tổng"] = i.total_price;
            //    dr["Ngày"] = i.date_order;
            //    ListTicket.Rows.Add(dr);
            //}
            //panelll = new Panel();
            //panelll.Location = new System.Drawing.Point(250, 105);
            //panelll.Name = "";
            //panelll.Size = new System.Drawing.Size(500, 297);
            //panelll.BackColor = Color.White;
            //panelll.BorderStyle = BorderStyle.None;

            //dataGridVieww = new BunifuDataGridView();
            //dataGridVieww.Location = new Point(3, 3);
            //dataGridVieww.Size = new Size(500, 297);
            //dataGridVieww.BackgroundColor = Color.White;
            //dataGridVieww.DataSource = ListTicket;
            //panelll.Controls.Add(dataGridVieww);
            //Controls.Add(panelll);
            
        }

        private void dataGridviewVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
