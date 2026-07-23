using Axis.Models.ViewModels;
using Axis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Axis.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminDashboardService _adminDashboardService;
        public AdminController(IAdminDashboardService adminDashboardService)
        {
            _adminDashboardService = adminDashboardService;
        }
        public IActionResult Dashboard()
        {
            AdminDashboardViewModel adminDashboardInfo = _adminDashboardService.getInfo();
            return View(adminDashboardInfo);
        }
    }
}
