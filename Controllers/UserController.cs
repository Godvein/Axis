using Axis.Models.ViewModels;
using Axis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Axis.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserDashboardService _userDashboardService;
        public UserController(IUserDashboardService userDashboardService)
        {
            _userDashboardService = userDashboardService;
        }
        public IActionResult Dashboard()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            UserDashboardViewModel model = _userDashboardService.getInfo(userId);
            return View(model);
        }
    }
}
