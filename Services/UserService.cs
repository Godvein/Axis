using Axis.Models.ViewModels;
using Axis.Repositories;

namespace Axis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(CreateUserViewModel createUserViewModel)
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

            }
        }
        
        public List<UserListViewModel> GetUserList()
        {
            return _userRepository.GetUserList();
        }
    }
}
