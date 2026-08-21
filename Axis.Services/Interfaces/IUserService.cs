using Axis.Models.ViewModels;

namespace Axis.Services.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(CreateUserViewModel createUserViewModel);
        public List<UserListViewModel> GetUserList();
        public EditUserViewModel? GetUserById(int id);
        public void EditUser(EditUserViewModel editUserViewModel);
        public void DeleteUser(int id);
    }
}
