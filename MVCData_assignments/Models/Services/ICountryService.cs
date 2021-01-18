using MVCData_assignments.Models.ViewModels;
using System.Collections.Generic;

namespace MVCData_assignments.Models.Services
{
    public interface ICountryService
    {
        Country Add(CountryCreateModel newCountryModel);
        Country Edit(Country country);
        List<Country> GetAll();
        Country GetById(int id);
        bool RemoveCountry(int id);
    }
}