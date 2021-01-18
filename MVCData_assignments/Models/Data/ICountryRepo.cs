using System.Collections.Generic;

namespace MVCData_assignments.Models.Data
{
    public interface ICountryRepo
    {
        Country Create(string name);
        bool Delete(Country country);
        List<Country> Read();
        Country Read(int id);
        Country Update(Country country);
    }
}