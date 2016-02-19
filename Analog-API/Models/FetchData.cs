using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Analog_API.Models
{
    public class FetchData
    {
        public static async Task<ShiftPlanningApiRequest> Login(ApplicationInfo info) {
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



            var result = await httpclient.PostAsync("https://www.shiftplanning.com/api/", content);

            // For some reason the response is "text/html". Needs to be changed....
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var loginData = JsonConvert.DeserializeObject<ApiResponse<Data>>(await result.Content.ReadAsStringAsync());

            apirequest.Token = loginData.Token;
            apirequest.Request = null;

            return apirequest;
        }
    }
}
