using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.BLL
{
    class BLL_TKVX
    {
        private static BLL_TKVX _Instance;

        public static BLL_TKVX Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_TKVX();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        // lấy tất cả xe
        public List<Vehicle> getAllXe_BLL()
        {
            return DAL_TKVX.Instance.getALLXe_DAL();
        }
        public string getid(string order)
        {
            return DAL_TKVX.Instance.getidperson(order);
        }
        // lấy tất cả tuyến mà người dùng đã chọn
        public List<Detail> getALLDetailSchedule_BLL(string departure1, string arrival1, DateTime date1)
        {
            return DAL_TKVX.Instance.getDetailSchedule_DAL(departure1,arrival1,date1);
        }
        // sắp xếp từ dal
        public List<Detail> Sort_BLL(DAL_TKVX.myDel d, string departure1, string arrival1, DateTime date1)
        {
            return DAL_TKVX.Instance.Sort_DAL(d, departure1, arrival1, date1);
        }

        // thêm thông tin người dùng
        public void addPerson_BLL(string id_person, string id_login, string name, string phone, string address, string email)
        {
            DAL_TKVX.Instance.addPerson_DAL(id_person,id_login,name,phone,address,email);
        }

        //lấy ghế từ dal
        public List<Seat> getAllGhe_BLL()
        {
            return DAL_TKVX.Instance.getALLGhe_DAL();
        }

        // thêm order
        public void addOrder_BLL(string id_order, string id_person, int numberTicket, double total_price, DateTime date_order)
        {
            DAL_TKVX.Instance.addOrder_DAL(id_order, id_person, numberTicket, total_price, date_order);
        }

        // lấy danh sách tên ghế từ DAL
        public List<Seat> getGhebyXe_BLL(string id_vehicle)
        {
            return DAL_TKVX.Instance.getGheByXe_DAL(id_vehicle);
        }

        // lấy tất cả khách
        public List<Person> getALlKhach_BLL()
        {
            return DAL_TKVX.Instance.getALlKhachHang_DAL();
        }
        // lấy tất cả order
        public List<Order> getallorder()
        {
            return DAL_TKVX.Instance.getALlOrder_DAL();
        }
        public List<Order> getallorder1(string id_order)
        {
            List<Order> data = new List<Order>();
            foreach (Order i in DAL_TKVX.Instance.getALlOrder_DAL())
            {
                if (i.id_order.Contains(id_order))
                {

                    data.Add(new Order
                    {
                        id_order = i.id_order,
                        id_person = i.id_person,
                        numberTicket = i.numberTicket,
                        total_price=i.total_price,
                        date_order=i.date_order
                    }) ;
                }
            }
            return data;

        }
        // lấy id_order max trong dal để khi push vào bảng Order không bị trùng khóa
        public string getMaxIdOrder_BLL()
        {
            return DAL_TKVX.Instance.getMaxIdOrder();
        }
        // lấy id_person max trong dal để khi push vào bảng Person không bị trùng khóa
        public string getMaxIdPerson_BLL()
        {
            return DAL_TKVX.Instance.getMaxIdPerson();
        }
        // lấy tất cả chi tiết tuyến
        public List<DetailRoute> getAllChiTietTuyen_BLL()
        {
            return DAL_TKVX.Instance.getALLChiTietTuyen_DAL();
        }
        // cập nhật chi tiết tuyến nếu thời gian hiện tại đã quá thời gian trong chi tiết tuyến
        public void updateDetailRoute_BLL(string id_detRoute)
        {
            DAL_TKVX.Instance.updateDetailRoute_DAL(id_detRoute);
        }

        // lấy tất cả orderSeat
        public List<orderSeat> getAllOrderSeat_BLL()
        {
            return DAL_TKVX.Instance.getAllOrderSeat_DAL();
        }

        // update orderSeat from order
        public void updateOrderSeat_BLL(int id_orderSeat,string id_order)
        {
            DAL_TKVX.Instance.updateOrderSeat_DAL(id_orderSeat, id_order);
        }
        // lấy tất cả login 
        public List<Login> getAllLogin_BLL()
        {
            return DAL_TKVX.Instance.getAllLogin();
        }
        // lấy id_login max
        public string getIdLoginMax_BLL()
        {
            return DAL_TKVX.Instance.getId_login();
        }
        //thêm tài khoản
        public void insertLogin_BLL(string id_login , string userName, string passWord)
        {
            DAL_TKVX.Instance.insertLogin(id_login, userName, passWord);
        }
        public List<Information_Order> showinformation_order(string id_order)
        {
            return DAL_TKVX.Instance.getall_Order(id_order);
        }
        public List<Information_Order> showinformation_order()
        {
            return DAL_TKVX.Instance.getall_Order();
        }
        public List<Information_Order> showinformation_ordersearch(string id_order)
        {
            return DAL_TKVX.Instance.getall_Ordersearch(id_order);
        }
        public  List<Information_Order> Search_information_Day(string day1,string day2)
        {
            return DAL_TKVX.Instance.getall_Ordersearch_Day(day1,day2);
        }
    }
}
