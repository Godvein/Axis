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
        public readonly IRoleService _roleService;
        public AdminController(IAdminDashboardService adminDashboardService, IDepartmentService departmentService, IRoleService roleService)
        {
            _adminDashboardService = adminDashboardService;
            _departmentService = departmentService;
            _roleService = roleService;
        }
        public IActionResult Dashboard()
        {
            AdminDashboardViewModel adminDashboardInfo = _adminDashboardService.getInfo();
            return View(adminDashboardInfo);
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult CreateUser() {
            CreateUserViewModel createUserViewModel = new CreateUserViewModel();
            createUserViewModel.Roles = _roleService.GetRoles();
            createUserViewModel.Departments = _departmentService.GetDepartments();
            return View(createUserViewModel);
        }


    }
}
