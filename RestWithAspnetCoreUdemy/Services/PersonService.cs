using RestWithAspnetCoreUdemy.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace RestWithAspnetCoreUdemy.Services
{
    public class PersonService : IPersonService
    {
        private volatile int _count;
        private readonly ICollection<Person> _moqPersons = new Collection<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "Samuel",
                LastName = "de Jesus",
                Address = "Rio de Janeiro",
                Gender = "Male"
            },
            new Person
            {
                Id = 2,
                FirstName = "Rafaela",
                LastName = "Nascimento",
                Address = "São João de Meriti",
                Gender = "Fermale"
            }
        };

        public Person Create(Person person)
        {
            person.Id = IncrementAndGet();
            _moqPersons.Add(person);
            return person;
        }

        public Person FindByid(long id)
        {
            return _moqPersons.FirstOrDefault(p => p.Id.Equals(id));
        }

        public IEnumerable<Person> FindAll() => _moqPersons;

        public Person Update(Person person)
        {
            var temp = _moqPersons.FirstOrDefault(p => p.Id == person.Id);

            if (temp == null) return null;

            _moqPersons.Remove(temp);
            _moqPersons.Add(person);

            return person;
        }

        public void Delete(long id)
        {
            var person = _moqPersons.FirstOrDefault(p => p.Id == id);

            if (person != null)
                _moqPersons.Remove(person);
        }

        private long IncrementAndGet() => Interlocked.Increment(ref _count);
    }
}