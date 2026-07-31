using Axis.Models.ViewModels;

namespace Axis.Services
{
    public interface ITaskService
    {
        public void AddTask(CreateTaskViewModel createTaskViewModel, int id);
        public List<TaskListViewModel> GetTaskList();
        public void DeleteTask(int id);
    }
}
