using Axis.Models.ViewModels;

namespace Axis.Services.Interfaces
{
    public interface IUserDashboardService
    {
        public UserDashboardViewModel getInfo(int userId);
    }
}
