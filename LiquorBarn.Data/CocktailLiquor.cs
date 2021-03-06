﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Data
{
    public class CocktailLiquor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Liquor))]
        public int LiquorId { get; set; }
        public virtual Liquor Liquor { get; set; }

        [ForeignKey(nameof(Cocktail))]
        public int CocktailId { get; set; }
        public virtual Cocktail Cocktail { get; set; }
    }
}
