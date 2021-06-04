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
    class DALL_vehicle
    {
        private static DALL_vehicle _Instance;
        public static DALL_vehicle Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DALL_vehicle();
                return _Instance;
            }
            private set { }

        }
        private DALL_vehicle()
        {
        }

        public List<DTO_vehicle> getallvehicle()
        {

            List<DTO_vehicle> data = new List<DTO_vehicle>();
            string q = "select * from Vehicle";
            foreach (DataRow i in DB_H.Instance.get(q).Rows)
            {
                data.Add(getvehicle(i));
            }
            return data;
        }

        public DTO_vehicle getvehicle(DataRow dr)
        {

            return new DTO_vehicle
            {
                id_vehicle = dr["id_vehicle"].ToString(),
                type = dr["type"].ToString(),
                name = dr["name"].ToString(),
                status_vehicle = Convert.ToBoolean(dr["status_vehicle"].ToString()),
                number_seat= Convert.ToInt32(dr["number_seat"].ToString())



            };

        }



        public void addvehicle_DAL(DTO_vehicle r)
        {
            string query = "insert into Vehicle values ('";
            query += r.id_vehicle + "', '" + r.type + "', '" + r.name + "', '"+ r.number_seat+"','"
                + false + "');";
            DB_H.Instance.Ex(query);

        }
        public void updatevehiclebyid_vehicle(DTO_vehicle s)
        {
            string querry = "update Vehicle set id_vehicle = '" + s.id_vehicle + "', type = '" + s.type
                + "', name = '" + s.name + "', status_vehicle = '" + false + "', number_seat = '" + s.number_seat
                + "' where id_vehicle = '" + s.id_vehicle + "'";
            DB_H.Instance.Ex(querry);
        }




        public void deleteVehicle_DALL(DTO_vehicle s)
        {
            string querry = "update Vehicle set id_vehicle = '" + s.id_vehicle + "', type = '" + s.type
                + "', name = '" + s.name + "', status_vehicle = '" + true + "', number_seat = '" + s.number_seat
                + "' where id_vehicle = '" + s.id_vehicle + "'";
            DB_H.Instance.Ex(querry);
        }
    }
}
