using Axis.Models.ViewModels;
using Axis.Repositories.Interfaces;
using Axis.Services.Interfaces;

namespace Axis.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUtilityRepository _utilityRepository;
        public TaskService(ITaskRepository taskRepository, IUtilityRepository utilityRepository)
        {
            _taskRepository = taskRepository;
            _utilityRepository = utilityRepository;
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
            _utilityRepository.LogActivity(
                createTaskViewModel.Title + "Task added", UserId: id, ActivityType: "Task");
        }
        public List<TaskListViewModel> GetTaskList()
        {
            return _taskRepository.GetTaskList();
        }

        public void DeleteTask(int id, int userId)
        {
            _taskRepository.DeleteTask(id);
            TaskDetailsViewModel? task = _taskRepository.GetTaskDetails(id);
            _utilityRepository.LogActivity(
                task?.Title + "Task deleted", UserId: userId, ActivityType: "Task");
        }
        public EditTaskViewModel? GetTaskViewModel(int id)
        {
            return _taskRepository.GetTaskViewModel(id);
        }
        public void UpdateTask(EditTaskViewModel editTaskViewModel, int id)
        {
            _taskRepository.UpdateTask(editTaskViewModel, id);
            TaskDetailsViewModel? task = _taskRepository.GetTaskDetails(id);
            _utilityRepository.LogActivity(
                task?.Title + "Task updated", UserId: id, ActivityType: "Task");
        }
        public TaskDetailsViewModel? GetTaskDetails(int id)
        {
            return _taskRepository.GetTaskDetails(id);
        }
        public void MarkTaskCompleted(int id, int userId)
        {
            _taskRepository.MarkTaskCompleted(id);
            TaskDetailsViewModel? task = _taskRepository.GetTaskDetails(id);
            _utilityRepository.LogActivity(
                task?.Title + "Task marked as completed", UserId: userId, ActivityType: "Task");
        }   
    }
}
