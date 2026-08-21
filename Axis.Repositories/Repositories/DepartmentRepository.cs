using Axis.Models;
using Axis.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
namespace Axis.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string connectionString;

        public DepartmentRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public List<Department> GetDepartments()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var departments = connection.Query<Department>("usp_GetDepartments", commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
            return departments;
        }   
    }
}
