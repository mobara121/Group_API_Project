using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Data
{
    public class SpecificLiquor
    {
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[ForeignKey(nameof(Liquor))]
		public int LiquorId { get; set; }

		public virtual Liquor Liquor { get; set; }

		public string Brand { get; set; }

		public string CountryOfOrigin { get; set; }

		public virtual ICollection<CustomSpecific> ListOfCustomCocktails { get; set; } = new List<CustomSpecific>();
	}
}
