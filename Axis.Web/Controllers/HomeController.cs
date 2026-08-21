using Axis.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Axis.Attributes;

namespace Axis.Controllers
{
    [SessionAuthorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("RoleId") == 1)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return RedirectToAction("Dashboard", "User");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
