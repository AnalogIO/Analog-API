using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamigoApiClient.Models;

namespace TamigoApiClient
{
    public interface ITamigoApiClient : IDisposable
    {
        Task<IEnumerable<Shift>> GetShifts(DateTime? date = null);
        Task<EmployeeDto> GetEmployee(int employeeId);
    }
}