using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TamigoApiClient.Models;

namespace TamigoApiClient
{
    public class TamigoApiClient : ITamigoApiClient
    {
        private readonly HttpClient _client;
        private readonly Task<string> _loginTask;
        private string _token;


        public TamigoApiClient(string email, string password)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            _client.BaseAddress = new Uri("https://api.tamigo.com/");

            _loginTask = Login(email, password);
        }

        private async Task<string> Login(string email, string password)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new LoginRequest { Email = email, Password = password }))
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


        public async Task<IEnumerable<Shift>> GetShifts(DateTime? date = null)
        {
            if (_token == null)
            {
                _token = await _loginTask;
                if (_token == null) throw new InvalidOperationException("Wrong username or password");
            }
            if (!date.HasValue)
            {   // Get future

                // Uber hack to retrieve the next week.
                var dates = new List<DateTime>();
                var d = DateTime.Today;
                for (var i = 0; i < 7; i++)
                {
                    if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                        dates.Add(d);
                    d = d.AddDays(1);
                }

                var responseTasks =
                    dates.Select(
                        day => _client.GetAsync($"shifts/day/{day.ToString("yyyy-MM-dd")}/?securitytoken={_token}"));

                var shifts = new List<Shift>();

                foreach (var responseTask in responseTasks)
                {
                    using (var response = await responseTask)
                    {
                        shifts.AddRange(await RetrieveShiftFromResponse(response));
                    }
                }
                return shifts.Where(shift => shift.Close >= DateTime.Now);
                // hack ends.
            }
            else
            {
                using (var result = await _client.GetAsync($"shifts/day/{date.Value.ToString("yyyy-MM-dd")}/?securitytoken={_token}"))
                {
                    return await RetrieveShiftFromResponse(result);
                }
            }
        }

        private async Task<IEnumerable<Shift>> RetrieveShiftFromResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var shifts =
                    JsonConvert.DeserializeObject<IEnumerable<TamigoShift>>(
                        await response.Content.ReadAsStringAsync());

                return shifts.GroupBy(shift => shift.StartTime)
                    .Select(grouping => new Shift
                    {
                        Open = grouping.Key,
                        Close = grouping.First().EndTime,
                        Employees = grouping.Select(shift => shift.EmployeeName.Split(' ').First())
                    });
            }
            return new Shift[0];
        } 

        public Task<EmployeeDto> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }

    public class TamigoShift
    {
        //public object BreakCode { get; set; }
        //public object Color { get; set; }
        //public string Comment { get; set; }
        //public object Comment2 { get; set; }
        //public string DepartmentName { get; set; }
        public string EmployeeId { get; set; }
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
