using PBL3_DATVEXE.DAL;
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
    public partial class historyBook : Form
    {
        public historyBook()
        {
            InitializeComponent();
        }

        private void historyBook_Load(object sender, EventArgs e)
        {
            dtg1.DataSource = DAL_TKVX.Instance.getHistoryBook();
        }
    }
}
