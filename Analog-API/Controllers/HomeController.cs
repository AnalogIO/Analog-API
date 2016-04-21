using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using TamigoApiClient.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Analog_API.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController(HttpClient client)
        {
            _client = client;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var shifts = JsonConvert.DeserializeObject<IEnumerable<ShiftDto>>(await _client.GetStringAsync("http://localhost/api/shifts"));

            return View(shifts);
        }
    }
}
