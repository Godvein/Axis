using Axis.Models.ViewModels;

namespace Axis.Services.Interfaces
{
    public interface ITaskService
    {
        public void AddTask(CreateTaskViewModel createTaskViewModel, int id);
        public List<TaskListViewModel> GetTaskList();
        public void DeleteTask(int id, int userId);
        public EditTaskViewModel? GetTaskViewModel(int id);
        public void UpdateTask(EditTaskViewModel editTaskViewModel, int id);
        public TaskDetailsViewModel? GetTaskDetails(int id);
        public void MarkTaskCompleted(int id, int userId);
    }
}
