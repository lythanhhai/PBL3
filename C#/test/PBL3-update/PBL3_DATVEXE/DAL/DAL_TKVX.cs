using PBL3_DATVEXE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DAL
{
    class DAL_TKVX
    {
        private static DAL_TKVX _Instance;

        public static DAL_TKVX Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_TKVX();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        // lấy tất cả xe trong nhà xe hiện tại
        public List<Vehicle> getALLXe_DAL()
        {
            List<Vehicle> list = new List<Vehicle>();
            //string query = "select * from Vehicle";
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from Vehicle").Rows)
            {
                list.Add(new Vehicle
                {
                    id_vehicle = i["id_vehicle"].ToString(),
                    type = i["type"].ToString(),
                    name = i["name"].ToString(),
                    number_seat = Convert.ToInt32(i["number_seat"].ToString()),
                    status_vehicle = Convert.ToBoolean(i["status_vehicle"].ToString()),
                });
            }
            return list;
        }

        // lấy tất cả các tuyến 
        public List<Route> getALLTuyen_DAL()
        {
            List<Route> list = new List<Route>();
            //string query = "select * from Vehicle";
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from Route").Rows)
            {
                list.Add(new Route
                {
                    id_route = i["id_route"].ToString(),
                    departure = i["departure"].ToString(),
                    arrival = i["arrival"].ToString(),
                    deleted = Convert.ToBoolean(i["deleted"].ToString()),
                });
            }
            return list;
        }

        // lấy tất cả các chi tiết tuyến
        public List<DetailRoute> getALLChiTietTuyen_DAL()
        {
            List<DetailRoute> list = new List<DetailRoute>();
            //string query = "select * from Vehicle";
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from DetailRoute").Rows)
            {
                list.Add(new DetailRoute
                {
                    id_delRoute = i["id_detRoute"].ToString(),
                    id_route = i["id_route"].ToString(),
                    id_vehicle = i["id_vehicle"].ToString(),
                    date = Convert.ToDateTime(i["date"].ToString()),
                    price = Convert.ToDouble(i["price"].ToString()),
                    time_start = Convert.ToDateTime(i["time_start"].ToString()),
                    deleted = Convert.ToBoolean(i["deleted"].ToString()),
                });
            }
            return list;
        }
        // lấy tất cả ghế
        public List<Seat> getALLGhe_DAL()
        {
            List<Seat> list = new List<Seat>();
            //string query = "select * from Vehicle";
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from Seat").Rows)
            {
                list.Add(new Seat
                {
                    id_seat = i["id_seat"].ToString(),
                    id_vehicle = i["id_vehicle"].ToString(),
                    name_seat = i["name_seat"].ToString(),

                });
            }
            return list;
        }
        // lấy tất cả orderSeat
        public List<orderSeat> getAllOrderSeat_DAL()
        {
            List<orderSeat> list = new List<orderSeat>();
            //string query = "select * from Vehicle";
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from orderSeat").Rows)
            {
                list.Add(new orderSeat
                {
                    id_orderSeat = Convert.ToInt32(i["id_orderSeat"].ToString()),
                    id_detRoute = i["id_detRoute"].ToString(),
                    //id_vehicle = i["id_vehicle"].ToString(), 3
                    id_seat = i["id_seat"].ToString(),
                    status = Convert.ToBoolean(i["status"].ToString()),
                    id_order = i["id_order"].ToString(),

                });
            }
            return list;
        }

        // hiện detail tuyến trên form detailSchedule
        public List<Detail> getDetailSchedule_DAL(string departure1, string arrival1, DateTime date1)
        {

            // lấy tuyến mà khách hàng chọn.
            List<Route> listRoute = new List<Route>();
            foreach (Route i in getALLTuyen_DAL())
            {
                if (i.departure == departure1 && i.arrival == arrival1 && i.deleted != true)
                {
                    listRoute.Add(i);
                }
            }

            // lấy cá chi tiết tuyến của listRoute sau khi có tuyến mà người dùng chọn
            List<DetailRoute> listDetailRoute = new List<DetailRoute>();
            foreach (DetailRoute i in getALLChiTietTuyen_DAL())
            {
                foreach (Route j in listRoute)
                {
                    if (i.id_route == j.id_route && i.deleted != true && i.date == date1)
                    {
                        listDetailRoute.Add(i);
                    }
                }
            }

            // lấy các xe sẽ chạy chi tiết tuyến đó 
            List<Vehicle> listVehicle = new List<Vehicle>();
            foreach (Vehicle i in getALLXe_DAL())
            {
                foreach (DetailRoute j in listDetailRoute)
                {
                    if (i.id_vehicle == j.id_vehicle && i.status_vehicle != true)
                    {
                        listVehicle.Add(i);
                        //break;
                    }
                }
            }


            // trả về các chi tiết tuyến mà người dùng muốn tìm 
            List<Detail> list = new List<Detail>();
            for (int i = 0; i < listDetailRoute.Count; i++)
            {
                // kiểm tra id_vehicle của xe và chi tiết tuyến.
                foreach (Vehicle j in listVehicle)
                {
                    if (listDetailRoute[i].id_vehicle == j.id_vehicle)
                    {
                        // tìm số ghế trống 
                        int gheTrong = j.number_seat;
                        foreach (orderSeat m in getAllOrderSeat_DAL())
                        {
                            if (listDetailRoute[i].id_delRoute == m.id_detRoute && m.status == true)//j.id_vehicle == m.id_vehicle && 
                            {
                                gheTrong--;
                            }
                        }
                        string time = Convert.ToString(listDetailRoute[i].time_start).Substring(9);
                        list.Add(new Detail
                        {
                            id_detRoute = listDetailRoute[i].id_delRoute,
                            id_vehicle = listDetailRoute[i].id_vehicle,
                            type = listVehicle[i].type.ToString(),
                            price = listDetailRoute[i].price,
                            time_start = time,
                            departure = departure1,
                            arrival = arrival1,
                            empty_seat = gheTrong,
                            name = j.name,
                        });
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return list;

        }

        // lấy danh sách Detail chi tiết trên datagridview
        // sắp xếp
        public delegate bool myDel(Object o1, Object o2);
        public List<Detail> Sort_DAL(myDel d, string departure1, string arrival1, DateTime date1)
        {
            List<Detail> list = getDetailSchedule_DAL(departure1, arrival1, date1);
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (d(list[i], list[j]))
                    {
                        Detail temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }

        // lấy tất cả khách hàng 
        public List<Person> getALlKhachHang_DAL()
        {
            List<Person> list = new List<Person>();
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from info_person").Rows)
            {
                list.Add(new Person
                {
                    id_person = i["id_person"].ToString(),
                    id_login = i["id_login"].ToString(),
                    name = i["name"].ToString(),
                    phone = i["phone"].ToString(),
                    address = i["address"].ToString(),
                    email = i["email"].ToString(),
                });
            }
            return list;
        }
        // lấy tất cả order
        public List<Order> getALlOrder_DAL()
        {
            List<Order> list = new List<Order>();
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from [Order]").Rows)
            {
                list.Add(new Order
                {
                    id_order = i["id_order"].ToString(),
                    //id_orderSeat = i["id_orderSeat"].ToString(),

                    //  id_detRoute = i["id_detRoute"].ToString(), 1

                    id_person = i["id_person"].ToString(),
                    numberTicket = Convert.ToInt32(i["numberTicket"].ToString()),
                    total_price = Convert.ToDouble(i["total_price"].ToString()),
                    date_order = Convert.ToDateTime(i["date_order"].ToString()),
                });
            }
            return list;
        }
        // thêm khách hàng
        public void addPerson_DAL(string id_person, string id_login, string name, string phone, string address, string email)
        {
            string query = "insert into info_person(id_person,id_login,name,phone,address,email) values (N'"
                + id_person
                + "',N'"
                + id_login
                + "',N'"
                + name
                + "',N'"
                + phone
                + "',N'"
                + address
                + "',N'" +
                email
                + "')";
            DBHelper.Instance.executeQuery(query);
        }
        // thêm order

        public void addOrder_DAL(string id_order, string id_person, int numberTicket, double total_price, DateTime date_order)//2
        {
            string query = "INSERT INTO [Order](id_order,id_person,numberTicket,total_price,date_order) values "
                + "(N'"
                + id_order
                + "',N'"
                + id_person
                + "','"
                + Convert.ToString(numberTicket)
                + "','"
                + Convert.ToString(total_price)
                + "','"
                + Convert.ToString(date_order)
                + "')";

            DBHelper.Instance.executeQuery(query);
        }

        public void updateDetailRoute_DAL(string id_detRoute)
        {
            string query = "Update DetailRoute set deleted = 1 where id_detRoute = " + id_detRoute;

            DBHelper.Instance.executeQuery(query);
        }





        // lấy danh sách các ghê theo id_vehicle.
        public List<Seat> getGheByXe_DAL(string id_vehicle)
        {
            List<Seat> list = new List<Seat>();
            foreach (Vehicle i in getALLXe_DAL())
            {
                if (i.id_vehicle == id_vehicle)
                {
                    foreach (Seat j in getALLGhe_DAL())
                    {
                        if (i.id_vehicle == j.id_vehicle)
                        {
                            list.Add(j);
                        }
                    }
                }
                else
                {
                    continue;
                }

            }
            return list;
        }

        // tìm id_order max trong danh sách order hiện tại 
        public string getMaxIdOrder()
        {
            string idOrder = "";
            int Max = 0;
            foreach (Order i in getALlOrder_DAL())
            {
                if (Convert.ToInt32(i.id_order) > Max)
                {
                    Max = Convert.ToInt32(i.id_order);
                }
            }
            idOrder = Convert.ToString(Max);
            return idOrder;
        }

        // tìm id_person max trong danh sách person hiện tại 
        public string getMaxIdPerson()
        {
            string idPerson = "";
            int Max = 0;
            foreach (Person i in getALlKhachHang_DAL())
            {
                if (Convert.ToInt32(i.id_person) > Max)
                {
                    Max = Convert.ToInt32(i.id_person);
                }
            }
            idPerson = Convert.ToString(Max);
            return idPerson;
        }

        // update orderSeat sau khi order
        public void updateOrderSeat_DAL(int id_orderSeat, string id_order)
        {
            string query = "Update orderSeat set status = 1,id_order = " + "'" + id_order + "'" + " where id_orderSeat = " + id_orderSeat.ToString();
            DBHelper.Instance.executeQuery(query);
        }

        // lấy tất cả login 
        public List<Login> getAllLogin()
        {
            List<Login> list = new List<Login>();
            foreach (DataRow i in DBHelper.Instance.executeNonQuery("select * from Login").Rows)
            {
                list.Add(new Login
                {
                    id_login = i["id_login"].ToString(),
                    userName = i["userName"].ToString(),
                    passWord = i["passWord"].ToString(),
                    row = Convert.ToInt32(i["row"].ToString()),
                });
            }
            return list;
        }

        // lấy id_login max
        public string getId_login()
        {
            string id_login = "";
            int Max = 0;
            List<Login> list = getAllLogin();
            foreach (Login i in list)
            {
                if (Convert.ToInt32(i.id_login) > Max)
                {
                    Max = Convert.ToInt32(i.id_login);
                }
            }
            id_login = Convert.ToString(Max);
            return id_login;
        }
        // thêm login khi đăng ký
        public void insertLogin(string id_login, string username, string passWord)
        {
            string query = "Insert into Login values('"
                + id_login
                + "','"
                + username
                + "','"
                + passWord
                + "',"
                + "1)";

            DBHelper.Instance.executeQuery(query);
        }
        public List<historyBook> getHistoryBook()
        {
            List<historyBook> list = new List<historyBook>();

            foreach (Person i in getALlKhachHang_DAL())
            {
                if (Properties.Settings.Default.id_login == i.id_login)
                {
                    foreach (Order j in getALlOrder_DAL())
                    {
                        if (i.id_person == j.id_person)
                        {
                            foreach (orderSeat k in getAllOrderSeat_DAL())
                            {
                                if (j.id_order == k.id_order)
                                {
                                    foreach (DetailRoute l in getALLChiTietTuyen_DAL())
                                    {
                                        if (k.id_detRoute == l.id_delRoute)
                                        {
                                            foreach (Route m in getALLTuyen_DAL())
                                            {
                                                if (m.id_route == l.id_route)
                                                {
                                                    list.Add(new historyBook
                                                    {
                                                        numberTicket = j.numberTicket,
                                                        date_order = j.date_order,
                                                        total_price = j.total_price,
                                                        departure = m.departure,
                                                        arrival = m.arrival,
                                                        date = l.date,
                                                    }
                                                    );
                                                    break;
                                                }
                                            }
                                            break;
                                        }

                                    }
                                    break;
                                }

                            }
                            break;
                        }


                    }
                }

            }
            return list;
        }
    }
}
