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
            if (createTaskViewModel.Status == "Completed")
            {
                createTaskViewModel.Completed = true;
            }
            else
            {
                createTaskViewModel.Completed = false;
            }
            _taskRepository.AddTask(createTaskViewModel, id);
        }
        public List<TaskListViewModel> GetTaskList()
        {
            return _taskRepository.GetTaskList();
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }
        public EditTaskViewModel? GetTaskViewModel(int id)
        {
            return _taskRepository.GetTaskViewModel(id);
        }
        public void UpdateTask(EditTaskViewModel editTaskViewModel, int id)
        {
            _taskRepository.UpdateTask(editTaskViewModel, id);
        }
        public TaskDetailsViewModel? GetTaskDetails(int id)
        {
            return _taskRepository.GetTaskDetails(id);
        }
    }
}
