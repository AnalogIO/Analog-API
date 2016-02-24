using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamigoApiClient.Models;

namespace TamigoApiClient
{
    public interface ITamigoApiClient : IDisposable
    {
        Task<bool> IsOpen();
        Task<IEnumerable<Shift>> GetShifts();
        Task<IEnumerable<Shift>> GetShifts(DateTime date);
        Task<IEnumerable<Shift>> GetShifts(DateTime from, DateTime to);
        Task<EmployeeDto> GetEmployee(int employeeId);
    }
}