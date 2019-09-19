using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NFramework.BL.Contacts;
using NFramework.DTO.CommandModels.UserCreate;
using NFramework.DTO.CommandModels.UserDelete;
using NFramework.DTO.Parameters.UserLogin;
using NFramework.DTO.QueryModels.UserLogin;
using NFramework.DTO.Result.Command;
using NFramework.DTO.Result.Query;

namespace NFramework.RS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {

        public ValuesController(IQueryExecutor query, ICommandHandler command)
            : base(query, command)
        {

        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var commandResult = Command<CommandResult, UserDeleteModel>(new UserDeleteModel { UserId = 0 });
            return Ok("Resource Server: " + commandResult.Message);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            /*var result = Query<QueryResult<UserLoginResult>, UserLoginParameter>(new UserLoginParameter
            {
                UserName = "nitin_padade@persistent.com",
                Password = "nitin@1234"
            });*/

            var commandResult = Command<CommandResult, UserCreateModel>(new UserCreateModel { FirstName = "Nitin", LastName = "Padade", Id = id });

            return Ok(commandResult);
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
