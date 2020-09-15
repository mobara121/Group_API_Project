using LiquorBarn.Data;
using LiquorBarn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
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
        string[] _separator = { ", " };

        //-- Create
        public bool AddCocktail(CocktailCreate model)
        {
            var entity =
                new Cocktail()
                {
                    Name = model.Name,
                    Ingredients = model.Ingredients
                };

            int numOfChanges = 1;

            List<CocktailLiquor> cocktailLiquors = ConvertFromStringToCocktailLiquor(model, entity);
            foreach (CocktailLiquor i in cocktailLiquors)
                _context.CocktailLiquors.Add(i);

            numOfChanges += cocktailLiquors.Count();

            entity.LiquorsInCocktail = cocktailLiquors;

            _context.Cocktails.Add(entity);
            return _context.SaveChanges() == numOfChanges;
        }


        //-- Get All
        public IEnumerable<CocktailListItem> GetAll()
        {
            var cocktailEntities = _context.Cocktails.ToList();
            var cocktailList = cocktailEntities.Select(c => new CocktailListItem
            {
                Id = c.Id,
                Name = c.Name,
                LiquorsInCocktail = ConvertFromCocktailLiquorToString(c.LiquorsInCocktail),
                Ingredients = c.Ingredients.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            });

            return cocktailList;
        }

        //-- Get By ID
        public CocktailListItem GetByID(int id)
        {
            Cocktail cocktail = _context.Cocktails.Find(id);

            if (cocktail is null)
                return null;

            return new CocktailListItem
            {
                Id = cocktail.Id,
                Name = cocktail.Name,
                LiquorsInCocktail = ConvertFromCocktailLiquorToString(cocktail.LiquorsInCocktail),
                Ingredients = cocktail.Ingredients.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
        }

        //-- Get By Name
        public CocktailListItem GetByName(string name)
        {
            Cocktail cocktail = _context.Cocktails.SingleOrDefault(e => e.Name.ToLower() == name.ToLower());

            if (cocktail is null)
                return null;

            return new CocktailListItem
            {
                Id = cocktail.Id,
                Name = cocktail.Name,
                LiquorsInCocktail = ConvertFromCocktailLiquorToString(cocktail.LiquorsInCocktail),
                Ingredients = cocktail.Ingredients.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
        }


        //-- Update
        public bool UpdateByID(int id, CocktailCreate updatedCocktail)
        {
            Cocktail cocktail = _context.Cocktails.Find(id);

            int numOfChanges = 0;
            if (!(cocktail.Name == updatedCocktail.Name && cocktail.Ingredients == updatedCocktail.Ingredients))
                numOfChanges = 1;

            cocktail.Name = updatedCocktail.Name;
            cocktail.Ingredients = updatedCocktail.Ingredients;

            numOfChanges += RemoveCocktailLiquor(id);

            List<CocktailLiquor> cocktailLiquors = ConvertFromStringToCocktailLiquor(updatedCocktail, cocktail);
            foreach (CocktailLiquor i in cocktailLiquors)
                _context.CocktailLiquors.Add(i);

            numOfChanges += cocktailLiquors.Count();

            cocktail.LiquorsInCocktail = cocktailLiquors;
            return _context.SaveChanges() == numOfChanges;
        }


        //-- Delete
        public bool DeleteCocktail(int id)
        {
            int numOfChanges = 1;

            _context.Cocktails.Remove(_context.Cocktails.Find(id));

            numOfChanges += RemoveCocktailLiquor(id);

            return _context.SaveChanges() == numOfChanges;
        }




        // helper
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

        // helper
        public List<CocktailLiquor> ConvertFromStringToCocktailLiquor(CocktailCreate cocktailCreate, Cocktail cocktail)
        {
            List<CocktailLiquor> cocktailLiquors = new List<CocktailLiquor>();
            List<string> liquors = cocktailCreate.LiquorsInCocktail.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string name in liquors)
            {
                var query =
                _context
                .Liquors
                .Single(e => e.Type == name && e.Subtype == null || e.Subtype == name);

                CocktailLiquor junction = new CocktailLiquor()
                {
                    Liquor = query,
                    Cocktail = cocktail
                };

                cocktailLiquors.Add(junction);
            }
            return cocktailLiquors;
        }

        // helper
        public bool IsLiquorInDatabase(string list)
        {
            List<string> liquors = list.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string name in liquors)
            {
                var query =
                    _context
                    .Liquors
                    .SingleOrDefault(e => e.Type == name && e.Subtype == null || e.Subtype == name);
                if (query is null)
                    return false;
            }
            return true;
        }

        // helper
        public bool ChangesWereNotMade(int id, CocktailCreate updatedCocktail)
        {
            Cocktail cocktail = _context.Cocktails.Find(id);

            return updatedCocktail.Name == cocktail.Name
                && string.Join(",", ConvertFromCocktailLiquorToString(cocktail.LiquorsInCocktail).ToList()) == string.Join(",", updatedCocktail.LiquorsInCocktail.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList())
                && updatedCocktail.Ingredients.ToLower() == cocktail.Ingredients.ToLower();
        }

        // helper
        public int RemoveCocktailLiquor(int id)
        {
            int numOfChanges = 0;
            List<CocktailLiquorDetail> cocktailLiquorDetails = _context.CocktailLiquors.Where(e => e.CocktailId == id).Select(
                d => new CocktailLiquorDetail
                {
                    Id = d.Id
                }).ToList();

            foreach (CocktailLiquorDetail i in cocktailLiquorDetails)
            {
                _context.CocktailLiquors.Remove(_context.CocktailLiquors.Find(i.Id));
                numOfChanges++;
            }
            return numOfChanges;
        }

        // helper
        public bool DoesCocktailAlreadyExist(CocktailCreate model)
        {
            CocktailListItem cocktailListItem = GetByName(model.Name);

            if (cocktailListItem is null)
                return false;

            return model.LiquorsInCocktail == string.Join(", ", cocktailListItem.LiquorsInCocktail) && model.Ingredients == string.Join(", ", cocktailListItem.Ingredients);
        }
    }
}
