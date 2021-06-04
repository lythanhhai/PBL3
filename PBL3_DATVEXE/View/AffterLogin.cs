using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.View
{
    public partial class AffterLogin : Form
    {

        private SearchRout searchRout;
        private AccountInformaition accountInformaition;
        private Panel dynamicPanel1;
        private Panel dynamicPanel2;
        private IconButton iconButton_Ok;
        public AffterLogin()
        {
            InitializeComponent();
        }

           

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void iconButton_Ok_Click(object sender, EventArgs e)
        {
            ViewSearchRoute viewSearchRoute1 = new ViewSearchRoute();
            viewSearchRoute1 = searchRout.GetSearchRoute();
            MessageBox.Show(viewSearchRoute1.ToString());
                
        }
        private void buttonSearch1_Click(object sender, EventArgs e)
        {
            //buttonAccount1.resret();
            //if (dynamicPanel2 != null)
            //    Controls.Remove(dynamicPanel2);
            //dynamicPanel1 = new Panel();
            //dynamicPanel1.Location = new System.Drawing.Point(170, 0);
            //dynamicPanel1.Name = "";
            //dynamicPanel1.Size = new System.Drawing.Size(997, 609);
            //dynamicPanel1.BackColor = Color.White;
            //dynamicPanel1.BorderStyle = BorderStyle.None;



            //searchRout = new SearchRout();
            //searchRout.Location = new Point(0, 0);
            //dynamicPanel1.Controls.Add(searchRout);
            //iconButton_Ok = new IconButton();
            //iconButton_Ok.BackColor = Color.Turquoise;
            //iconButton_Ok.FlatStyle = FlatStyle.Flat;
            //iconButton_Ok.FlatAppearance.BorderColor = Color.Yellow;
            //iconButton_Ok.FlatAppearance.BorderSize = 1;
            //iconButton_Ok.FlatAppearance.MouseOverBackColor = Color.Yellow;
            //iconButton_Ok.Location = new Point(485, 300);
            //iconButton_Ok.Size = new Size(94, 70);
            //iconButton_Ok.Visible = true;
            //iconButton_Ok.BackgroundImage = global::PBL3_DATVEXE.Properties.Resources.check;
            //iconButton_Ok.BackgroundImageLayout = ImageLayout.Stretch;
            //iconButton_Ok.Click += new System.EventHandler(this.iconButton_Ok_Click);
            //Controls.Add(iconButton_Ok);

            //Controls.Add(dynamicPanel1);
        }

        private void buttonAccount1_Click(object sender, EventArgs e)
        {
            buttonSearch1.reset();
            if (dynamicPanel1 != null)
            {
                Controls.Remove(dynamicPanel1);
                Controls.Remove(iconButton_Ok);
            }
             dynamicPanel2 = new Panel();
            dynamicPanel2.Location = new System.Drawing.Point(170, 0);
            dynamicPanel2.Name = "";
            dynamicPanel2.Size = new System.Drawing.Size(997, 609);
            dynamicPanel2.BackColor = Color.White;
            dynamicPanel2.BorderStyle = BorderStyle.None;

           
            accountInformaition = new AccountInformaition();
            accountInformaition.Location = new Point(0, 0);
            dynamicPanel2.Controls.Add(accountInformaition);
            Controls.Add(dynamicPanel2);
        }



        private void veCuaToi_Click(object sender, EventArgs e)
        {
            historyBook hb = new historyBook();
            hb.Show();
        }
    }
}
