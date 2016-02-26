using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TamigoApiClient;
using TamigoApiClient.Models;


namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class ShiftsController : Controller
    {
        private readonly ITamigoApiClient _client;

        public ShiftsController(ITamigoApiClient client)
        {
            _client = client;
        }

        // GET: api/shifts
        [HttpGet]
        public async Task<IEnumerable<Shift>> Get()
        {
            return (await _client.GetShifts()).Where(shift => shift.Close > DateTime.Now);
        }

        [HttpGet("today")]
        public async Task<IEnumerable<Shift>> GetToday()
        {
            return await _client.GetShifts(DateTime.Today);
        }

        [HttpGet("day/{date}")]
        public async Task<ActionResult> GetDate(string date)
        {
            DateTime d;
            if (DateTime.TryParse(date, out d))
            {
                return Ok(await _client.GetShifts(d));
            }
            return HttpBadRequest("Date format should be yyyy-MM-dd");
        }
    }
}
