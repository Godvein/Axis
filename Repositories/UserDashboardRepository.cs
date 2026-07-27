
using Axis.Models.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Axis.Repositories
{
    public class UserDashboardRepository: IUserDashboardRepository
    {
        private readonly string _connectionString;

        public UserDashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public UserDashboardViewModel getInfo(int userId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@AssignedTasks", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@CompletedTasks", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@PendingTasks", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
            connection.Execute("usp_UserDashboardInfo", parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
            return new UserDashboardViewModel
            {
                AssignedTasksCount = parameters.Get<int?>("@AssignedTasks") ?? 0,
                CompletedTasksCount = parameters.Get<int?>("@CompletedTasks") ?? 0,
                PendingTasksCount = parameters.Get<int?>("@PendingTasks") ?? 0
            };
        }
    }
}
