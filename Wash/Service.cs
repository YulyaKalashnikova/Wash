using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wash
{
    public class Service
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int MachineId { get; set; }
        public int PowderId { get; set; }
        public int DryingId { get; set; }
        public int StaffId { get; set; }
        public bool? IsStatus { get; set; }
        public Machine Machine { get; set; }
        public Powder Powder { get; set; }
        public Drying Drying { get; set; }
        public Staff Staff { get; set; }

        public string Status
        {
            get
            {
                if (IsStatus.HasValue)
                {
                    return IsStatus.Value ? "Выдан" : "Готов";
                }
                return "";
            }
        }
        public DateTime DateStart
        {
            get
            {
                var date = Code.Substring(5, 9);
                return Convert.ToDateTime(date);
            }
        }
    }
}
