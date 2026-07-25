namespace Axis.Models.ViewModels
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; } = 0;
        public int DepartmentId { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
