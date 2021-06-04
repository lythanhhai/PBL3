using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DTO
{
    public class historyBook
    {
        public int numberTicket { get; set; }

        public DateTime date_order { get; set; }

        public double total_price {get;set;}

        public string departure { get; set; }

        public string arrival { get; set; }

        public DateTime date { get; set; }
    }
}
