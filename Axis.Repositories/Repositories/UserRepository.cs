using Axis.Models.ViewModels;
using Axis.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Axis.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        #region create user repository
        public void CreateUser(string username, string password, string fullName, string email, int roleId, int departmentId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            connection.Execute(
                "usp_CreateUser", 
                new { Username = username, PasswordHash = password, FullName = fullName, Email = email, RoleId = roleId, DepartmentId = departmentId },
                commandType: CommandType.StoredProcedure);
            connection.Close();

        }
        #endregion

        #region get user list repository
        public List<UserListViewModel>  GetUserList()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var users = connection.Query<UserListViewModel>("usp_GetUsers", 
                new { flag = 1, UserId = 0 }, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
            return users;
        }
        #endregion

        #region delete user repository
        public void DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("usp_DeleteUser", new { UserId = id }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }
        #endregion

        public EditUserViewModel? GetUserById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var user = connection.QueryFirstOrDefault<EditUserViewModel>("usp_GetUsers",
                new { flag = 0, UserId = id }, commandType: CommandType.StoredProcedure);
            if(user != null)
                user.UserId = id;
            connection.Close();
            return user;
        }
        
        public void EditUser(EditUserViewModel editUserViewModel)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("usp_UpdateUser",
                new { UserId = editUserViewModel.UserId, Username = editUserViewModel.Username, 
                    FullName = editUserViewModel.FullName, Email = editUserViewModel.Email, RoleId = editUserViewModel.RoleId,
                    DepartmentId = editUserViewModel.DepartmentId, IsActive = editUserViewModel.IsActive },
                commandType: CommandType.StoredProcedure);
            connection.Close();
        }
    }
}
