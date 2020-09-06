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

        public List<CocktailLiquor> LiquorsInCocktail { get; set; }

        public List<string> Ingredients { get; set; }
    }
}
