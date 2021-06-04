using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DTO
{
    class DTO_vehicle
    {
        public string id_vehicle { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int number_seat { get; set; }
        public bool status_vehicle { get; set; }
        public static bool compareid(object s1, object s2)
        {
            if (String.Compare(((DTO_vehicle)s1).id_vehicle, ((DTO_vehicle)s2).id_vehicle) > 0)
                return true;
            else return false;
        }
        public static bool comparetype(object s1, object s2)
        {
            if (String.Compare(((DTO_vehicle)s1).type, ((DTO_vehicle)s2).type) > 0)
                return true;
            else return false;
        }
        public static bool comparename(object s1, object s2)
        {
            if (String.Compare(((DTO_vehicle)s1).name, ((DTO_vehicle)s2).name) > 0)
                return true;
            else return false;
        }
        public static bool comparenumber(object s1, object s2)
        {
            if (((DTO_vehicle)s1).number_seat> ((DTO_vehicle)s2).number_seat )
                return true;
            else return false;
        }
        public static bool Comparestatus(object s1, object s2)
        {
            if (!((DTO_vehicle)s1).status_vehicle && ((DTO_vehicle)s2).status_vehicle)
                return true;
            else return false;
        }

    }
}
