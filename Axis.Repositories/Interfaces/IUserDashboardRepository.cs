using Axis.Models.ViewModels;
namespace Axis.Repositories.Interfaces
{
    public interface IUserDashboardRepository
    {
        public UserDashboardViewModel getInfo(int userId);
    }
}
