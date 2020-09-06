using LiquorBarn.Data;
using LiquorBarn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Services
{
    public class CocktailLiquorService
    {
        public List<CocktailLiquor> ConvertToLiquorsInCocktail(string userInput)
        {
            List<CocktailLiquor> finalList = new List<CocktailLiquor>();
            List<string> listedInput = userInput.Split(',').ToList();

            using (var ctx = new ApplicationDbContext())
            {
                foreach (string i in listedInput)
                {
                    var query =
                        ctx
                        .CocktailLiquors
                        .Single(e => (e.Liquor.Type == i && e.Liquor.Subtype == null) || e.Liquor.Subtype == i);

                    finalList.Add(query);
                }
            }

            return finalList;
        }
    }
}
