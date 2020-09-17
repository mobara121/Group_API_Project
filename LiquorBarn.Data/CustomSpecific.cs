using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Data
{
    public class CustomSpecific
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CustomCocktail))]
        public int CustomCocktailId { get; set; }
        public virtual CustomCocktail CustomCocktail { get; set; }

        [ForeignKey(nameof(SpecificLiquor))]
        public int? SpecificLiquorId { get; set; }
        public virtual SpecificLiquor SpecificLiquor { get; set; }

        [ForeignKey(nameof(Liquor))]
        public int? LiquorId { get; set; }
        public virtual Liquor Liquor { get; set; }
    }
}
