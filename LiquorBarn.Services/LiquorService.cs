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
        public bool AddLiquor(LiquorCreate model)
        {
            var entity =
                new Liquor()
                {
                    Type = model.Type,
                    Subtype = model.Subtype
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Liquors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
