using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Data
{
    public class InMemoryPersonRepo : IPersonRepo
    {
        private static int PersonId = 0;

        private static List<Person> personList = new List<Person>();


        public Person Create(string name, City city, string phone)
        {
            {
                int newId = ++PersonId;
                Person per = new Person() { Id = newId, Name = name, City = city, Phonenumber = phone };

                personList.Add(per);
                return per;
            }
        }

        public bool Delete(Person person)
        {
            return personList.Remove(person);
        }

        public List<Person> Read()
        {
            return personList;
        }

        public Person Read(int id)
        {

            foreach (Person per in personList)
            {
                if (per.Id == id)
                {
                    return per;
                }
            }

            return null;
        }

        public Person Update(Person person)
        {
            Person savedPerson = Read(person.Id);
            if (savedPerson != null)
            {
                savedPerson.Name = person.Name;
                savedPerson.City = person.City;
                savedPerson.Phonenumber = person.Phonenumber;
                return savedPerson;
            }
            return null;
        }


    }
}
