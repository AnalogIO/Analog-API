using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamigoApiClient.Models;

namespace TamigoApiClient
{
    public interface ITamigoApiClient : IDisposable
    {
        Task<bool> IsOpen();
        Task<IEnumerable<ShiftDto>> GetShifts();
        Task<IEnumerable<ShiftDto>> GetShifts(DateTime date);
        Task<IEnumerable<ShiftDto>> GetShifts(DateTime from, DateTime to);
    }
}