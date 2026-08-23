using Axis.Attributes;
using Axis.Models.ViewModels;
using Axis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Axis.Models;

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
            AdminDashboardViewModel adminDashboard = _adminDashboardService.getInfo();
            RecentActivitiesViewModel? recentActivities = _adminDashboardService.getRecentActivities();
            AdminDashboardInfoViewModel adminDashboardInfoViewModel = new AdminDashboardInfoViewModel
            {
                AdminDashboardInfo = adminDashboard,
                RecentActivities = recentActivities
            };
            return View(adminDashboardInfoViewModel);
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
            List<TaskListViewModel> tasks = _taskService.GetTaskList();
            return View(tasks);
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

        public IActionResult DeleteTask([FromRoute] int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToAction("Tasks", "Admin");
        }
        public IActionResult EditTask([FromRoute] int id)
        {
            EditTaskViewModel? editTaskViewModel = _taskService.GetTaskViewModel(id);
            if (editTaskViewModel == null)
            {
                return NotFound();
            }
            editTaskViewModel.Users = _userService.GetUserList();
            return View(editTaskViewModel);
        }

        [HttpPost]
        public IActionResult EditTask(EditTaskViewModel editTaskViewModel)
        {
            if (editTaskViewModel != null)
            {
               _taskService.UpdateTask(editTaskViewModel, HttpContext.Session.GetInt32("UserId") ?? 0);
                return RedirectToAction("Tasks", "Admin");
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult TaskDetails([FromRoute] int id)
        {
            TaskDetailsViewModel? taskDetailsViewModel = _taskService.GetTaskDetails(id);
            if (taskDetailsViewModel == null)
            {
                return NotFound();
            }
            return View(taskDetailsViewModel);
        }
        #endregion

        public IActionResult Roles()
        {
            List<Role> roles = _roleService.GetRoles();  
            List<RoleViewModel> rolesViewModel = new List<RoleViewModel>();

            foreach(var role in roles)
            {
                rolesViewModel.Add(new RoleViewModel
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName
                });
            }
            return View(rolesViewModel);
        }
        #region Role Management
        public IActionResult CreateRole() {
            RoleViewModel roleViewModel = new RoleViewModel();
            return View(roleViewModel);
        }

        [HttpPost]
        public IActionResult CreateRole(RoleViewModel roleViewModel)
        {
            if (roleViewModel != null)
            {
                _roleService.AddRole(roleViewModel);
                return RedirectToAction("Roles", "Admin");
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult EditRole([FromRoute] int id)
        {
            RoleViewModel? roleViewModel = _roleService.GetRoleById(id);
            if (roleViewModel == null)
            {
                return NotFound();
            }
            return View(roleViewModel);
        }

        [HttpPost]
        public IActionResult EditRole(RoleViewModel roleViewModel)
        {
            if (roleViewModel != null)
            {
                _roleService.UpdateRole(roleViewModel);
                return RedirectToAction("Roles", "Admin");
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult DeleteRole([FromRoute] int id)
        {
            _roleService.DeleteRole(id);
            return RedirectToAction("Roles", "Admin");
        }
        #endregion
    }
}
