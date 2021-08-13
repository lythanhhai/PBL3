using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DTO
{
    public class Information_Order
    {  
        public string Id_Order { get; set; }
       public string NameVehicle { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time_Start { get; set; }
        public string Number_Ticket { get; set; }
        public string Total_price { get; set; }
        public string Date_Order { get; set; }
        public string Name_Customer { get; set; }
        public string Phone_Custemer { get; set; }
    }
}
