using Axis.Models;
using Axis.Models.ViewModels;
namespace Axis.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public List<Role> GetRoles();
        public void AddRole(RoleViewModel role);
        public RoleViewModel? GetRoleById(int id);
        public void UpdateRole(RoleViewModel role);
        public void DeleteRole(int id);
    }
}
