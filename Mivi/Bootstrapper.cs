using Microsoft.Practices.Unity;
using Mivi.Models;
using Mivi.Views;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mivi
{
    public class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //REGISTER THE VIEWS
            Container.RegisterTypeForNavigation<StudentsView>("StudentsView");
            Container.RegisterTypeForNavigation<CoursesView>("CoursesView");
            Container.RegisterTypeForNavigation<DepartmentsView>("DepartmentsView");
            Container.RegisterTypeForNavigation<InstructorView>("InstructorView");

            //REGISTER THE CLASSES TO BE INJECTED INTO THE VIEWMODELS
            Container.RegisterType<ICoursesServices, CoursesServices>();
            Container.RegisterType<IDepartmentServices, DepartmentServices>();
            Container.RegisterType<IPersonServices, PersonServices>();
        }
    }
}
