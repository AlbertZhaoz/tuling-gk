using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace VOL.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApiHomeController : Controller
    {
        
        public IActionResult Index()
        {
            return new RedirectResult("/swagger/");
        }
    }
}