using Axis.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Axis.Models.ViewModels;
using Axis.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
namespace Axis.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string connectionString;

        public RoleRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public List<Role> GetRoles()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var roles = connection.Query<Role>("usp_GetRoles", new { RoleId = 0, Flag = 0 }, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
            return roles;
        }

        public void AddRole(RoleViewModel role)
        {
            using var connection = new SqlConnection(this.connectionString);
            connection.Open();
            connection.Execute("usp_CreateRole", new { RoleName = role.RoleName }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public RoleViewModel? GetRoleById(int id)
        {
            using var connection = new SqlConnection(this.connectionString);
            connection.Open();
            var role = connection.QueryFirstOrDefault<RoleViewModel>("usp_GetRoles", new { RoleId = id, Flag = 1 }, commandType: CommandType.StoredProcedure);
            connection.Close();
            return role;
        }

        public void UpdateRole(RoleViewModel role)
        {
            using var connection = new SqlConnection(this.connectionString);
            connection.Open();
            connection.Execute("usp_EditRole", new { RoleId = role.RoleId, RoleName = role.RoleName }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void DeleteRole(int id)
        {
            using var connection = new SqlConnection(this.connectionString);
            connection.Open();
            connection.Execute("usp_DeleteRole", new { RoleId = id }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }
    }
}
