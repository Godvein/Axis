using Dapper;
using Axis.Models.ViewModels;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Axis.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;
        public TaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public void AddTask(CreateTaskViewModel createTaskViewModel, int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("usp_CreateTask",
                new
                {
                    Title = createTaskViewModel.Title,
                    Description = createTaskViewModel.Description,
                    Priority = createTaskViewModel.Priority,
                    Status = createTaskViewModel.Status,
                    DueDate = createTaskViewModel.DueDate,
                    AssignedTo = createTaskViewModel.AssignedTo,
                    CreatedBy = id
                },
                commandType: System.Data.CommandType.StoredProcedure);
            connection.Close();
        }

        public List<TaskListViewModel> GetTaskList()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var tasks = connection.Query<TaskListViewModel>("usp_GetTasks", new{TaskId = 0, flag = 0}, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
            return tasks;
        }
    }
}
