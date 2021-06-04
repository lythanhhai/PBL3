using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.BLL
{
    class BLL_vehicle
    {
        private static BLL_vehicle _Instance;

        public static BLL_vehicle Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_vehicle();
                return _Instance;
            }
            private set { }
        }
        private BLL_vehicle()
        {

        }

        public List<DTO_vehicle> getallvehicle()
        {
            return DALL_vehicle.Instance.getallvehicle();

        }


        public string getmssv()
        {
            string a = "";
            return a;
        }

        public DTO_vehicle Getid_vehicle(string id_vehicle)
        {
            if (id_vehicle == null)
                return null;
            else
            {
                DTO_vehicle s = new DTO_vehicle();
                foreach (DTO_vehicle i in DALL_vehicle.Instance.getallvehicle())
                {
                    if (i.id_vehicle == id_vehicle)
                    { s = i; }
                }
                return s;
            }
        }
        public void add_vehicle (DTO_vehicle s)
        {
            DALL_vehicle.Instance.addvehicle_DAL(s);
        }
        public void edit(DTO_vehicle s)
        {
            DALL_vehicle.Instance.updatevehiclebyid_vehicle(s);
        }

        public void deletevehicle(string id_vehicle)
        {
            foreach (DTO_vehicle i in DALL_vehicle.Instance.getallvehicle())
            {
                if (i.id_vehicle == id_vehicle)
                {
                    DALL_vehicle.Instance.deleteVehicle_DALL(i);
                }
            }
        }
        public List<DTO_vehicle> sort(Compare cmp)
        {
            List<DTO_vehicle> data = BLL_vehicle.Instance.getallvehicle();
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (cmp(data[i], data[j]))
                    {
                        DTO_vehicle t = data[i];
                        data[i] = data[j];
                        data[j] = t;
                    }
                }
            }
            return data;
        }

        public delegate bool Compare(object s1, object s2);

    }
}
