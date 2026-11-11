using System;
using System.Collections.Generic;
using System.Text;

namespace Axis.Api.Core.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
