using Axis.Repositories;
using Axis.Models.ViewModels;

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
    }
}
