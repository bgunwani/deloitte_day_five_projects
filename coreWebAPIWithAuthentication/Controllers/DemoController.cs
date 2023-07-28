using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace coreWebAPIWithAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [Produces("text/plain")]
        [HttpGet("demo1")]
        public async Task<IActionResult> Demo1()
        {
            try
            {
                var content = "Hello World";
                return Ok(content);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Produces("text/html")]
        [HttpGet("demo2")]
        public async Task<IActionResult> Demo2()
        {
            try
            {
                var content = "<h3>Hello World</h3>";
                return new ContentResult
                {
                    Content = content,
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
