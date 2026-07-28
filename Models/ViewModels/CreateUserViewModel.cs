using System.ComponentModel.DataAnnotations;

namespace Axis.Models.ViewModels
{
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
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int RoleId { get; set; } = 0;
        [Required]
        public int DepartmentId { get; set; } = 0;
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
