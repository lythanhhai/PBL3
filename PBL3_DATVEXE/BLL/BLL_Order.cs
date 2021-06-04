using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.BLL
{
    class BLL_Order
    {
        private static BLL_Order _Instance = null;
        public static BLL_Order Instance
        {
            get
            {
                if (_Instance == null) return new BLL_Order();
                return _Instance;
            }
             private set
            {

            }
        } 
        BLL_Order()
        {

        }
        public List<Order> GetHistory(string Id)
        {
            List<Order> list = new List<Order>();
            foreach(Order i in DAL_Order.Instance.GetList( Id))
            {
                list.Add(i);
            }
            return list;
        }
    }
}
