using Microsoft.AspNetCore.Mvc;

namespace NFramework.AS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Authorization Server");
        }        
    }
}
