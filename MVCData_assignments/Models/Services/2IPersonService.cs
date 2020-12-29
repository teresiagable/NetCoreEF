using System.Collections.Generic;

namespace MVCData_assignments.Models.Services
{
    public interface IPersonService2
    {
        Person Add(string name, string city, string phonenumber);
        List<Person> FilterPerson(string searchPhrase);
        List<Person> GetAll();
        Person GetById(int id);
        bool Remove(int id);
        bool Edit(Person person);
    }
}