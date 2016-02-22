using System.Threading.Tasks;
using Analog_API.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;

namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IShiftplanningApiClient _client;

        public EmployeesController(IConfiguration config)
        {
            var appinfo = config.Get<ApplicationInfo>("secrets");

            _client = new ShiftplanningApiClient(appinfo);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _client.GetEmployee(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _client.Dispose();
            }
        }
    }
}
