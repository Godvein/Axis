using Axis.Models.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

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
    }
}
