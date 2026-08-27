using System.ComponentModel.DataAnnotations;

namespace Axis.Models.ViewModels
{
    public class UserManagementViewModel
    {
        public List<UserListViewModel> Users { get; set; } = new List<UserListViewModel>();
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Department> Departments { get; set; } = new List<Department>();
    } 
    public class UserListViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<RoleViewModel> RoleViewModel { get; set; } = new List<RoleViewModel>();

    }
    public class CreateUserViewModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required]
        public int RoleId { get; set; } = 0;
        [Required]
        public int DepartmentId { get; set; } = 0;
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Department> Departments { get; set; } = new List<Department>();
    }
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
