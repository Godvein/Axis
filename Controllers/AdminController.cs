using Axis.Attributes;
using Axis.Models.ViewModels;
using Axis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Axis.Controllers
{
    [SessionAuthorize(RoleId = 1)]
    public class AdminController : Controller
    {
        private readonly IAdminDashboardService _adminDashboardService;
        private readonly IDepartmentService _departmentService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public AdminController(IAdminDashboardService adminDashboardService, IDepartmentService departmentService, IRoleService roleService, IUserService userService)
        {
            _adminDashboardService = adminDashboardService;
            _departmentService = departmentService;
            _roleService = roleService;
            _userService = userService;
        }
        public IActionResult Dashboard()
        {
            AdminDashboardViewModel adminDashboardInfo = _adminDashboardService.getInfo();
            return View(adminDashboardInfo);
        }

        public IActionResult Users()
        {
            var users = _userService.GetUserList();
            return View(users);
        }
        #region create user controller
        public IActionResult CreateUser() {
            CreateUserViewModel createUserViewModel = new CreateUserViewModel();
            createUserViewModel.Roles = _roleService.GetRoles();
            createUserViewModel.Departments = _departmentService.GetDepartments();
            return View(createUserViewModel);
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserViewModel createUserViewModel) { 
            if (createUserViewModel != null)
            {
               _userService.CreateUser(createUserViewModel);
                return RedirectToAction("Users", "Admin");
            }
            return RedirectToAction("CreateUser", "Admin");
        }
        #endregion
    }
}
