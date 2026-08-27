using Axis.Models;
using Axis.Models.ViewModels;

namespace Axis.Services.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(CreateUserViewModel createUserViewModel, int userId);
        public List<UserListViewModel> GetUserList();
        public EditUserViewModel? GetUserById(int id);
        public void EditUser(EditUserViewModel editUserViewModel, int userId);
        public void DeleteUser(int id, int userId);
        public List<UserListViewModel> SearchUsers(string Username, int? roleId, int? departmentId, int? IsActive);
    }
}
