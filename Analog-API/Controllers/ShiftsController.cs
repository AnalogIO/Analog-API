using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Analog_API.Models;
using Microsoft.Extensions.Configuration;

namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class ShiftsController : Controller
    {
        private readonly ShiftplanningApiClient _client;

        public ShiftsController(IConfiguration config)
        {
            var appinfo = config.Get<ApplicationInfo>("secrets");

            _client = new ShiftplanningApiClient(appinfo);
        }

        [HttpGet]
        [Route("today")]
        public async Task<IEnumerable<Shift>> GetToday()
        {
            return await _client.GetShifts(DateTime.Today, DateTime.Today);
        }

        // GET: api/shifts
        [HttpGet]
        public async Task<IEnumerable<Shift>> Get()
        {
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
