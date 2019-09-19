using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFramework.BL.Contacts;
using NFramework.DTO.QueryModels.RoleList;
using NFramework.DTO.Result.Query;

namespace NFramework.RS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {

        public RoleController(IQueryExecutor query, ICommandHandler command)
            : base(query, command)
        {

        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var queryResult = QueryList<QueryResult<RoleListModel>>();
            return Ok(queryResult);
        }
    }
}