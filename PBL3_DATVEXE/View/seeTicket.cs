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
    public partial class seeTicket : UserControl
    {
        private string _gia;
        private string _nameGhe;

        public string Gia
        { 
            get
            {
                return lbGia.Text;
            }          
            set
            {
                lbGia.Text = value;
            }
        }
        public string NameGhe
        {
            get
            {
                return lbNameGhe.Text;
            }
            set
            {
                lbNameGhe.Text = value;
            }
        }
        public seeTicket()
        {
            InitializeComponent();
        }


    }
}
