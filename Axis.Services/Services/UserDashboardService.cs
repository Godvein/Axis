using Axis.Models.ViewModels;
using Axis.Repositories.Interfaces;
using Axis.Services.Interfaces;

namespace Axis.Services
{
    public class UserDashboardService: IUserDashboardService
    {
        private readonly IUserDashboardRepository _userDashboardRepository;

        public UserDashboardService(IUserDashboardRepository userDashboardRepository)
        {
            _userDashboardRepository = userDashboardRepository;
        }
        public UserDashboardViewModel getInfo(int userId)
        {
            return _userDashboardRepository.getInfo(userId);
        }
    }
}
