using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class SpecificLiquorCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Liquor { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string CountryOfOrigin { get; set; }
    }
}
