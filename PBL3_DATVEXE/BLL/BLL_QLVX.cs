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
        List<DTO_QLVX1> dataa = DAL_QLVX.Instance.getallQLVX();


        public List<DTO_QLVX1> getallQLVX()
        {
            return DAL_QLVX.Instance.getallQLVX();

        }
          public List<DTO_QLVX> getQLVXBY(string route, string vehicle, string name_person)
          {
              List<DTO_QLVX> data = new List<DTO_QLVX>();
            foreach (DTO_QLVX1 i in dataa)
            {
                
                    if (i.route.Contains(route) && i.vehicle.Contains(vehicle) && (i.name_person.Contains(name_person) || i.phone.Contains(name_person)))
                    {
                        data.Add(new DTO_QLVX
                        {
                            id_order = i.id_order,
                            //   date_order = i.date_order,
                            //  date_route = i.date_route,
                            name_person = i.name_person,
                            phone = i.phone,
                            //  address = i.address,
                            //  email = i.email,
                            number_ticket = i.number_ticket,
                            total_price = i.total_price,
                            // vehicle = i.vehicle,
                            order_seat = i.order_seat,
                            // route = i.route

                        });

                    }
                }


                return data;
          }
        public List<DTO_QLVX> getQLVXBY1(string route, string vehicle, DateTime a, DateTime b, string name_person)
        {
            List<DTO_QLVX> data = new List<DTO_QLVX>();
            foreach (DTO_QLVX1 i in dataa)
            {
                
               

                    if (DateTime.Compare(a, i.date_order) < 0 && DateTime.Compare(b, i.date_order) > 0)
                    {



                        if (i.route.Contains(route) && i.vehicle.Contains(vehicle) && (i.name_person.Contains(name_person) || i.phone.Contains(name_person)))
                        {
                            data.Add(new DTO_QLVX
                            {
                                id_order = i.id_order,

                                name_person = i.name_person,
                                phone = i.phone,

                                number_ticket = i.number_ticket,
                                total_price = i.total_price,

                                order_seat = i.order_seat,


                            });

                        }

                    }
                
               
            }
            return data;
        }
        public int tt(string route, string vehicle, DateTime c, DateTime b, string name)
        {
            int a = 0;
            foreach (DTO_QLVX i in BLL_QLVX.Instance.getQLVXBY1(route, vehicle, c,b, name))
            {
                a = a + i.number_ticket;
            }


            return a;
        }
        public double tp(string route, string vehicle, DateTime a, DateTime c, string name)
        {
            double b = 0;
            foreach (DTO_QLVX i in BLL_QLVX.Instance.getQLVXBY1(route, vehicle, a,c,name))
            {
                b = b + i.total_price;
            }
            return b;
        }
     /*   public List<DTO_QLVX> sort(Compare cmp, string route, string vehicle, string date_route, string name)
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
     */
    }
     
}
