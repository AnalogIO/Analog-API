using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShiftPlanningApiConnection.Models;
using ShiftPlanningApiConnection.Requests;

namespace ShiftPlanningApiConnection
{
    public class ShiftplanningApiClient : IShiftplanningApiClient
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        private static readonly Dictionary<int, EmployeeDto> EmployeeCache = new Dictionary<int, EmployeeDto>();

        private readonly HttpClient _client;
        private readonly Task<bool> _loginTask;

        private ShiftPlanningApiRequest _apiRequest;

        public ShiftplanningApiClient(ApplicationInfo info)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri("https://www.shiftplanning.com/api/");
            _apiRequest = new ShiftPlanningApiRequest
            {
                Key = info.Key,
                Output = "json"
            };
            _loginTask = Login(info.Username, info.Password);
        }

        public async Task<IEnumerable<Shift>> GetShifts(DateTime? from = null, DateTime? to = null)
        {
            if (_apiRequest?.Token == null)
            {
                if (!await _loginTask)
                {
                    throw new InvalidOperationException("Couldn't perform login.");
                }
            }

            var request = new ShiftsRequest
            {
                Method = "GET",
                StartDate = from,
                EndDate = to,
                Mode = ShiftsRequest.OverviewMode
            };

            using (var result = await _client.PostAsync("", CreateContent(request)))
            {
                result.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var res =
                    JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ShiftsData>>>(
                        await result.Content.ReadAsStringAsync());

                return
                    res?.Data?.Select(
                        shift => new Shift
                        {
                            Open = DateTime.Parse(shift.StartTimestamp),
                            Close = DateTime.Parse(shift.EndTimestamp),
                            EmployeeIds = shift.Employees.Select(emp => new EmployeeMiniDto { Id = emp.Id, Firstname = emp.Name.Split(' ').FirstOrDefault() })
                        });
            }
        }

        public async Task<EmployeeDto> GetEmployee(int employeeId)
        {
            if (EmployeeCache.ContainsKey(employeeId)) return EmployeeCache[employeeId];

            if (_apiRequest?.Token == null)
            {
                if (!await _loginTask)
                {
                    throw new InvalidOperationException("Couldn't perform login.");
                }
            }

            var request = new EmployeeRequest
            {
                Id = employeeId
            };

            using (var result = await _client.PostAsync("", CreateContent(request)))
            {
                result.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var res =
                    JsonConvert.DeserializeObject<ApiResponse<EmployeeData>>(
                        await result.Content.ReadAsStringAsync());

                if (res.Status != 1) return null;

                var employee =
                    new EmployeeDto
                    {
                        Id = employeeId,
                        Firstname = res.Data.Firstname,
                        AvatarUrl = res.Data.Avatar?.Large
                    };

                EmployeeCache.Add(employeeId, employee);
                return employee;
            }
        }
        
        #region Private helpers
        private async Task<bool> Login(string username, string password)
        {
            var request = new LoginRequest
            {
                Method = "GET",
                Username = username,
                Password = password
            };

            using (var result = await _client.PostAsync("", CreateContent(request)))
            {

                // For some reason the response is "text/html". Needs to be changed....
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var loginData =
                    JsonConvert.DeserializeObject<ApiResponse<Data>>(await result.Content.ReadAsStringAsync());

                _apiRequest.Token = loginData.Token;

                return !string.IsNullOrWhiteSpace(loginData.Token);
            }
        }

        private HttpContent CreateContent(Request data)
        {
            using (var writer = new StringWriter())
            {
                using (var wr = new JsonTextWriter(writer))
                {
                    _apiRequest.Request = data;

                    Serializer.Serialize(wr, _apiRequest);

                    _apiRequest.Request = null;

                    return new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        ["data"] = writer.ToString()
                    });
                }
            }
        }
        #endregion
        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.Dispose();
                _apiRequest = null;
            }
        }
        #endregion
    }
}
