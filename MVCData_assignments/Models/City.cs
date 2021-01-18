using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get;set; }
        public List<Person> Persons { get; set; }
        public City()
        {
        }

        public City(string name, Country country)
        {
            Name = name;
            Country = country;
        }

        public City(int id, string name, Country country) : this(name, country)
        {
            Id = id;
        }
    }
}
