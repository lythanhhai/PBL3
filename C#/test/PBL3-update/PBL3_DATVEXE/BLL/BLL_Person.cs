using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_DATVEXE.DAL;
using PBL3_DATVEXE.DTO;

namespace PBL3_DATVEXE.BLL
{
    class BLL_Person
    {
        private static BLL_Person _Instance = null;
        public static BLL_Person Instance
        {
            get
            {
                if (_Instance == null) return new BLL_Person();
                return _Instance;
            }
            private set { }
        }
        public Person GetPerson(string id)
        {
            Person obj = new Person();
            foreach (DataRow i in DB_H.Instance.get("select * from [dbo].[info_person]  where id_person='" + id + "'").Rows)
            {
                obj.id_person = i["id_person"].ToString();
                obj.name = i["name"].ToString();
                obj.id_login = i["id_login"].ToString();
                obj.phone = i["phone"].ToString();
                obj.address = i["address"].ToString();
                obj.email = i["email"].ToString();
            }
            return obj;
        }
    }
}
