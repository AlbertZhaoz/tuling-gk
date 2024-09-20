using DotNet实战.AutofacCommon;
using DotNet实战.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet实战.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FromServiceDemoController : ControllerBase
    {
        public FromServiceDemoController(IMyService myService, IUserService userService)
        {
            _myService = myService;
            _userService = userService;
        }

        private IMyService _myService { get; set; }

        private IUserService _userService { get; set; }

        [MyInterceptor.IgnoreInterceptAttribute]
        [HttpGet]
        public ActionResult GetSomething([FromServices] ILogger<FromServiceDemoController> logger)
        {
            _myService.ShowCode();
            _userService.ShowCode();
            logger.LogInformation("Hello World!");
            return Ok("Hello World!");
        }
    }
}
