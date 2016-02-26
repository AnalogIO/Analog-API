using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamigoApiClient.Models;

namespace TamigoApiClient
{
    public class CachedTamigoClient : ITamigoApiClient
    {
        private static readonly TimeSpan FiveMinutes = TimeSpan.FromMinutes(5);
        private readonly ITamigoApiClient _client;
        private List<ShiftDto> _cache;
        private DateTime _lastRefresh;

        public CachedTamigoClient(ITamigoApiClient client)
        {
            _client = client;
            _cache = new List<ShiftDto>();
            FillCacheBackground();
        }

        public void Dispose()
        {
            _client.Dispose();
            _cache.Clear();
        }

        public async void FillCacheBackground()
        {
            await FillCache();
        }

        public async Task FillCache()
        {
            if (DateTime.Now - _lastRefresh > FiveMinutes 
                || !_cache.Any()
                || (_cache.Any(shift => shift.Open < DateTime.Now) && DateTime.Now.Subtract(_cache.Where(shift => shift.Open < DateTime.Now).Max(shift => shift.Open)) < DateTime.Now.Subtract(_lastRefresh)))
            {
                _lastRefresh = DateTime.Now;
                var newCache = new List<ShiftDto>();
                newCache.AddRange(await _client.GetShifts());
                _cache = newCache;
            }
        }

        public Task<bool> IsOpen()
        {
            FillCacheBackground();
            return Task.FromResult(_cache.Any(shift => shift.Open < DateTime.Now && DateTime.Now < shift.Close));
        }

        public Task<IEnumerable<ShiftDto>> GetShifts()
        {
            FillCacheBackground();
            return Task.FromResult(_cache.AsEnumerable());
        }

        public async Task<IEnumerable<ShiftDto>> GetShifts(DateTime date)
        {
            FillCacheBackground();
            if (_cache.Exists(shift => shift.Open.Date == date.Date))
                return _cache.Where(d => d.Open.Date == date.Date);
            return await _client.GetShifts(date);
        }

        public async Task<IEnumerable<ShiftDto>> GetShifts(DateTime @from, DateTime to)
        {
            FillCacheBackground();
            if (_cache.Exists(shift => shift.Open.Date == from.Date) &&
                _cache.Exists(shift => shift.Open.Date == to.Date))
                return _cache.Where(shift => shift.Open > from && shift.Close < to);
            return await _client.GetShifts(from, to);
        }
    }
}
