using Mivi.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.Models
{
    public class CoursesServices : ICoursesServices
    {
        SchoolEntities schoolContext;
        List<Course> courses;

        public CoursesServices()
        {
            schoolContext = ((MainWindow)App.Current.MainWindow).schoolContext;
            courses = schoolContext.Course.ToList<Course>();
        }

        

        public IEnumerable<Course> GetAllCourses()
        {
            //List<Course> courses = schoolContext.Course.ToList<Course>();
            return courses;
        }

        public Course InsertCourse(Course course)
        {
            
            Course _courseAffeted;
            
            _courseAffeted = schoolContext.Course.Add(course);//ADD THE ENTITY IN MEMORY
            schoolContext.SaveChanges();//PERSIST THE ENTITY TO THE DB
            courses.Add(_courseAffeted);//ADD THE ENTITY AFFECTED TO THE LIST
            //schoolContext.Entry(_courseAffeted).GetDatabaseValues();//RETRIEVE THE VALUE FROM THE DB
            return _courseAffeted;
        }

        public Course SaveCourse(Course course)
        {
            //ANOTHER WAY
            //schoolContext.Entry(course).State = course.CourseID == 0 ? 
            //    EntityState.Added : 
            //    EntityState.Modified;

            Course _courseAffected;
            if (course.CourseID == 0)
            {
                _courseAffected = InsertCourse(course);
            }
            else
            {
                _courseAffected = UpdateCourse(course);
            }
            return _courseAffected;
        }

        public Course UpdateCourse(Course course)
        {
            var _courseAffected = courses.Find((c) => c.CourseID == course.CourseID);//SELECT THE RECORD

            //CHANGE VALUES
            _courseAffected.Credits = course.Credits;
            _courseAffected.Department = course.Department;
            _courseAffected.DepartmentID = course.DepartmentID;
            _courseAffected.OnlineCourse = course.OnlineCourse;
            _courseAffected.OnsiteCourse = course.OnsiteCourse;
            _courseAffected.Person = course.Person;
            _courseAffected.StudentGrade = course.StudentGrade;
            _courseAffected.Title = course.Title;

            schoolContext.SaveChangesAsync();//SAVE CHANGES IN DATABASE

            //RETURNING THE OBJECT
            return _courseAffected;
        }

        public Course DeleteCourse(Course course)
        {
           
            var _courseAffected = schoolContext.Course.Remove(course);//REMOVE FROM MEMORY
            schoolContext.SaveChanges();//PERSIST CHANGES IN DB
            return _courseAffected;
        }
    }
}
