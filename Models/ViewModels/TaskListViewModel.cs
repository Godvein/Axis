namespace Axis.Models.ViewModels
{
    public class TaskListViewModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string AssignedToName { get; set; } = string.Empty;
        public string CreatedByName { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }
}
