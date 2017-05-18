using Mivi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.Models
{
    public class PersonServices : IPersonServices
    {
        SchoolEntities schoolContext;
        List<Person> persons;
        public PersonServices()
        {
            schoolContext = ((MainWindow)App.Current.MainWindow).schoolContext;
            persons = schoolContext.Person.ToList<Person>();
        }
        public Person DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return persons;
        }

        public Person InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Person SavePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Person UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
