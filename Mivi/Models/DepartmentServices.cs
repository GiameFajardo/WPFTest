using Mivi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.Models
{
    public class DepartmentServices : IDepartmentServices
    {
        SchoolEntities schoolContext;
        List<Department> departments;
        public DepartmentServices()
        {
            schoolContext = ((MainWindow)App.Current.MainWindow).schoolContext;
            departments = schoolContext.Department.ToList<Department>();
        }
        public Department DeleteDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return departments;
        }

        public Department InsertDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Department SaveDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Department UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
