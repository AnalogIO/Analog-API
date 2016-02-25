using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TamigoApiClient;

namespace Analog_API.Controllers
{
    [Route("api/[controller]")]
    public class OpenController : Controller
    {
        private readonly ITamigoApiClient _client;

        public OpenController(ITamigoApiClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetIsOpen()
        {
            return Ok(new { open = await _client.IsOpen() });
        }
    }
}