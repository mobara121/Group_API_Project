using LiquorBarn.Data;
using LiquorBarn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Services
{
    public class CustomCocktailService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        string[] _separator = { ", " };
        private readonly ApplicationUser _user;

        public CustomCocktailService(string userId)
        {
            ApplicationUser user = _context.Users.Find(userId);
            _user = user;
        }

        //-- Create
        public bool Create(CocktailCreate model)
        {
            var entity =
                new CustomCocktail()
                {
                    User = _user,
                    Name = model.Name,
                    Ingredients = model.Ingredients
                };

            int numOfChanges = 1;

            List<CustomSpecific> customSpecifics = ConvertFromStringToCustomSpecific(model, entity);
            foreach (CustomSpecific i in customSpecifics)
                _context.CustomSpecifics.Add(i);

            numOfChanges += customSpecifics.Count();

            entity.LiquorsInCocktail = customSpecifics;

            _context.CustomCocktails.Add(entity);
            return _context.SaveChanges() == numOfChanges;
        }


        //-- Get All
        public IEnumerable<CocktailListItem> GetAll()
        {
            var customCocktailEntities = _context.CustomCocktails.ToList();
            var customCocktailList = customCocktailEntities.Select(c => new CocktailListItem
            {
                Id = c.Id,
                Name = c.Name,
                LiquorsInCocktail = ConvertFromCustomSpecificToString(c.LiquorsInCocktail),
                Ingredients = c.Ingredients.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            });

            return customCocktailList;
        }

        //-- Get By ID
        public CocktailListItem GetById(int id)
        {
            CustomCocktail customCocktail = _context.CustomCocktails.Find(id);

            if (customCocktail is null)
                return null;

            return new CocktailListItem
            {
                Id = customCocktail.Id,
                Name = customCocktail.Name,
                LiquorsInCocktail = ConvertFromCustomSpecificToString(customCocktail.LiquorsInCocktail),
                Ingredients = customCocktail.Ingredients.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
        }

        //-- Get By Name
        public CocktailListItem GetByName(string name)
        {
            CustomCocktail customCocktail = _context.CustomCocktails.SingleOrDefault(e => e.Name.ToLower() == name.ToLower());

            if (customCocktail is null)
                return null;

            return new CocktailListItem
            {
                Id = customCocktail.Id,
                Name = customCocktail.Name,
                LiquorsInCocktail = ConvertFromCustomSpecificToString(customCocktail.LiquorsInCocktail),
                Ingredients = customCocktail.Ingredients.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
        }


        //-- Update
        public bool Update(int id, CocktailCreate updatedCustomCocktail)
        {
            CustomCocktail customCocktail = _context.CustomCocktails.Find(id);

            int numOfChanges = 0;

            customCocktail.Name = updatedCustomCocktail.Name;
            customCocktail.Ingredients = updatedCustomCocktail.Ingredients;

            numOfChanges += RemoveCustomSpecific(id);

            List<CustomSpecific> customSpecifics = ConvertFromStringToCustomSpecific(updatedCustomCocktail, customCocktail);
            foreach (CustomSpecific i in customSpecifics)
                _context.CustomSpecifics.Add(i);

            numOfChanges += customSpecifics.Count();

            customCocktail.LiquorsInCocktail = customSpecifics;
            return _context.SaveChanges() == numOfChanges;
        }


        //-- Delete
        public bool Delete(int id)
        {
            int numOfChanges = 1;

            _context.CustomCocktails.Remove(_context.CustomCocktails.Find(id));

            numOfChanges += RemoveCustomSpecific(id);

            return _context.SaveChanges() == numOfChanges;
        }


        // helper
        public List<CustomSpecific> ConvertFromStringToCustomSpecific(CocktailCreate cocktailCreate, CustomCocktail customCocktail)
        {
            List<CustomSpecific> customSpecifics = new List<CustomSpecific>();
            List<string> liquors = cocktailCreate.LiquorsInCocktail.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string name in liquors)
            {
                var liquorQuery =
                    _context
                    .Liquors
                    .SingleOrDefault(e => e.Type == name && e.Subtype == null || e.Subtype == name);

                var specificLiquorQuery =
                    _context
                    .SpecificLiquors
                    .SingleOrDefault(e => e.Name == name);

                CustomSpecific junction = new CustomSpecific()
                {
                    CustomCocktail = customCocktail,
                    Liquor = liquorQuery,
                    SpecificLiquor = specificLiquorQuery
                };

                customSpecifics.Add(junction);
            }
            return customSpecifics;
        }

        // helper
        public List<string> ConvertFromCustomSpecificToString(ICollection<CustomSpecific> input)
        {
            List<string> finalResult = new List<string>();
            foreach (CustomSpecific i in input)
            {
                if (i.SpecificLiquor != null)
                    finalResult.Add(i.SpecificLiquor.Name);
                else if (i.Liquor.Subtype != null)
                    finalResult.Add(i.Liquor.Subtype);
                else
                    finalResult.Add(i.Liquor.Type);
            }

            return finalResult;
        }

        // helper
        public int RemoveCustomSpecific(int id)
        {
            int numOfChanges = 0;
            List<CustomSpecificDetail> customSpecificDetails = _context.CustomSpecifics.Where(e => e.CustomCocktailId == id).Select(d => new CustomSpecificDetail
            {
                Id = d.Id
            }).ToList();

            foreach (CustomSpecificDetail i in customSpecificDetails)
            {
                _context.CustomSpecifics.Remove(_context.CustomSpecifics.Find(i.Id));
                numOfChanges++;
            }
            return numOfChanges;
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

                var queryTwo =
                    _context
                    .SpecificLiquors
                    .SingleOrDefault(e => e.Name == name);

                if (query is null && queryTwo is null)
                    return false;
            }
            return true;
        }

        // helper
        public bool ChangesWereNotMade(int id, CocktailCreate updatedCustomCocktail)
        {
            CustomCocktail customCocktail = _context.CustomCocktails.Find(id);

            return updatedCustomCocktail.Name == customCocktail.Name && string.Join(",", ConvertFromCustomSpecificToString(customCocktail.LiquorsInCocktail).ToList()) == string.Join(",", updatedCustomCocktail.LiquorsInCocktail.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()) && updatedCustomCocktail.Ingredients.ToLower() == customCocktail.Ingredients.ToLower();
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
