using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShiftPlanningApiConnection.Models;

namespace ShiftPlanningApiConnection
{
    public interface IShiftplanningApiClient : IDisposable
    {
        Task<IEnumerable<Shift>> GetShifts(DateTime? from = default(DateTime?), DateTime? to = default(DateTime?));
        Task<EmployeeDto> GetEmployee(int employeeId);
    }
}