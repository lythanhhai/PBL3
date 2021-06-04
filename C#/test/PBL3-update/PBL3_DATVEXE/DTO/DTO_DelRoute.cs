using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DTO
{
    class DTO_DelRoute
    {
        public string id_delroute { get; set; }
        public string route { get; set; }
        public string vehicle { get; set; }
        public DateTime date { get; set; }
        public string time_start { get; set; }
        public double price { get; set; }
        public bool deleted { get; set; }
        public static bool compareid(object s1, object s2)
        {
            if (String.Compare(((DTO_DelRoute)s1).id_delroute, ((DTO_DelRoute)s2).id_delroute) > 0)
                return true;
            else return false;
        }
        public static bool compareroute(object s1, object s2)
        {
            if (String.Compare(((DTO_DelRoute)s1).route, ((DTO_DelRoute)s2).route) > 0)
                return true;
            else return false;
        }
        public static bool comparevehicle(object s1, object s2)
        {
            if (String.Compare(((DTO_DelRoute)s1).vehicle, ((DTO_DelRoute)s2).vehicle) > 0)
                return true;
            else return false;
        }
        public static bool comparetime(object s1, object s2)
        {
            if (String.Compare(((DTO_DelRoute)s1).time_start, ((DTO_DelRoute)s2).time_start) > 0)
                return true;
            else return false;
        }
        public static bool Comparedate(object s1, object s2)
        {
            if (DateTime.Compare(((DTO_DelRoute)s1).date, ((DTO_DelRoute)s2).date) >= 0)
                return true;
            else return false;
        }
        public static bool comparenumber(object s1, object s2)
        {
            if (((DTO_DelRoute)s1).price > ((DTO_DelRoute)s2).price)
                return true;
            else return false;
        }
        public static bool Comparedele(object s1, object s2)
        {
            if (!((DTO_DelRoute)s1).deleted && ((DTO_DelRoute)s2).deleted)
                return true;
            else return false;
        }
    }
}
