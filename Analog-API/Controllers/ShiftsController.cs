using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Analog_API.Models;

namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class ShiftsController : Controller
    {
        private ApplicationInfo _appInfo;

        public ShiftsController() {
            ReadJsonSecrets();
        }

        private void ReadJsonSecrets() {
            using (var r = new StreamReader("../SECRETS.json"))
            {
                var json = r.ReadToEnd();
                _appInfo = JsonConvert.DeserializeObject<ApplicationInfo>(json);
            }
        }

        // GET: api/shifts
        [HttpGet]
        public string Get()
        {
            var loggedIn = FetchData.Login(_appInfo);
            return "Sucessfully logged in: " + loggedIn.ToString();
        }

        // GET api/shift/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/shifts
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/shifts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/shifts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
