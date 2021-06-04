using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_DATVEXE.DTO;
using System.Data;

using System.Data.SqlClient;

namespace PBL3_DATVEXE.DAL
{
    class DAL_QLVX
    {
        private static DAL_QLVX _Instance;

        public static DAL_QLVX Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_QLVX();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public string doi_date(string id_order)
        {
            string a = "";
            string id_det = "";
            string query = "select * from orderSeat";
            string query1 = "select * from DetailRoute";
            foreach (DataRow i in DB_H.Instance.get(query).Rows)
            {
                if (i["id_order"].ToString() == id_order)
                {
                    id_det = i["id_detRoute"].ToString();
                    foreach (DataRow r in DB_H.Instance.get(query1).Rows)
                    {
                        if (id_det == r["id_detRoute"].ToString())
                        {
                            a = (Convert.ToDateTime(r["date"].ToString())).ToShortDateString() + "--" + (Convert.ToDateTime(r["time_start"].ToString())).ToLongTimeString();
                        }
                    }
                }

            }
            return a;
        }
        public string doipersonvip(string id_person, int i)
        {
            string a = "";
            string query = "select * from info_person";
            foreach (DataRow r in DB_H.Instance.get(query).Rows)
            {
                if (r["id_person"].ToString() == id_person)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                a = r["name"].ToString();
                            }
                            break;
                        case 2:
                            {
                                a = r["phone"].ToString();
                            }
                            break;
                        case 3:
                            {
                                a = r["address"].ToString();
                            }
                            break;
                        case 4:
                            {
                                a = r["email"].ToString();
                            }
                            break;
                    }


                }
            }

            return a;
        }
        public string doiseat(string id_order)
        {
            string a = "";
            string id_seat = "";
            string query = "select * from orderSeat";
            string query1 = "select * from Seat";
            foreach (DataRow i in DB_H.Instance.get(query).Rows)
            {
                if (i["id_order"].ToString() == id_order)
                {
                    id_seat = i["id_seat"].ToString();
                    foreach (DataRow r in DB_H.Instance.get(query1).Rows)
                    {
                        if (id_seat == r["id_seat"].ToString())
                        {
                            a = a + "---" + r["name_seat"].ToString();

                        }

                    }
                }

            }
            return a;

        }
        public string doivehicle(string id_order)
        {
            string a = "";
            string id_det = "";
            string id_vehicle = "";
            string query = "select * from orderSeat";
            string query1 = "select * from DetailRoute";
            string q = "select * from Vehicle";
            foreach (DataRow i in DB_H.Instance.get(query).Rows)
            {
                if (i["id_order"].ToString() == id_order)
                {
                    id_det = i["id_detRoute"].ToString();
                    foreach (DataRow r in DB_H.Instance.get(query1).Rows)
                    {
                        if (id_det == r["id_detRoute"].ToString())
                        {
                            id_vehicle = r["id_vehicle"].ToString();
                            foreach (DataRow d in DB_H.Instance.get(q).Rows)
                            {  if(id_vehicle== d["id_vehicle"].ToString())
                                a = d["name"].ToString();
                            }
                        }
                    }
                }

            }
            return a;
        }
        public string doiroute(string id_order)
        {
            string a = "";
            string id_det = "";
            string id_route = "";
            string query = "select * from orderSeat";
            string query1 = "select * from DetailRoute";
            string q = "select * from Route";
            foreach (DataRow i in DB_H.Instance.get(query).Rows)
            {
                if (i["id_order"].ToString() == id_order)
                {
                    id_det = i["id_detRoute"].ToString();
                    foreach (DataRow r in DB_H.Instance.get(query1).Rows)
                    {
                        if (id_det == r["id_detRoute"].ToString())
                        {
                            id_route = r["id_route"].ToString();
                            foreach (DataRow d in DB_H.Instance.get(q).Rows)
                            { if (id_route == d["id_route"].ToString())
                                {
                                    a = d["departure"].ToString() + "-" + d["arrival"].ToString();
                                }
                            }
                        }
                    }
                }

            }
            return a;
        }
        public List<DTO_QLVX> getallQLVX()
        {

            List<DTO_QLVX> data = new List<DTO_QLVX>();
            string q = "select * from [Order]";
            foreach (DataRow i in DB_H.Instance.get(q).Rows)
            {
                data.Add(getQLVX(i));
            }
            return data;
        }

        public DTO_QLVX getQLVX(DataRow dr)
        {


            return new DTO_QLVX
            {
                id_order = dr["id_order"].ToString(),
                date_order = Convert.ToDateTime(dr["date_order"].ToString()),
                date_route = doi_date(dr["id_order"].ToString()),
                name_person = doipersonvip(dr["id_person"].ToString(), 1),
                phone = doipersonvip(dr["id_person"].ToString(), 2),
                address = doipersonvip(dr["id_person"].ToString(), 3),
                email = doipersonvip(dr["id_person"].ToString(), 4),
                number_ticket = Convert.ToInt32(dr["numberTicket"].ToString()),
                total_price = Convert.ToDouble(dr["total_price"].ToString()),
                vehicle = doivehicle(dr["id_order"].ToString()),
                order_seat = doiseat(dr["id_order"].ToString()),
                route = doiroute(dr["id_order"].ToString())









            };


        }
    }
}

