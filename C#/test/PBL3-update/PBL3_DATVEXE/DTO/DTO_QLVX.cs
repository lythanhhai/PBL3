using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DTO
{
    class DTO_QLVX
    {
        public string id_order { get; set; }
        public DateTime date_order { get; set; }
        public string date_route { get; set; }
        public string name_person { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int number_ticket { get; set; }
        public double total_price { get; set; }
        public string vehicle { get; set; }// name_vehicle
        public string order_seat { get; set; }// name_seat// liet ke tat ca neu dat nhieu hon 1 ve
        public string route { get; set; }// name_route "den-di"
        public static bool comparenum(object s1, object s2)
        {
            if (((DTO_QLVX)s1).number_ticket> ((DTO_QLVX)s2).number_ticket)
                return true;
            else return false;
        }
        public static bool comparenpr(object s1, object s2)
        {
            if (((DTO_QLVX)s1).total_price > ((DTO_QLVX)s2).total_price)
                return true;
            else return false;
        }

    }
}
