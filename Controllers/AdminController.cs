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
        private readonly ITaskService _taskService;
        public AdminController(IAdminDashboardService adminDashboardService, IDepartmentService departmentService, IRoleService roleService, IUserService userService, ITaskService taskService)
        {
            _adminDashboardService = adminDashboardService;
            _departmentService = departmentService;
            _roleService = roleService;
            _userService = userService;
            _taskService = taskService;
        }
        public IActionResult Dashboard()
        {
            AdminDashboardViewModel adminDashboardInfo = _adminDashboardService.getInfo();
            return View(adminDashboardInfo);
        }

        #region User Management
        public IActionResult Users()
        {
            List<UserListViewModel> users = _userService.GetUserList();
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

        #region edit user controller
        public IActionResult EditUser([FromRoute] int id)
        {
            EditUserViewModel? editUserViewModel = _userService.GetUserById(id);
            if (editUserViewModel == null)
            {
                return NotFound();
            }
            editUserViewModel.Roles = _roleService.GetRoles();
            editUserViewModel.Departments = _departmentService.GetDepartments();
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult EditUser(EditUserViewModel editUserViewModel)
        {
            if (editUserViewModel != null)
            {
                _userService.EditUser(editUserViewModel);
                return RedirectToAction("Users", "Admin");
            }
            return RedirectToAction("Error", "Home");
        }
        #endregion
        public IActionResult DeleteUser([FromRoute] int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Users", "Admin");
        }
        #endregion

        #region Task Management
        public IActionResult Tasks()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            List<UserListViewModel> users = _userService.GetUserList();
            CreateTaskViewModel createTaskViewModel = new CreateTaskViewModel();
            createTaskViewModel.Users = users;
            return View(createTaskViewModel);
        }

        [HttpPost]
        public IActionResult AddTask(CreateTaskViewModel createTaskViewModel)
        {
            int id = HttpContext.Session.GetInt32("UserId") ?? 0;
            _taskService.AddTask(createTaskViewModel, id);
            return RedirectToAction("Tasks", "Admin");    
        }
        #endregion
    }
}
