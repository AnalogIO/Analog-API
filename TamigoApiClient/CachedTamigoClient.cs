using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamigoApiClient.Models;

namespace TamigoApiClient
{
    public class CachedTamigoClient : ITamigoApiClient
    {
        private readonly ITamigoApiClient _client;
        private List<Shift> _cache;
        private DateTime _lastRefresh;

        public CachedTamigoClient(ITamigoApiClient client)
        {
            _client = client;
            _cache = new List<Shift>();
            FillCache();
        }

        public void Dispose()
        {
            // Don't do anything.
        }

        public async void FillCache()
        {
            if (DateTime.Now - _lastRefresh > TimeSpan.FromMinutes(5))
            {
                _lastRefresh = DateTime.Now;
                var newCache = new List<Shift>();
                newCache.AddRange(await _client.GetShifts());
                _cache = newCache;
            }
        }

        public Task<bool> IsOpen()
        {
            FillCache();
            return Task.FromResult(_cache.Any(shift => shift.Open < DateTime.Now && DateTime.Now < shift.Close));
        }

        public Task<IEnumerable<Shift>> GetShifts()
        {
            FillCache();
            return Task.FromResult(_cache.AsEnumerable());
        }

        public Task<IEnumerable<Shift>> GetShifts(DateTime date)
        {
            FillCache();
            return Task.FromResult(_cache.Where(d => d.Open.Date == date.Date));
        }

        public Task<IEnumerable<Shift>> GetShifts(DateTime @from, DateTime to)
        {
            //Todo: Make implementation using tamigo.
            FillCache();
            return Task.FromResult(_cache.Where(shift => shift.Open > from && shift.Close < to));
        }

        public Task<EmployeeDto> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
