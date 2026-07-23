using Axis.Models.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Axis.Repositories
{
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        private readonly string _connectionString;
        public AdminDashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        #region Admin Dashboard Info Repository
        public AdminDashboardViewModel getInfo()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@UsersCount", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@TasksCount", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@RolesCount", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@DepartmentsCount", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
            
            connection.Execute("usp_AdminDashboardInfo", parameters, commandType: CommandType.StoredProcedure);

            connection.Close();
            return new AdminDashboardViewModel
            {
                UsersCount = parameters.Get<int>("@UsersCount"),
                TasksCount = parameters.Get<int>("@TasksCount"),
                RolesCount = parameters.Get<int>("@RolesCount"),
                DepartmentsCount = parameters.Get<int>("@DepartmentsCount")
            };
        }
        #endregion
    }
}
