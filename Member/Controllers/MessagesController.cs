using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var messages = new dynamic[]
            {
                new {Date= DateTime.Now, Text="Kifah Message"},
                 new {Date= DateTime.Now, Text="Sanjay Message"},
                  new {Date= DateTime.Now, Text="Samin Message"}

            };

            return Ok(messages);
        }
    }
}
