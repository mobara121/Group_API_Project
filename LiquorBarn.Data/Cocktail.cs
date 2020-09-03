using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Data
{
    public class Cocktail
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //public List<Liquor> LiquorsInCocktail { get; set; }

        public string Ingredients { get; set; }
    }
}
