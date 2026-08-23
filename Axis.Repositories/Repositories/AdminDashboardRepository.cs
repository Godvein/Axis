using Axis.Models.ViewModels;
using Axis.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration; 

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
            parameters.Add("@UsersCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@TasksCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@RolesCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@DepartmentsCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@flag", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
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

        public List<RecentActivitiesViewModel>? getRecentActivities()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@UsersCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@TasksCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@RolesCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@DepartmentsCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@flag", 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            List<RecentActivitiesViewModel>? recentActivitiesViewModel = connection.Query<RecentActivitiesViewModel>(
                "usp_AdminDashboardInfo", parameters, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
            return recentActivitiesViewModel;
        }
        #endregion
    }
}
