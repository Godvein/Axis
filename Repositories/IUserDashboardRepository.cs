using Axis.Models.ViewModels;
namespace Axis.Repositories
{
    public interface IUserDashboardRepository
    {
        public UserDashboardViewModel getInfo(int userId);
    }
}
