using Axis.Models.ViewModels;

namespace Axis.Repositories
{
    public interface ITaskRepository
    {
        public void AddTask(CreateTaskViewModel createTaskViewModel, int id);
    }
}
