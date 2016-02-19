using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Analog_API.Models;

namespace Analog_API.Models
{
    public class FetchData
    {
        public static bool Login(ApplicationInfo info) {
            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var apirequest = new ShiftPlanningApiRequest
            {
                Key = info.Key,
                Output = "json",
                Request = new LoginRequest
                {
                    Module = "staff.login",
                    Method = "GET",
                    Username = info.Username,
                    Password = info.Password
                }
            };

            var map = new Dictionary<string, string>
            {
                ["data"] = JsonConvert.SerializeObject(apirequest)
            };

            HttpContent content = new FormUrlEncodedContent(map);



            var result = httpclient.PostAsync("https://www.shiftplanning.com/api/", content).Result;

            // For some reason the response is "text/html". Needs to be changed....
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var s = result.Content.ReadAsStringAsync().Result;

            var loginData = JsonConvert.DeserializeObject<LoginData>(result.Content.ReadAsStringAsync().Result);


            var success = result.IsSuccessStatusCode;
            return success;
        }


    }
}
