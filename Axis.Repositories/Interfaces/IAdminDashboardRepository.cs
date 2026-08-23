using Axis.Models.ViewModels;

namespace Axis.Repositories.Interfaces
{
    public interface IAdminDashboardRepository
    {
        public AdminDashboardViewModel getInfo();
        public RecentActivitiesViewModel? getRecentActivities();
    }
}
