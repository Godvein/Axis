using Axis.Models.ViewModels;
using Axis.Repositories.Interfaces;
using Axis.Services.Interfaces;

namespace Axis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUtilityRepository _utilityRepository;

        public UserService(IUserRepository userRepository, IUtilityRepository utilityRepository)
        {
            _userRepository = userRepository;
            _utilityRepository = utilityRepository;
        }

        public void CreateUser(CreateUserViewModel createUserViewModel, int userId)
        {
            if (createUserViewModel.Password == createUserViewModel.ConfirmPassword)
            {
                _userRepository.CreateUser(
                createUserViewModel.Username,
                BCrypt.Net.BCrypt.HashPassword(createUserViewModel.Password),
                createUserViewModel.FullName,
                createUserViewModel.Email,
                createUserViewModel.RoleId,
                createUserViewModel.DepartmentId
            );
            _utilityRepository.LogActivity(
                createUserViewModel.Username + " User created", UserId: userId, ActivityType: "User");

            }
        }
        
        public List<UserListViewModel> GetUserList()
        {
            return _userRepository.GetUserList();
        }

        public void DeleteUser(int id, int userId)
        {
            _userRepository.DeleteUser(id);
            EditUserViewModel? editUserViewModel = _userRepository.GetUserById(id);
            _utilityRepository.LogActivity(
                editUserViewModel?.Username + " User deleted", UserId: userId, ActivityType: "User");
        }

        public EditUserViewModel? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void EditUser(EditUserViewModel editUserViewModel, int userId)
        {
            _userRepository.EditUser(editUserViewModel);
            _utilityRepository.LogActivity(
               editUserViewModel.Username + " User updated", UserId: userId, ActivityType: "User");
        }
    }
}
