using MVCData_assignments.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Data
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        private readonly PersonDbContext _personDbContext;

        public DatabaseCountryRepo(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public Country Create(string name)
        {
            Country country = new Country(name);
            _personDbContext.Countries.Add(country);
            _personDbContext.SaveChanges();
            return country;
        }

        public bool Delete(Country country)
        {
            _personDbContext.Countries.Remove(country);
            int rowsEffected = _personDbContext.SaveChanges();

            return (rowsEffected > 0 ? true : false);

        }

        public List<Country> Read()
        {
            return _personDbContext.Countries.ToList();
        }

        public Country Read(int id)
        {
            return _personDbContext.Countries.SingleOrDefault(country => country.Id == id);
        }

        public Country Update(Country country)
        {
            Country savedCountry = Read(country.Id);
            if (savedCountry != null)
            {
                savedCountry.Name = country.Name;

                _personDbContext.SaveChanges();

                //return savedPerson;
            }
            //return null;
            return _personDbContext.Countries.SingleOrDefault(country => country.Id == country.Id);
        }
    }
}
