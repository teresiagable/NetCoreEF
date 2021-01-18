using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Models.ViewModels
{
    public class CountryCreateModel
    {
        [Required]
        [StringLength(32, ErrorMessage = "The name is too long", MinimumLength = 1)]
        public string Name { get; set; }
    }
}
