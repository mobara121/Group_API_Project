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

            int numOfChanges = 1;

            String[] separator = { ", " };
            List<CocktailLiquor> cocktailLiquors = new List<CocktailLiquor>();
            List<string> liquors = model.LiquorsInCocktail.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string name in liquors)
            {
                var query =
                    _context
                    .Liquors
                    .Single(e => e.Type == name && e.Subtype == null || e.Subtype == name);

                CocktailLiquor junction = new CocktailLiquor()
                {
                    Liquor = query,
                    Cocktail = entity
                };

                _context.CocktailLiquors.Add(junction);
                cocktailLiquors.Add(junction);
                numOfChanges++;
            }

            entity.LiquorsInCocktail = cocktailLiquors;
            
            _context.Cocktails.Add(entity);
            return _context.SaveChanges() == numOfChanges;
        }

        // Get All
        public IEnumerable<CocktailListItem> GetAll()
        {
            String[] separator = { ", " };
            var cocktailEntities = _context.Cocktails.ToList();
            var cocktailList = cocktailEntities.Select(c => new CocktailListItem
            {
                Id = c.Id,
                Name = c.Name,
                LiquorsInCocktail = ConvertFromCocktailLiquorToString(c.LiquorsInCocktail),
                Ingredients = c.Ingredients.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            });

            return cocktailList;
        }

        public List<string> ConvertFromCocktailLiquorToString(ICollection<CocktailLiquor> input)
        {
            List<string> finalResult = new List<string>();
            foreach (CocktailLiquor i in input)
            {
                if (i.Liquor.Subtype != null)
                {
                    finalResult.Add(i.Liquor.Subtype);
                }
                else
                {
                    finalResult.Add(i.Liquor.Type);
                }
            }

            return finalResult;
        }

        // Get By ID
        public CocktailListItem GetByID(int id)
        {
            string[] separator = { ", " };
            Cocktail cocktail = _context.Cocktails.Find(id);

            return new CocktailListItem
            {
                Id = cocktail.Id,
                Name = cocktail.Name,
                LiquorsInCocktail = ConvertFromCocktailLiquorToString(cocktail.LiquorsInCocktail),
                Ingredients = cocktail.Ingredients.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
        }
    }
}
