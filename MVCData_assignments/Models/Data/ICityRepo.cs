using System.Collections.Generic;

namespace MVCData_assignments.Models.Data
{
    public interface ICityRepo
    {
        City Create(string name, Country country);
        bool Delete(City city);
        List<City> Read();
        City Read(int id);
        City Update(City city);
    }
}