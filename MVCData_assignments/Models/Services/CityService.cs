using MVCData_assignments.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Services
{
    public class CityService
    {
        using MVCData_assignments.Models.Data;
using MVCData_assignments.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Services
    {
        public class CityService
        {
            ICityRepo _cityRepo;

            public CityService(ICityRepo cityRepo)
            {
                _cityRepo = cityRepo;

            }

            public City Add(CityCreateModel newCityModel)
            {
                return _cityRepo.Create(newCityModel.Name);
            }

            public City Edit(City city)
            {
                return _cityRepo.Update(city);
            }

            public List<City> GetAll()
            {
                return _cityRepo.Read();
            }

            public City GetById(int id)
            {
                //should be some error handling here
                return _cityRepo.Read(id);
            }


            public bool RemoveCity(int id)
            {
                City city = _cityRepo.Read(id);
                if (city == null)
                {
                    return false;
                }
                else
                {
                    return _cityRepo.Delete(city);
                }

            }
        }
    }

}
}
