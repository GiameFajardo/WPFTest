using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.Models
{
    public interface IDepartmentServices
    {
        IEnumerable<Department> GetAllDepartments();
        Department InsertDepartment(Department department);
        Department UpdateDepartment(Department department);
        Department SaveDepartment(Department department);
        Department DeleteDepartment(Department department);
    }
}
