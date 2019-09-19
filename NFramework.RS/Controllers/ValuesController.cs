using Microsoft.AspNetCore.Mvc;
using NFramework.BL.Contacts;
using NFramework.DTO.CommandModels.UserCreate;
using NFramework.DTO.CommandModels.UserDelete;
using NFramework.DTO.Result.Command;

namespace NFramework.RS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        readonly IQueryExecutor _query;
        readonly ICommandHandler _command;

        public ValuesController(IQueryExecutor query, ICommandHandler command)
        {
            _query = query;
            _command = command;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //var commandResult = _query.Execute<CommandResult, UserDeleteModel>(new UserDeleteModel { UserId = 0 });
            return Ok("Resource Server");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           return Ok("Result");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
