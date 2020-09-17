using LiquorBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class LiquorDetail
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public int Id { get; set; }

        public string Type { get; set; }

        public string Subtype { get; set; }

        public List<string> ListOfCocktails
        {
            get
            {
                var cocktailLiquor = _context.CocktailLiquors.ToList();
                List<string> cocktailLiquors = new List<string>();
                foreach (CocktailLiquor cocktail in cocktailLiquor)
                {
                    if (cocktail.LiquorId == Id)
                    { cocktailLiquors.Add(cocktail.Cocktail.Name); }
                }
                return cocktailLiquors;
            } //Maybe where would be more appropriate?
        }

        public virtual List<SpecificLiquor> SpecificLiquors { get; set; }
    }
}
