using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_DATVEXE.DTO
{
    public class ViewSearchRoute
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime StartTime { get; set; }
        public override string ToString()
        {
            return StartPoint;
        }
    }
}
