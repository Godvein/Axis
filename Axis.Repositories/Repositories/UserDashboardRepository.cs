
using Axis.Models.ViewModels;
using Axis.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

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
            parameters.Add("@AssignedTasks", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@CompletedTasks", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@PendingTasks", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OverdueTasks", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = connection.QueryMultiple("usp_UserDashboardInfo", parameters, commandType: CommandType.StoredProcedure);
            var tasks = result.Read<TaskListViewModel>().ToList();
            connection.Close();
            return new UserDashboardViewModel
            {
                AssignedTasksCount = parameters.Get<int?>("@AssignedTasks") ?? 0,
                CompletedTasksCount = parameters.Get<int?>("@CompletedTasks") ?? 0,
                PendingTasksCount = parameters.Get<int?>("@PendingTasks") ?? 0,
                OverdueTasksCount = parameters.Get<int?>("@OverdueTasks") ?? 0,
                Tasks = tasks
            };
        }
    }
}
