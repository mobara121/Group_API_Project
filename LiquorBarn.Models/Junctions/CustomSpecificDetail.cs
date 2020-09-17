using LiquorBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class CustomSpecificDetail
    {
        public int Id { get; set; }
        public int CustomCocktailId { get; set; }
        public CustomCocktail CustomCocktail { get; set; }
        public int? SpecificLiquorId { get; set; }
        public SpecificLiquor SpecificLiquor { get; set; }
        public int? LiquorId { get; set; }
        public Liquor Liquor { get; set; }
    }
}
