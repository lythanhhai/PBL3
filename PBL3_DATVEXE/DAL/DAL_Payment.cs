using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.DAL
{
    public class DAL_Payment
    {
        private static DAL_Payment _Instance = null;
        public static DAL_Payment Instance { 
            get {
                if (_Instance == null) return new DAL_Payment();
                return _Instance;
            } 
            private set { }
        }
        private DAL_Payment()
        {

        }
       
        public List<Payment> Getpayment()
        {
            string sql ="select * from [MVH_07_DEMO].[dbo].[info_person]";
            List<Payment> l = new List<Payment>();
            
            foreach(DataRow i in DB_H.Instance.get(sql).Rows)
            {
                bool T;
                
                if (i["permission"] == null) { T=false; }
                else
                    if (i["permission"].ToString() == "1")
                    {
                    
                        T=true;
                    }
                    else T=false;
                Payment obj = new Payment
                {
                    id_login = i["id_login"].ToString(),
                    id_person = Convert.ToString(Convert.ToInt32(i["id_person"].ToString())),
                    permission = T
                };
                l.Add(obj);
            }
            return l;
        } 
    }
}
