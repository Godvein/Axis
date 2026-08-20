using Axis.Models;
using Axis.Repositories;
using Axis.Models.ViewModels;

namespace Axis.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService (IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public List<Role> GetRoles()
        {
            return _roleRepository.GetRoles();
        }
        public void AddRole(RoleViewModel role)
        {
            _roleRepository.AddRole(role);
        }  
        public RoleViewModel? GetRoleById(int id) {
            return _roleRepository.GetRoleById(id);
        }

        public void UpdateRole(RoleViewModel role)
        {
            _roleRepository.UpdateRole(role);
        }
    }
}
