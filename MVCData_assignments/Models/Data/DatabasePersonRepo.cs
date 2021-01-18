using MVCData_assignments.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Data
{
    public class DatabasePersonRepo : IPersonRepo
    {
        private readonly PersonDbContext _personDbContext;
        public DatabasePersonRepo(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public Person Create(string name, City city, string phone)
        {
            Person person = new Person(name, city, phone);
            _personDbContext.Persons.Add(person);
            _personDbContext.SaveChanges();
            return person;
        }

        public bool Delete(Person person)
        {
            _personDbContext.Persons.Remove(person);
            int rowsEffected = _personDbContext.SaveChanges();

            return (rowsEffected > 0 ? true : false);

        }

        public List<Person> Read()
        {
            return _personDbContext.Persons.ToList();
        }

        public Person Read(int id)
        {
            return _personDbContext.Persons.SingleOrDefault(persons => persons.Id == id);
        }

        public Person Update(Person person)
        {
            Person savedPerson = Read(person.Id);
            if (savedPerson != null)
            {
                savedPerson.Name = person.Name;
                savedPerson.City = person.City;
                savedPerson.Phonenumber = person.Phonenumber;
                _personDbContext.SaveChanges();

                //return savedPerson;
            }
            //return null;
            return _personDbContext.Persons.SingleOrDefault(persons => persons.Id == person.Id);
        }
    }
}
