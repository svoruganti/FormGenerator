using Microsoft.AspNetCore.Mvc;

namespace FormGenerator.Web.Controllers
{
    [Route("testapi")]
    public class TestApiController : Controller
    {
        public IActionResult Get()
        {
            return Ok(5);
        }
    }
}