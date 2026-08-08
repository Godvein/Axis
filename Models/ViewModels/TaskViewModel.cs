namespace Axis.Models.ViewModels
{
    public class TaskListViewModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string AssignedTo { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }
    public class CreateTaskViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        public int? AssignedTo { get; set; }

        public DateTime? DueDate { get; set; }

        public List<UserListViewModel> Users { get; set; } = new();
        public bool Completed { get; set; }
    }
    public class EditTaskViewModel
    {
        public int TaskId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int AssignedTo { get; set; }

        public DateTime? DueDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<UserListViewModel> Users { get; set; } = new();
    }
    public class TaskDetailsViewModel
    {
        public int TaskId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public string AssignedTo { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DueDate { get; set; }

        public bool Completed { get; set; }
    }
}
