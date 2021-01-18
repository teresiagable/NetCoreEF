using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models
{
    public class Country
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<City> Cities { get; set; }  //Fluent API?

        public Country() {}

        public Country(string name)
        {
            Name = name;
        }

        public Country(int id, string name) : this(name)
        {
            Id = id;
        }
    }
}
