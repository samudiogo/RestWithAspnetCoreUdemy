using System.Collections.Generic;
using RestWithAspnetCoreUdemy.Model;

namespace RestWithAspnetCoreUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);

        Person FindByid(long id);

        IEnumerable<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);


    }
}