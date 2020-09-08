using LiquorBarn.Data;
using LiquorBarn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiquorBarn.Services
{
    public class LiquorService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool AddLiquor(LiquorCreate model)
        {
            var entity =
                new Liquor()
                {
                    Type = model.Type,
                    Subtype = model.Subtype
                };

            _context.Liquors.Add(entity);
            return _context.SaveChanges() == 1;
        }
    }
}
