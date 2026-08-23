using Axis.Repositories.Interfaces;
using Axis.Models.ViewModels;
using Axis.Services.Interfaces;

namespace Axis.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IAdminDashboardRepository _repository;
        public AdminDashboardService(IAdminDashboardRepository repository)
        {
            this._repository = repository;
        }

        public AdminDashboardViewModel getInfo()
        {
            return _repository.getInfo();
        }

        public List<RecentActivitiesViewModel>? getRecentActivities()
        {
            return _repository.getRecentActivities();
        }
    }
}
