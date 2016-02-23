using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ShiftPlanningApiConnection;

namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IShiftplanningApiClient _client;

        public EmployeesController(IShiftplanningApiClient client)
        {
            _client = client;
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
