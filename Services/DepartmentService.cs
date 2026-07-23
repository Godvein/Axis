using Axis.Models;
using Axis.Repositories;

namespace Axis.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService (IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public List<Department> GetDepartments()
        {
            return _departmentRepository.GetDepartments();
        }

    }
}
