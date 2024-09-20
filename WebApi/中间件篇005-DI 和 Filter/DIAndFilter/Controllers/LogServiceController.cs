using DotNet实战.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet实战.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogServiceController : ControllerBase
    {
        private readonly ILogger<LogServiceController> logger;

        public LogServiceController(ILogger<LogServiceController> logger)
        {
            this.logger = logger;
        }
        // [LogServiceFilterAttribute]
        // TypeFilter 会默认将 LogActionFilterAttribute 注册为瞬态
        // ServiceFilter 需要手动注入 LogActionFilterAttribute为瞬态
        // [TypeFilter(typeof(LogActionFilterAttribute))]
        [HttpGet]
        public ActionResult GetSomething()
        {
            Console.WriteLine("Run something");
            return Ok("Hello World!");
        }
    }
}
