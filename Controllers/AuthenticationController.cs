using Axis.Models;
using Axis.Models.ViewModels;
using Axis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Axis.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _service;
        public AuthenticationController (IAuthenticationService service)
        {
            this._service = service;
        }
        #region Login Controller
        public IActionResult Login()
        {
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Login (LoginViewModel loginmodel)
        {
            UserSession? user = _service.Login(loginmodel.Username, loginmodel.Password);
            if (user != null && BCrypt.Net.BCrypt.Verify(loginmodel.Password, user.PasswordHash))
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("FullName", user.FullName);
                HttpContext.Session.SetInt32("RoleId", user.RoleId);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Authentication");

        }
        #endregion

        #region Logout Controller

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }
        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
