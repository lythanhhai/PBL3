using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.DAL
{
    class DAL_Order
    {
        private static DAL_Order _Instance = null;

        public static DAL_Order Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DAL_Order();
                return _Instance;
            }
            private set { }
        }
        private DAL_Order()
        {

        }
        public List<Order> GetList(string Id)
        {
            List<Order> list = new List<Order>();
            string sql = "select * from [MVH_07].[dbo].[Order] where id_person='"+Id+"'";
            foreach(DataRow i in DB_H.Instance.get(sql).Rows)
            {
                Order obj = new Order
                {
                    id_order = i["id_order"].ToString(),
                    id_person = i["id_person"].ToString(),
                    numberTicket = Convert.ToInt32(i["numberTicket"].ToString()),
                    total_price = Convert.ToDouble(i["total_price"].ToString()),
                    date_order = Convert.ToDateTime(i["date_order"].ToString())
                };
                list.Add(obj);
            }
            return list;
        }
    }
}
