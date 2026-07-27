using Axis.Models.ViewModels;

namespace Axis.Services
{
    public interface IUserDashboardService
    {
        public UserDashboardViewModel getInfo(int userId);
    }
}
