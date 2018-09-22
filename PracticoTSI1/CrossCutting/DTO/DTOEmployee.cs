using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class DTOEmployee
    {
        public int id { get; set; }
        public String name {get; set; }
        public DateTime StartDate { get; set; }
        public int Salary { get; set; }
        public Double HourlyRate { get; set; }
        public Boolean full { get; set; }
    }
}
