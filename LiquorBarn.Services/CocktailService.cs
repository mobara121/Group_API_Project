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
        public bool AddCocktail(CocktailCreate model)
        {
            var entity =
                new Cocktail()
                {
                    Name = model.Name,
                    LiquorsInCocktail = model.LiquorsInCocktail,
                    Ingredients = model.Ingredients
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cocktails.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CocktailListItem> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cocktails
                    .Select(
                        e =>
                        new CocktailListItem()
                        {
                            Id = e.Id,
                            Name = e.Name,
                            LiquorsInCocktail = e.LiquorsInCocktail,
                            Ingredients = e.Ingredients,
                        }
                        );
                return query.ToArray();
        }
    }
}
