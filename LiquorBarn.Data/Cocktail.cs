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

        [Required]
        public string Name { get; set; }

        public virtual ICollection<CocktailLiquor> LiquorsInCocktail { get; set; } = new List<CocktailLiquor>();

        public List<string> Ingredients { get; set; }
    }
}
