using Axis.Models.ViewModels;

namespace Axis.Repositories
{
    public interface ITaskRepository
    {
        public void AddTask(CreateTaskViewModel createTaskViewModel, int id);
        public List<TaskListViewModel> GetTaskList();
        public void DeleteTask(int id);
    }
}
