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
        

        //-- Create
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


        //-- Get All
        public IEnumerable<LiquorListItem> GetAllLiquor()
        {
            var liquorEntities = _context.Liquors.ToList();
            var liquorList = liquorEntities.Select(l => new LiquorListItem
            {
                Id = l.Id,
                Type = l.Type,
                Subtype = l.Subtype,
            });

            return liquorList;
        }

        //-- Get By Id
        public LiquorDetail GetLiquorByID(int id)
        {
            Liquor liquor = _context.Liquors.Find(id);

            if (liquor is null)
                return null;

            return new LiquorDetail
            {
                Id = liquor.Id,
                Type = liquor.Type,
                Subtype = liquor.Subtype,
            };
        }


        //-- Update
        public bool UpdateLiquor(int id, LiquorCreate updatedLiquor)
        {
            Liquor liquor = _context.Liquors.Find(id);

            liquor.Type = updatedLiquor.Type;
            liquor.Subtype = updatedLiquor.Subtype;

            return _context.SaveChanges() == 1;
        }


        //-- Delete
        public bool DeleteLiquor(int id)
        {
            _context.Liquors.Remove(_context.Liquors.Find(id));

            return _context.SaveChanges() == 1;
        }



        // helper
        public bool IsLiquorInAnyCocktails(int id)
        {
            List<LiquorListItem> query = _context.CocktailLiquors.Where(e => e.LiquorId == id).Select(
                l => new LiquorListItem
                {
                    Id = l.Id
                }).ToList();

            List<LiquorListItem> queryTwo =
                _context.CustomSpecifics.Where(e => e.LiquorId == id).Select(
                    l => new LiquorListItem
                    {
                        Id = l.Id
                    }).ToList();

            return query.Count() != 0 || queryTwo.Count != 0;
        }

        // helper
        public bool IsLiquorInDatabase(LiquorCreate model)
        {
            var query =
                    _context
                    .Liquors
                    .SingleOrDefault(e => e.Type == model.Type && e.Subtype == model.Subtype);
            if (query != null)
                return true;
            return false;
        }

        // helper
        public bool ChangesWereNotMade(int id, LiquorCreate updatedLiquor)
        {
            Liquor liquor = _context.Liquors.Find(id);

            return liquor.Type == updatedLiquor.Type && liquor.Subtype == updatedLiquor.Subtype;
        }
    }
}
