using Axis.Models;
using Axis.Models.ViewModels;
namespace Axis.Services.Interfaces
{
    public interface IRoleService
    {
        public List<Role> GetRoles();
        public void AddRole(RoleViewModel role, int userId);
        public RoleViewModel? GetRoleById(int id);
        public void UpdateRole(RoleViewModel role, int userId);
        public void DeleteRole(int id, int userId);
    }
}
