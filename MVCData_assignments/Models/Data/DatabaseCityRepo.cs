using MVCData_assignments.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Data
{
    public class DatabaseCityRepo : ICityRepo
    {
        private readonly PersonDbContext _personDbContext;

        public DatabaseCityRepo(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public City Create(string name, Country country)
        {
            City city = new City(name, country);
            _personDbContext.Cities.Add(city);
            _personDbContext.SaveChanges();
            return city;
        }

        public bool Delete(City city)
        {
            _personDbContext.Cities.Remove(city);
            int rowsEffected = _personDbContext.SaveChanges();

            return (rowsEffected > 0 ? true : false);

        }

        public List<City> Read()
        {
            return _personDbContext.Cities.ToList();
        }

        public City Read(int id)
        {
            return _personDbContext.Cities.SingleOrDefault(city => city.Id == id);
        }

        public City Update(City city)
        {
            City savedCity = Read(city.Id);
            if (savedCity != null)
            {
                savedCity.Name = city.Name;
                savedCity.Country = city.Country;

                _personDbContext.SaveChanges();

            }
            return _personDbContext.Cities.SingleOrDefault(city => city.Id == city.Id);
        }
    }
}
}
