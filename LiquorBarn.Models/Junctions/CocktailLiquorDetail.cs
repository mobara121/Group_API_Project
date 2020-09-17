using LiquorBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class CocktailLiquorDetail
    {
        public int Id { get; set; }
        public int LiquorId { get; set; }
        public Liquor Liquor { get; set; }
        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
    }
}
