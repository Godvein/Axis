using Axis.Models.ViewModels;

namespace Axis.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(string username, string password, string fullName, string email, int roleId, int departmentId);
        public List<UserListViewModel> GetUserList();
        public void DeleteUser(int id);
        public EditUserViewModel? GetUserById(int id);
        public void EditUser(EditUserViewModel editUserViewModel);
        public List<UserListViewModel> SearchUsers(string Username, int? roleId, int? departmentId, int? IsActive);
    }
}
