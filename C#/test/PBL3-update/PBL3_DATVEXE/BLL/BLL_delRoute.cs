using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;
using System.Data;
using System.Data.SqlClient;

namespace PBL3_DATVEXE.BLL
{
    class BLL_delRoute
    {
        private static BLL_delRoute _Instance;

        public static BLL_delRoute Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_delRoute();
                return _Instance;
            }
            private set { }
        }
        private BLL_delRoute()
        {

        }
        public string doiRoute(string id_Route)
        {
            string route = "";
            foreach (DTO_route i in DALL_route.Instance.getallroute())
            {
                if (i.id_route == id_Route)
                {
                    route = (i.departure.ToString() +"-"+ i.arrival.ToString());
                }
            }
            return route;
        }
        public string doivehicle(string id_vehicle)
        {
            string vehicle = "";
            foreach (DTO_vehicle i in DALL_vehicle.Instance.getallvehicle())
            {
                if (i.id_vehicle == id_vehicle)
                {
                    vehicle = i.name.ToString();
                }
            }
            return vehicle;
        }
        public List<DTO_DelRoute> getallDetRoute()
        {
            List<DTO_DelRoute> data = new List<DTO_DelRoute>();
            foreach (DTO_delRoute_xl i in DAL_DelRoute.Instance.getalldelroute_xl())
            {

                data.Add(new DTO_DelRoute
                {
                    id_delroute = i.id_delroute,
                    route = doiRoute(i.id_route),
                    vehicle = doivehicle(i.id_vehicle),
                    date = i.date,
                    price = i.price,
                    time_start = i.time_start.ToLongTimeString(),
                    deleted = i.deleted

                });


            }
            return data;
            }
        public List<DTO_DelRoute> getListdelroute_BLL(string  id_route, string name)
        {

            List<DTO_DelRoute> data = new List<DTO_DelRoute>();
            foreach (DTO_delRoute_xl i in DAL_DelRoute.Instance.getalldelroute_xl())
            {
                
                    if (i.id_route == id_route && doivehicle(i.id_vehicle).Contains(name))
                    {
                        data.Add(new DTO_DelRoute
                        {
                            id_delroute = i.id_delroute,
                            route = doiRoute(i.id_route),
                            vehicle = doivehicle(i.id_vehicle),
                            date = i.date,
                            price = i.price,
                            time_start = i.time_start.ToLongTimeString(),
                            deleted = i.deleted

                        });

                    }
                
                if (id_route == "0" && name=="")
                {
                    data.Add(new DTO_DelRoute
                    {
                        id_delroute = i.id_delroute,
                        route = doiRoute(i.id_route),
                        vehicle = doivehicle(i.id_vehicle),
                        date = i.date,
                        price = i.price,
                        time_start = i.time_start.ToLongTimeString(),
                        deleted = i.deleted

                    }) ;

                }
                if (id_route == "0" && name != "")
                {
                    if ( doivehicle(i.id_vehicle).Contains(name))
                    {
                        data.Add(new DTO_DelRoute
                        {
                            id_delroute = i.id_delroute,
                            route = doiRoute(i.id_route),
                            vehicle = doivehicle(i.id_vehicle),
                            date = i.date,
                            price = i.price,
                            time_start = i.time_start.ToLongTimeString(),
                            deleted = i.deleted

                        });

                    }
                }    


            }
            return data;
        }
        
       
        public string getmssv()
        {
            string a = "";
            return a;
        }
        

        public DTO_delRoute_xl GetsvByid_detroute(string id_delroute)
        {
            if (id_delroute == null)
                return null;
            else
            {
                DTO_delRoute_xl s = new DTO_delRoute_xl();
                foreach (DTO_delRoute_xl i in DAL_DelRoute.Instance.getalldelroute_xl())
                {
                    if (i.id_delroute == id_delroute)
                    { s = i; }
                }
                return s;
            }
        }


        public void deleteSV_BLL(string ms)
        {
            foreach (DTO_delRoute_xl i in DAL_DelRoute.Instance.getalldelroute_xl())
            {
                if (i.id_delroute == ms)
                {
                    DAL_DelRoute.Instance.deletedelRoute_DALL(i);
                }
            }
        }
        
        public void execute(DTO_delRoute_xl s)
        {
            bool check = false;
            foreach (DTO_delRoute_xl i in DAL_DelRoute.Instance.getalldelroute_xl())
            {
                if (i.id_delroute == s.id_delroute)
                {
                    check = true;
                }

            }
            if (check)
            {
                DAL_DelRoute.Instance.updatedelRoutebyid_delroute(s);

            }
            else
            {
                DAL_DelRoute.Instance.adddelroute_DAL(s);
            }
        }

        public List<DTO_DelRoute> sort(Compare cmp, string id_route, string name)
        {
            List<DTO_DelRoute> data = BLL_delRoute.Instance.getListdelroute_BLL(id_route, name);
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (cmp(data[i], data[j]))
                    {
                        DTO_DelRoute t = data[i];
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
