using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    
    public class PartTimeEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int SalXHora { get; set; }
    }
}
