using Microsoft.AspNetCore.Mvc;
using Member.Attributes;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class TokenHookController : ControllerBase
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
        //[HttpPost]

        //public ActionResult Post([FromBody] TokenPayload token)
        //{
        //    Token t = new Token();
        //    t.ClientID = "abcde";
        //    t.TokenID = "efgh";
        //    return Ok(t);

        //}


        // POST api/<InlineHookController>
      //  [HttpPost("TokenHook3")]  //[Route("TokenHook2")]
        [HttpPost]
        public ActionResult Post() {

            ValueArr Valuex = new ValueArr();
            Valuex.op = "add";
            Valuex.path = "/claims/ClaimKeyArray";
            Valuex.value = "koko";
            CommandDTO c = new CommandDTO();
            c.type = "com.okta.identity.patch";
            c.value= new List<ValueArr>();
            c.value.Add(Valuex);
            //Command.Add(c);

            CommandArr Commandsx = new CommandArr();

            Commandsx.commands = new List<CommandDTO>();
            Commandsx.commands.Add(c);
            // return Newtonsoft.Json.JsonConvert.SerializeObject(Commandsx);;
            //return "{'commands':[{'type':'com.okta.identity.patch','value':[{'op':'add','path':'/claims/ClaimKeyArray','value':'Koko'}]}]}";

            return Ok(Commandsx);

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

    public class CommandArr
    {
      public  List<CommandDTO> commands { get; set; }
    }
public class CommandDTO
{
    public string type { get; set; }
        public List<ValueArr> value { get; set; }
    }

    public class ValueArr
    {
        public string op { get; set; }
    
        public string path { get; set; }
    
        public string value { get; set; }
    }
}
