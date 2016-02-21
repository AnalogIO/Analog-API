using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Analog_API.Models;

namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class ShiftsController : Controller
    {
        private readonly ShiftplanningApiClient _client;

        public ShiftsController()
        {
            _client = new ShiftplanningApiClient(ReadJsonSecrets());
        }

        private static ApplicationInfo ReadJsonSecrets()
        {
            using (Stream stream = new FileStream("../../SECRETS.json", FileMode.Open))
            {
                using (var r = new StreamReader(stream))
                {
                    var json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<ApplicationInfo>(json);
                }
            }
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
