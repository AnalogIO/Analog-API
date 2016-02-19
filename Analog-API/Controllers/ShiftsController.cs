using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Analog_API.Models;

namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class ShiftsController : Controller
    {
        private ApplicationInfo _appInfo;

        public ShiftsController()
        {
            ReadJsonSecrets();
        }

        private void ReadJsonSecrets()
        {
            using (Stream stream = new FileStream("../../SECRETS.json", FileMode.Open))
            {
                using (var r = new StreamReader(stream))
                {
                    var json = r.ReadToEnd();
                    _appInfo = JsonConvert.DeserializeObject<ApplicationInfo>(json);
                }
            }
        }


        [HttpGet]
        [Route("~/api/shifts/today")]
        public async Task<IEnumerable<Shift>> GetToday()
        {
            return (await Get()).Where(shift => shift.Open.Date == DateTime.Now.Date);
        }


        // GET: api/shifts
        [HttpGet]
        public async Task<IEnumerable<Shift>> Get()
        {
            var loggedIn = await FetchData.Login(_appInfo);

            if (loggedIn.Token != null)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

                var request = new ShiftsRequest
                {
                    Module = "schedule.shifts",
                    Method = "GET",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(12),
                    Mode = ShiftsRequest.OverviewMode
                };

                loggedIn.Request = request;

                var dict = new Dictionary<string, string>
                {
                    ["data"] = JsonConvert.SerializeObject(loggedIn)
                };

                var content = new FormUrlEncodedContent(dict);

                var result = await client.PostAsync("https://www.shiftplanning.com/api/", content);

                if (result.IsSuccessStatusCode)
                {
                    result.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var str = await result.Content.ReadAsStringAsync();

                    var res = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ShiftsData>>>(str);

                    return
                        res?.Data.Select(
                            shift => new Shift
                            {
                                Open = DateTime.Parse(shift.start_timestamp),
                                Close = DateTime.Parse(shift.end_timestamp),
                                EmployeeNames = shift.employees.Select(emp => emp.name.Split(' ').FirstOrDefault())
                            });
                }
            }
            return new Shift[0];
        }

        // GET api/shift/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/shifts
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/shifts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/shifts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
