using Axis.Models.ViewModels;

namespace Axis.Repositories
{
    public interface ITaskRepository
    {
        public void AddTask(CreateTaskViewModel createTaskViewModel, int id);
        public List<TaskListViewModel> GetTaskList();
        public void DeleteTask(int id);
        public EditTaskViewModel? GetTaskViewModel(int id);
        public void UpdateTask(EditTaskViewModel editTaskViewModel, int id);
        public TaskDetailsViewModel? GetTaskDetails(int id);
    }
}
