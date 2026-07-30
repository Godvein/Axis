using Axis.Repositories;
using Axis.Models.ViewModels;

namespace Axis.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void AddTask(CreateTaskViewModel createTaskViewModel, int id)
        {
            _taskRepository.AddTask(createTaskViewModel, id);
        }
    }
}
