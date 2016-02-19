using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analog_API.Models
{
    public class Shift
    {
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public IEnumerable<string> EmployeeNames { get; set; }
    }
}
