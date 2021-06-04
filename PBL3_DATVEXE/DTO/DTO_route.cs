using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DTO
{
    class DTO_route
    {
        public string id_route { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public bool deleted { get; set; }
        public static bool compareid(object s1, object s2)
        {
            if (String.Compare(((DTO_route)s1).id_route, ((DTO_route)s2).id_route) > 0)
                return true;
            else return false;
        }
        public static bool compareid1(object s1, object s2)
        {
            if (String.Compare(((DTO_route)s1).departure, ((DTO_route)s2).departure) > 0)
                return true;
            else return false;
        }
        public static bool compareid2(object s1, object s2)
        {
            if (String.Compare(((DTO_route)s1).arrival, ((DTO_route)s2).arrival) > 0)
                return true;
            else return false;
        }
        public static bool Comparedele(object s1, object s2)
        {
            if (!((DTO_route)s1).deleted && ((DTO_route)s2).deleted)
                return true;
            else return false;
        }
    }
}
