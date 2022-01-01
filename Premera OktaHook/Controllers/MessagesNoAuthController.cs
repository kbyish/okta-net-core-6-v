using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PremeraOktaHooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesNoAuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var messages = new dynamic[]
            {
                new {Date= DateTime.Now, Text="Kifah Message No Auth"},
                 new {Date= DateTime.Now, Text="Sanjay Message No Auth"},
                  new {Date= DateTime.Now, Text="Samin Message No Auth"}

            };

            return Ok(messages);
        }
    }
}
