using LiquorBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Models
{
    public class UserCocktailDetail
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CocktailId { get; set; }
        public virtual Cocktail Cocktail { get; set; }
    }
}
