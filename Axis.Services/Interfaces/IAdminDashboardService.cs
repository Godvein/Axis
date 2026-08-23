using Axis.Models.ViewModels;
namespace Axis.Services.Interfaces
{
    public interface IAdminDashboardService
    {
        public AdminDashboardViewModel getInfo();
        public List<RecentActivitiesViewModel>? getRecentActivities();
    }
}
