namespace Axis.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int UsersCount { get; set; }
        public int TasksCount { get; set; }
        public int RolesCount { get; set; }
        public int DepartmentsCount { get; set; }
    }

    public class RecentActivitiesViewModel
    {
        public int ActivityId { get; set; }
        public string Activity { get; set; } = string.Empty;
        public DateTime ActivityType { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

    }

    public class AdminDashboardInfoViewModel
    {
        public AdminDashboardViewModel AdminDashboardInfo { get; set; } = new AdminDashboardViewModel();
        public RecentActivitiesViewModel? RecentActivities { get; set; }
    }
}
