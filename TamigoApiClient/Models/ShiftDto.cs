using System;
using System.Collections.Generic;

namespace TamigoApiClient.Models
{
    public class ShiftDto
    {
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public IEnumerable<string> Employees { get; set; }
    }
}
