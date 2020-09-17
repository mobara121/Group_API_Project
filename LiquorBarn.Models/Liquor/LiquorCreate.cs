using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class LiquorCreate
    {
        [Required]
        public string Type { get; set; }
        public string Subtype { get; set; }
    }
}
