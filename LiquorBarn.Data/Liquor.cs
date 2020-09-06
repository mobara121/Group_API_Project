using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Data
{
    public class Liquor
    {
		[Key]
		public int Id { get; set; }

		[Required]
		public string Type { get; set; }

		public string Subtype { get; set; }

		public List<CocktailLiquor> ListOfCocktails { get; set; }

		public List<SpecificLiquor> SpecificLiquors { get; set; }
	}
}
