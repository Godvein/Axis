using Microsoft.AspNetCore.Mvc;

namespace Axis.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
