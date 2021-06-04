using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_DATVEXE.View
{
    public partial class buttonAccount : UserControl
    {
        private bool Check = false;
        public buttonAccount()
        {
            InitializeComponent();
        }
        public void resret()
        {
            Check = false;
            pictureBox1.Location = new Point(3, 3);
            label1.Location = new Point(69, 17);
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if(Check==false)
            {
                pictureBox1.Location = new Point(3, 3);
                label1.Location = new Point(69, 17);
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Check==false)
            {
                pictureBox1.Location = new Point(115, 3);
                label1.Location = new Point(3, 15);
            }
        }

        private void buttonAccount_MouseDown(object sender, MouseEventArgs e)
        {
            Check = true;
            pictureBox1.Location = new Point(115, 3);
            label1.Location = new Point(3, 15);
        }
    }
}
