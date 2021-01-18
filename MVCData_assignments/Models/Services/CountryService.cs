using MVCData_assignments.Models.Data;
using MVCData_assignments.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;

        }

        public Country Add(CountryCreateModel newCountryModel)
        {
            return _countryRepo.Create(newCountryModel.Name);
        }

        public Country Edit(Country country)
        {
            return _countryRepo.Update(country);
        }

        public List<Country> GetAll()
        {
            return _countryRepo.Read();
        }

        public Country GetById(int id)
        {
            //should be some error handling here
            return _countryRepo.Read(id);
        }


        public bool RemoveCountry(int id)
        {
            Country country = _countryRepo.Read(id);
            if (country == null)
            {
                return false;
            }
            else
            {
                return _countryRepo.Delete(country);
            }

        }
    }
}
