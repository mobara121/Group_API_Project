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
    public class PreferenceService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly ApplicationUser _user;
        string[] _separator = { ", " };
        private readonly CocktailService _cocktailService = new CocktailService();

        public PreferenceService(string userId)
        {
            ApplicationUser user = _context.Users.Find(userId);
            _user = user;
        }

        public bool AddToPreferences(int id)
        {
            Cocktail cocktail = _context.Cocktails.Find(id);
            UserCocktail userCocktail =
                new UserCocktail
                {
                    User = _user,
                    Cocktail = cocktail
                };
            _context.UserCocktails.Add(userCocktail);
            _user.SavedCocktails.Add(userCocktail);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<CocktailListItem> GetAll()
        {
            List<Cocktail> cocktails = new List<Cocktail>();
            foreach (UserCocktail i in _user.SavedCocktails)
            {
                cocktails.Add(i.Cocktail);
            }

            var cocktailList = cocktails.Select(c => new CocktailListItem
            {
                Id = c.Id,
                Name = c.Name,
                LiquorsInCocktail = _cocktailService.ConvertFromCocktailLiquorToString(c.LiquorsInCocktail),
                Ingredients = c.Ingredients.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList()
            });

            return cocktailList;
        }

        public bool RemoveFromPreferences(int id)
        {
            _context.UserCocktails.Remove(_context.UserCocktails.SingleOrDefault(e => e.CocktailId == id && e.UserId == _user.Id));
            return _context.SaveChanges() == 1;
        }

        public bool ClearList()
        {
            _user.SavedCocktails.Clear();

            int numOfChanges = 0;
            List<UserCocktailDetail> clearedList = _context.UserCocktails.Where(e => e.UserId == _user.Id).Select(u => new UserCocktailDetail
            {
                Id = u.Id
            }).ToList();
            foreach (UserCocktailDetail userCocktail in clearedList)
            {
                _context.UserCocktails.Remove(_context.UserCocktails.Find(userCocktail.Id));
                numOfChanges++;
            }

            return _context.SaveChanges() == numOfChanges;
        }

        // helper
        public bool IsCocktailInList(int id)
        {
            var userCocktail = _context.UserCocktails.SingleOrDefault(e => e.CocktailId == id && e.UserId == _user.Id);
            return userCocktail != null;
        }
    }
}
