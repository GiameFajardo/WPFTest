using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivi.Models
{
    public interface IPersonServices
    {
        IEnumerable<Person> GetAllPerson();
        Person InsertPerson(Person person);
        Person UpdatePerson(Person person);
        Person SavePerson(Person person);
        Person DeletePerson(Person person);
    }
}
