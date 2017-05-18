using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.Models
{
    public interface ICoursesServices
    {
        IEnumerable<Course> GetAllCourses();
        Course InsertCourse(Course course);
        Course UpdateCourse(Course course);
        Course SaveCourse(Course course);
        Course DeleteCourse(Course course);
    }
}
