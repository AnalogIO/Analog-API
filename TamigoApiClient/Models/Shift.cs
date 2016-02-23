using System;
using System.Collections.Generic;

namespace TamigoApiClient.Models
{
    public class Shift
    {
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public IEnumerable<EmployeeMiniDto> EmployeeIds { get; set; }
    }
}
