using Axis.Models;
using Axis.Repositories;

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
    }
}
