using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.BLL
{
    class BLL_QLVX
    {
        private static BLL_QLVX _Instance;

        public static BLL_QLVX Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLVX();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public List<DTO_QLVX> getallQLVX()
        {
            return DAL_QLVX.Instance.getallQLVX();

        }
      /*  public List<DTO_QLVX> getQLVXBY(string route, string vehicle, string date_route)
        {
            List<DTO_QLVX> data = new List<DTO_QLVX>();
            foreach (DTO_QLVX i in DAL_QLVX.Instance.getallQLVX())
            {
                if (i.route.Contains(route) && i.vehicle.Contains(vehicle) && i.date_route.Contains(date_route))
                {
                    data.Add(new DTO_QLVX
                    {
                        id_order = i.id_order,
                        date_order = i.date_order,
                        date_route = i.date_route,
                        name_person = i.name_person,
                        phone = i.phone,
                        address = i.address,
                        email = i.email,
                        number_ticket = i.number_ticket,
                        total_price = i.total_price,
                        vehicle = i.vehicle,
                        order_seat = i.order_seat,
                        route = i.route

                    });

                }
               
            }
            return data;
        }*/
        public List<DTO_QLVX> getQLVXBY1(string route, string vehicle, string date_route,string name_person )
        {
            List<DTO_QLVX> data = new List<DTO_QLVX>();
            foreach (DTO_QLVX i in DAL_QLVX.Instance.getallQLVX())
            {
                if (i.route.Contains(route) && i.vehicle.Contains(vehicle) && i.date_route.Contains(date_route)&& (i.name_person.Contains(name_person)||i.phone.Contains(name_person)))
                {
                    data.Add(new DTO_QLVX
                    {
                        id_order = i.id_order,
                        date_order = i.date_order,
                        date_route = i.date_route,
                        name_person = i.name_person,
                        phone = i.phone,
                        address = i.address,
                        email = i.email,
                        number_ticket = i.number_ticket,
                        total_price = i.total_price,
                        vehicle = i.vehicle,
                        order_seat = i.order_seat,
                        route = i.route

                    });

                }

            }
            return data;
        }
        public int tt(string route, string vehicle, string date_route, string name)
        {
            int a = 0;
            foreach(DTO_QLVX i in BLL_QLVX.Instance.getQLVXBY1(route,vehicle,date_route,name))
            {
                a = a + i.number_ticket;
            }
            return a;
        }
        public double tp(string route, string vehicle, string date_route,string name)
        {
            double b = 0;
            foreach (DTO_QLVX i in BLL_QLVX.Instance.getQLVXBY1(route, vehicle, date_route,name))
            {
                b = b + i.total_price;
            }
            return b;
        }
        public List<DTO_QLVX> sort(Compare cmp, string route, string vehicle, string date_route, string name)
        {
            List<DTO_QLVX> data = BLL_QLVX.Instance.getQLVXBY1(route, vehicle, date_route, name);
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (cmp(data[i], data[j]))
                    {
                        DTO_QLVX t = data[i];
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
