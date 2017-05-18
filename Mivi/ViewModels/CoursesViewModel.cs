using Mivi.Events;
using Mivi.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mivi.ViewModels
{
    public class CoursesViewModel:BindableBase
    {
        #region Declarations

        IEventAggregator _eventAggregator;
        ICoursesServices _coursesServices;
        IDepartmentServices _departmentServices;
        IPersonServices _personServices;
        public ObservableCollection<Course> CoursesCollection { get; set; }
        public ObservableCollection<Department> DepartmentsCollection { get; set; }
        public ObservableCollection<Person> StudentsCollection { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Constructors
        public CoursesViewModel(IEventAggregator eventAggregator, ICoursesServices coursesService,IDepartmentServices departmentService, IPersonServices personService)
        {
            //INMERTION CONTROL
            _eventAggregator = eventAggregator;
            _coursesServices = coursesService;
            _departmentServices = departmentService;
            _personServices = personService;

            //COMMANDS INITIALIZATION
            SaveCommand = new DelegateCommand(SaveExecute, SaveCanExecute);
            NewCommand = new DelegateCommand(NewExecute, NewCanExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute, DeleteCanExecute);

            //ObservesProperty(()=>Name).ObservesProperty(()=>LastName);

            //COLLECTIONS INITIALIZATION
            CoursesCollection = new ObservableCollection<Course>();
            DepartmentsCollection = new ObservableCollection<Department>();
            StudentsCollection = new ObservableCollection<Person>();

            //LOAD COLLECTIONS
            LoadCourses();
            LoadDepartments();
            LoadStudents();
        }


        #endregion
        
        #region Persistence Methods

        private void DeleteExecute()
        {
            var _courseAffected = _coursesServices.DeleteCourse(Course);
            if (_courseAffected != null)
            {
                CoursesCollection.Remove(_courseAffected);
                SelectedCourse = CoursesCollection.First();
            }
        }

        private bool DeleteCanExecute()
        {
            return true;
        }

        private bool NewCanExecute()
        {
            return true;
        }

        private void NewExecute()
        {
            Course = new Course();
        }

        private void SaveExecute()
        {

            Course.DepartmentID = SelectedDepartment.DepartmentID;
            var _courseAffected = _coursesServices.SaveCourse(Course);
            if (!CoursesCollection.Contains(_courseAffected)){
                CoursesCollection.Add(_courseAffected);
                _courseAffected.Department = SelectedDepartment;
                SelectedCourse = _courseAffected;
            }
            _eventAggregator.GetEvent<UpdatedEvent>().Publish(SelectedCourse.Title);
        }

        private bool SaveCanExecute()
        {
            return true; //!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(LastName);
        }


        #endregion
        
        #region Load Methods

        private void LoadCourses()
        {
            foreach (var course in _coursesServices.GetAllCourses())
            {
                CoursesCollection.Add(course);
            }
        }
        private void LoadDepartments()
        {
            foreach (var department in _departmentServices.GetAllDepartments())
            {
                DepartmentsCollection.Add(department);
            }
        }
        private void LoadStudents()
        {
            
        }
        #endregion

        #region Properties
        private Course _selectedCourse;

        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set { _selectedCourse = value;
                OnPropertyChanged(() => SelectedCourse);
                Course = SelectedCourse;
                DepartmentsCollection.ToList().ForEach(item =>
                    {
                        if(SelectedCourse!=null)
                        if (item.DepartmentID == SelectedCourse.Department.DepartmentID)
                        {
                            SelectedDepartment = item;
                        }
                    }
                );
                if (SelectedCourse != null)
                    foreach (var person in SelectedCourse.Person)
                {
                    StudentsCollection.Clear();
                    StudentsCollection.Add(person);
                }
            }
        }
        private Department _selectedDepartment;

        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set { _selectedDepartment = value;
                OnPropertyChanged(() => SelectedDepartment);
            }
        }


        private Course _course;

        public Course Course
        {
            get { return _course; }
            set
            {
                _course = value;
                OnPropertyChanged(() => Course);
            }
        }
        #endregion

    }
}
