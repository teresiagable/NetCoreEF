using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.Database
{
    public class PersonDbContext : DbContext
    {

        //ctor
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        { }

        //DbSet<name of the class to be saved> "Name of the table"{get; set;}
        //DbSet tell us what to store as tables in the database
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }





    }
}
