using Axis.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Axis.Models.ViewModels;

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
            var roles = connection.Query<Role>("usp_GetRoles", commandType: CommandType.StoredProcedure).ToList();
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
    }
}
