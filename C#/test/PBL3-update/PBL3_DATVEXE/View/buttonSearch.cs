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
    public partial class buttonSearch : UserControl
    {
        private bool Check = false;
        public buttonSearch()
        {
            InitializeComponent();
        }
        public void reset()
        {
            Check = false;
            pictureBox1.Location = new Point(0, 0);
            label1.Location = new Point(67, 15);
        }
        

      

        private void buttonSearch_MouseLeave(object sender, EventArgs e)
        {
            if (Check == false)
            {
                pictureBox1.Location = new Point(0, 0);
                label1.Location = new Point(67, 15);
            }   
               
        }

        private void buttonSearch_MouseMove(object sender, MouseEventArgs e)
        {
            if (Check == false)
            {
                pictureBox1.Location = new Point(115, 0);
                label1.Location = new Point(3, 15);
            }
        }

        private void buttonSearch_MouseDown(object sender, MouseEventArgs e)
        {
            Check = true;
            pictureBox1.Location = new Point(115, 0);
            label1.Location = new Point(3, 15);
        }
    }
}
