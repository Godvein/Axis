namespace Axis.Models.ViewModels
{
    public class UserDashboardViewModel
    {
        public int AssignedTasksCount { get; set; }
        public int CompletedTasksCount { get; set; }
        public int PendingTasksCount { get; set; }
        public List<TaskListViewModel> Tasks { get; set; } = new List<TaskListViewModel>();
    }
}
