﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Data
{
    public class CustomCocktail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CustomSpecific> LiquorsInCocktail { get; set; } = new List<CustomSpecific>();
        public string Ingredients { get; set; }
    }
}
