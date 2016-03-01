using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TamigoApiClient.Models;
using TamigoApiClient.Models.Login;
using TamigoApiClient.Models.Shifts;

namespace TamigoApiClient
{
    public class TamigoClient : ITamigoApiClient
    {
        private readonly HttpClient _client;
        private Task<string> _userLoginTask;
        private string _userToken;
        private readonly Action _relogin;


        public TamigoClient(string email, string password)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            _client.BaseAddress = new Uri("https://api.tamigo.com/");
            
            _relogin = () =>
            {
                _userLoginTask = UserLogin(email, password);
            };

            _relogin();
        }

        private async Task<string> UserLogin(string email, string password)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new UserLoginRequest { Email = email, Password = password }))
            {
                Headers = { ContentType = MediaTypeHeaderValue.Parse("application/json") }
            };

            var response = await _client.PostAsync("login", content);

            if (response.IsSuccessStatusCode)
            {
                var loginresult = JsonConvert.DeserializeObject<LoginResult>(await response.Content.ReadAsStringAsync());
                return loginresult.SessionToken;
            }

            return null;
        }

        public async Task<bool> IsOpen()
        {
            if (_userToken == null)
            {
                _userToken = await _userLoginTask;
                if (_userToken == null) throw new InvalidOperationException("Wrong username or password");
            }
            return (await GetShifts(DateTime.Today)).Any(shift => shift.Open < DateTime.Now && shift.Close > DateTime.Now);
        }

        public async Task<IEnumerable<ShiftDto>> GetShifts()
        {
            if (_userToken == null)
            {
                _userToken = await _userLoginTask;
                if (_userToken == null) throw new InvalidOperationException("Wrong username or password");
            }
            // Get future
            return await GetShifts(DateTime.Today, DateTime.Today.AddDays(7));
        }

        public async Task<IEnumerable<ShiftDto>> GetShifts(DateTime date)
        {
            if (_userToken == null)
            {
                _userToken = await _userLoginTask;
                if (_userToken == null) throw new InvalidOperationException("Wrong username or password");
            }
            using (var result = await _client.GetAsync($"shifts/day/{date.ToString("yyyy-MM-dd")}/?securitytoken={_userToken}"))
            {
                return await RetrieveShiftFromResponse(result);
            }
        }

        public async Task<IEnumerable<ShiftDto>> GetShifts(DateTime @from, DateTime to)
        {
            if (_userToken == null)
            {
                _userToken = await _userLoginTask;
                if (_userToken == null) throw new InvalidOperationException("Wrong username or password");
            }

            var result = new List<ShiftDto>();

            var tasks = Enumerable
                .Range(0, (to - from).Days + 1)
                .Select(offset => from.AddDays(offset))
                .Select(async date => await GetShifts(date));

            foreach (var task in tasks)
            {
                result.AddRange(await task);
            }

            return result;
        }

        private async Task<IEnumerable<ShiftDto>> RetrieveShiftFromResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var shifts =
                    JsonConvert.DeserializeObject<IEnumerable<TamigoShift>>(
                        await response.Content.ReadAsStringAsync());

                return shifts.GroupBy(shift => shift.StartTime)
                    .Select(grouping => new ShiftDto
                    {
                        Open = grouping.Key,
                        Close = grouping.First().EndTime,
                        Employees = grouping.Select(shift => shift.EmployeeName.Split(' ').First())
                    })
                    .OrderBy(shift => shift.Open)
                    .Where(shift => shift.Employees.Any(employee => employee != "Vacant"));
            }
            else
            {
                // The api probably returned unauthorized, because the token needs to be refreshed.
                _userToken = null;
                _relogin();
            }
            
            return new ShiftDto[0];
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
