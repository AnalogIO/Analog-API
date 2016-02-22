using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Analog_API.Models;

namespace Analog_API
{
    public interface IShiftplanningApiClient : IDisposable
    {
        Task<IEnumerable<Shift>> GetShifts(DateTime? from = default(DateTime?), DateTime? to = default(DateTime?));
        Task<EmployeeDto> GetEmployee(int employeeId);
    }
}