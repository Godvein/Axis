using Axis.Models.ViewModels;
using Axis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Axis.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserDashboardService _userDashboardService;
        private readonly ITaskService _taskService;
        public UserController(IUserDashboardService userDashboardService, ITaskService taskService)
        {
            _userDashboardService = userDashboardService;
            _taskService = taskService;
        }
        public IActionResult Dashboard()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            UserDashboardViewModel model = _userDashboardService.getInfo(userId);
            return View(model);
        }

        public IActionResult TaskDetails([FromRoute] int id)
        {
            TaskDetailsViewModel? model = _taskService.GetTaskDetails(id);
            if (model != null && model.AssignedTo == HttpContext.Session.GetString("Username"))
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Authentication");
            }
        }

        public IActionResult Tasks()
        {
            List<TaskListViewModel> model = _taskService.GetTaskList();
            model = model.Where(m => m.AssignedTo == HttpContext.Session.GetString("Username")).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult MarkTaskCompleted(int id)
        {
            _taskService.MarkTaskCompleted(id);
            return RedirectToAction("Tasks");
        }
    }
}
