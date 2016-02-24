using System;
using System.Collections.Generic;
using System.Linq;
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
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var shifts = JsonConvert.DeserializeObject<IEnumerable<Shift>>(await client.GetStringAsync("http://localhost:43655/api/shifts"));

            return View(shifts);
        }
    }
}
