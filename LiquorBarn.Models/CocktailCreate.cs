using LiquorBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class CocktailCreate
    {
        public string Name { get; set; }

        public string LiquorsInCocktail { get; set; }

        public string Ingredients { get; set; }
    }
}
