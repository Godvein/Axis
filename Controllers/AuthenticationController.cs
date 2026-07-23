using Microsoft.AspNetCore.Mvc;

namespace Axis.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
