using Microsoft.AspNetCore.Mvc;
using PremeraOktaHooks.Attributes;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremeraOktaHooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class InlineHookController : ControllerBase
    {
        // GET: api/<InlineHookController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InlineHookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InlineHookController>
        [HttpPost]

        public ActionResult Post([FromBody] TokenPayload token)
        {
            Token t = new Token();
            t.ClientID = "abcde";
            t.TokenID = "efgh";
            return Ok(t);

        }

        // PUT api/<InlineHookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InlineHookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Token
    {
        public string TokenID { get; set; }
        public string ClientID { get; set; }
    }

    public class TokenPayload
    {
        public string Issuer { get; set; }
        public string ClientID { get; set; }

    }
}
