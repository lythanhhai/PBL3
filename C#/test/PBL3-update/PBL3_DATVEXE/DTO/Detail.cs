using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PBL3_DATVEXE.DTO
{
    class Detail
    {
        public string id_detRoute{ get; set; }

        public string id_vehicle { get; set; }
        public string time_start { get; set; }

        public string type { get; set; }
        public string departure { get; set; }

        public string arrival { get; set; }

        public string name { get; set; }

        public int empty_seat { get; set; }

        public double price { get; set; }

        public static bool ComparePriceIncre(Object o1,Object o2)
        {
            return ((Detail)o1).price > ((Detail)o2).price;
        }
        public static bool ComparePriceDecre(Object o1, Object o2)
        {
            return ((Detail)o1).price < ((Detail)o2).price;
        }

        public static bool CompareTimeIncre(Object o1, Object o2)
        {
            
            DateTime date1 = Convert.ToDateTime(((Detail)o1).time_start);
            DateTime date2 = Convert.ToDateTime(((Detail)o2).time_start);
            //if (TimeSpan.Compare(date1.TimeOfDay, date2.TimeOfDay) > 0)
            if (DateTime.Compare(date1, date2) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool CompareTimeDecre(Object o1, Object o2)
        {

            DateTime date1 = Convert.ToDateTime(((Detail)o1).time_start);
            DateTime date2 = Convert.ToDateTime(((Detail)o2).time_start);
            //if (TimeSpan.Compare(date1.TimeOfDay, date2.TimeOfDay) > 0)
            if (DateTime.Compare(date1, date2) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
