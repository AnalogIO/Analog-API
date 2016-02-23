using System;
using System.Collections.Generic;
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

        [HttpGet("today")]
        public async Task<IEnumerable<Shift>> GetToday()
        {
            return await _client.GetShifts(DateTime.Now);
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

        // GET: api/shifts
        [HttpGet]
        public async Task<IEnumerable<Shift>> Get()
        {
            // Todo: Returns empty. :-(
            return await _client.GetShifts();
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
