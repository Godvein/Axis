using Axis.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

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
    }
}
