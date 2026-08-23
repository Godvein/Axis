using Axis.Models;
using Axis.Repositories.Interfaces;
using Axis.Models.ViewModels;
using Axis.Services.Interfaces;

namespace Axis.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUtilityRepository _utilityRepository;

        public RoleService (IRoleRepository roleRepository, IUtilityRepository utilityRepository)
        {
            this._roleRepository = roleRepository;
            this._utilityRepository = utilityRepository;
        }

        public List<Role> GetRoles()
        {
            return _roleRepository.GetRoles();
        }
        public void AddRole(RoleViewModel role, int userId)
        {
            _roleRepository.AddRole(role);
            _utilityRepository.LogActivity(
               role.RoleName + " Role added", UserId: userId, ActivityType: "Role");
        }  
        public RoleViewModel? GetRoleById(int id) {
            return _roleRepository.GetRoleById(id);
        }

        public void UpdateRole(RoleViewModel role, int userId)
        {
            _roleRepository.UpdateRole(role);
            _utilityRepository.LogActivity(
               role.RoleName + " Role updated", UserId: userId, ActivityType: "Role");
        }

        public void DeleteRole(int id, int userId)
        {
            _roleRepository.DeleteRole(id);
            RoleViewModel? role = _roleRepository.GetRoleById(id);
            _utilityRepository.LogActivity(
                role?.RoleName + " Role deleted", UserId: userId, ActivityType: "Role");
        }
    }
}
