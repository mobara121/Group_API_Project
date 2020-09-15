using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class SpecificLiquorCountry
    {
        [Required]
        public string CountryOfOrigin { get; set; }
    }
}
