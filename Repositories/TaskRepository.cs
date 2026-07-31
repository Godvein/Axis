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

        public void DeleteTask(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("usp_DeleteTask", new { TaskId = id }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }
        public EditTaskViewModel? GetTaskViewModel(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var task = connection.QueryFirstOrDefault<EditTaskViewModel>("usp_GetTasks", new { TaskId = id, flag = 1 }, commandType: CommandType.StoredProcedure);
            connection.Close();
            return task;
        }
        public void UpdateTask(EditTaskViewModel editTaskViewModel, int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("usp_UpdateTask",
                new
                {
                    TaskId = editTaskViewModel.TaskId,
                    Title = editTaskViewModel.Title,
                    Description = editTaskViewModel.Description,
                    Priority = editTaskViewModel.Priority,
                    Status = editTaskViewModel.Status,
                    DueDate = editTaskViewModel.DueDate,
                    AssignedTo = editTaskViewModel.AssignedTo,
                    CreatedBy = id
                },
                commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public TaskDetailsViewModel? GetTaskDetails(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var task = connection.QueryFirstOrDefault<TaskDetailsViewModel>("usp_GetTasks", new { TaskId = id, flag = 2 }, commandType: CommandType.StoredProcedure);
            connection.Close();
            return task;
        }
    }
}
