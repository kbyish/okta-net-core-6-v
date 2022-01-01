using Microsoft.AspNetCore.Mvc;
using PremeraOktaHooks.Attributes;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremeraOktaHooks.Controllers
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


        [HttpPost]
        public ActionResult Post()
        {

            MemberKeys MemberKey = new MemberKeys();
            MemberKey.memberKey = "123456";
            MemberKey.groupKey = "12";
            MemberKey.lineOfBusiness = "ABCDEF";


            ValueDTO Value = new ValueDTO();
            Value.op = "add";
            Value.path = "/claims/memberKeysx";
            Value.value = new List<MemberKeys>();
            Value.value.Add(MemberKey);

            CommandDTO command = new CommandDTO();
            command.type = "com.okta.identity.patch";
            command.value = new List<ValueDTO>();
            command.value.Add(Value);

            List<CommandDTO> commands = new List<CommandDTO>();
            commands.Add(command);

            return Ok(new { commands });
        }

    }


    public class CommandDTO
    {
        public string type { get; set; }
        public List<ValueDTO> value { get; set; }
    }

    public class ValueDTO
    {
        public string op { get; set; }

        public string path { get; set; }

        public List<MemberKeys> value { get; set; }
    }


    public class MemberKeys
    {
        public string memberKey { get; set; }
        public string groupKey { get; set; }
        public string lineOfBusiness { get; set; }
    }
}
