using Axis.Models.ViewModels;

namespace Axis.Services
{
    public interface IUserService
    {
        public void CreateUser(CreateUserViewModel createUserViewModel);
        public List<UserListViewModel> GetUserList();
    }
}
