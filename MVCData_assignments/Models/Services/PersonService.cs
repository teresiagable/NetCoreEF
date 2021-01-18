using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData_assignments.Models;
using MVCData_assignments.Models.Data;

namespace MVCData_assignments.Models.Services
{
    public class PersonService : IPersonService
    {


        IPersonRepo _personRepo;
        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
            //personList.Add(new Person("Anna Andersson", "Anderstorp", "111-2222333"));
            //personList.Add(new Person("Bosse Bildoktorn", "Bollebygd", "222-223344"));
            //personList.Add(new Person("Ceasar Carlsson", "Cöpenhamn", "333-2224455"));
            //personList.Add(new Person("Daniel Doppsko", "Sålundastad", "444-2255667"));
        }
        public Person Add(PersonCreateModel personCreateModel)
        {
            return _personRepo.Create(personCreateModel.Name, personCreateModel.City, personCreateModel.Phonenumber);
        }


        public Person Edit(Person person)
        {
            Person newDataPerson = person; //new Person() { Id = id, Name = personCreateModel.Name, City = personCreateModel.City, Phonenumber = personCreateModel.Phonenumber };
            return _personRepo.Update(newDataPerson);
        }
        public List<Person> GetAll()
        {
            return _personRepo.Read();
        }

        public Person GetById(int id)
        {
            //should be some error handling here
            return _personRepo.Read(id);
        }


        public bool RemovePerson(int id)
        {
            Person per = _personRepo.Read(id);
            if (per == null)
            {
                return false;
            }
            else
            {
                return _personRepo.Delete(per);
            }

        }

        public List<Person> FilterPerson(string searchPhrase)
        {
            List<Person> filteredList = new List<Person>();
            List<Person> returnList = new List<Person>();

            if (!string.IsNullOrEmpty(searchPhrase))
                filteredList = _personRepo.Read().FindAll(p => p.Name.ToLower().Contains(searchPhrase.ToLower()));
            returnList = filteredList;

            if (!string.IsNullOrEmpty(searchPhrase))
                filteredList = _personRepo.Read().FindAll(p => p.City.Name.ToLower().Contains(searchPhrase.ToLower()));

            var templist = returnList.Concat(filteredList); //add list from city-filter to previous name-filter 
            returnList = templist.ToList();

            if (!string.IsNullOrEmpty(searchPhrase))
                filteredList = _personRepo.Read().FindAll(p => p.Phonenumber.ToLower().Contains(searchPhrase.ToLower()));

            templist = returnList.Concat(filteredList); // Add phonenumber list to city/name-list  
            returnList = templist.Distinct().ToList(); //remove duplicates

            return returnList;
        }


    }
}
