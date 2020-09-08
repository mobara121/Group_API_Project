using LiquorBarn.Data;
using LiquorBarn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiquorBarn.Services
{
    public class CocktailService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // Create
        public bool AddCocktail(CocktailCreate model)
        {
            var entity =
                new Cocktail()
                {
                    Name = model.Name,
                    Ingredients = model.Ingredients
                };

            /*string[] separator = { ", " };
            List<string> liquors = model.LiquorsInCocktail.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string l in liquors)
            {
                
            }*/

            _context.Cocktails.Add(entity);
            return _context.SaveChanges() == 1;
        }
        
        // Get All
        public IEnumerable<CocktailListItem> GetAll()
        {
            var cocktailEntities = _context.Cocktails.ToList();
            var cocktailList = cocktailEntities.Select(c => new CocktailListItem
            {
                Id = c.Id,
                Name = c.Name,
                
                Ingredients = c.Ingredients
            });

            return cocktailList;
        }

        // Get By ID
    }
}
