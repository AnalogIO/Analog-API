using System;

namespace TamigoApiClient.Models.Shifts
{
    public class TamigoShift
    {
        //public object BreakCode { get; set; }
        //public object Color { get; set; }
        //public string Comment { get; set; }
        //public object Comment2 { get; set; }
        //public string DepartmentName { get; set; }
        //public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EndTime { get; set; }
        //public bool HasBid { get; set; }
        //public bool IsAbsenceShift { get; set; }
        //public bool IsAvailable { get; set; }
        //public bool IsExchange { get; set; }
        //public string ShiftActivityId { get; set; }
        //public string ShiftActivityName { get; set; }
        //public float ShiftHours { get; set; }
        //public string ShiftId { get; set; }
        public DateTime StartTime { get; set; }
    }
}