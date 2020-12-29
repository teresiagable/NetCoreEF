using System.Collections.Generic;

namespace MVCData_assignments.Models.Services
{
    public interface IPersonService
    {
        Person Add(PersonCreateModel personCreateModel);
        Person Edit(Person person);
            //Person Edit(int id, PersonCreateModel personCreateModel);

        List<Person> FilterPerson(string searchPhrase);
        List<Person> GetAll();
        Person GetById(int id);
        bool RemovePerson(int id);
    }
}