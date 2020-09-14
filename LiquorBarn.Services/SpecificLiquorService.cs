using LiquorBarn.Data;
using LiquorBarn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorBarn.Services
{
    public class SpecificLiquorService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //-- Create
        public bool AddSpecificLiquor(SpecificLiquorCreate model)
        {
            var entity = new SpecificLiquor
            {
                Liquor = ConvertFromStringToLiquor(model.Liquor),
                Brand = model.Brand,
                CountryOfOrigin = model.CountryOfOrigin
            };

            _context.SpecificLiquors.Add(entity);
            return _context.SaveChanges() == 1;
        }


        //-- Get All
        public IEnumerable<SpecificLiquorListItem> GetAll()
        {
            var specificLiquorEntities = _context.SpecificLiquors.ToList();
            var specificLiquorList = specificLiquorEntities.Select(s => new SpecificLiquorListItem
            {
                Id = s.Id,
                Liquor = ConvertFromLiquorToString(s.Liquor),
                Brand = s.Brand,
                CountryOfOrigin = s.CountryOfOrigin
            });

            return specificLiquorList;
        }

        //-- Get By ID
        public SpecificLiquorListItem GetById(int id)
        {
            SpecificLiquor entity = _context.SpecificLiquors.Find(id);

            if (entity is null)
                return null;

            return new SpecificLiquorListItem
            {
                Id = entity.Id,
                Liquor = ConvertFromLiquorToString(entity.Liquor),
                Brand = entity.Brand,
                CountryOfOrigin = entity.CountryOfOrigin
            };
        }

        //-- Get All By Brand
        public List<SpecificLiquorListItem> GetByBrand(string brand)
        {
           
            List<SpecificLiquorListItem> specificLiquorList =
                _context.SpecificLiquors.Where(e => e.Brand.ToLower() == brand.ToLower()).Select(s => new SpecificLiquorListItem
                {                    
                    Id = s.Id,                   
                    Brand = s.Brand,
                    CountryOfOrigin = s.CountryOfOrigin
                }).ToList();

            foreach (SpecificLiquorListItem item in specificLiquorList)
            {
                SpecificLiquor specificLiquor = _context.SpecificLiquors.Find(item.Id);
                item.Liquor = ConvertFromLiquorToString(specificLiquor.Liquor);
            }

            return specificLiquorList;
        }

        //-- Get All From Country
        public List<SpecificLiquorListItem> GetByCountry(string country)
        {
            List<SpecificLiquorListItem> specificLiquorList =
                _context.SpecificLiquors.Where(e => e.CountryOfOrigin.ToLower() == country.ToLower()).Select(s => new SpecificLiquorListItem
                {
                    Id = s.Id,                   
                    Brand = s.Brand,
                    CountryOfOrigin = s.CountryOfOrigin
                }).ToList();

            foreach (SpecificLiquorListItem item in specificLiquorList)
            {
                SpecificLiquor specificLiquor = _context.SpecificLiquors.Find(item.Id);
                item.Liquor = ConvertFromLiquorToString(specificLiquor.Liquor);
            }

            return specificLiquorList;
        }


        //-- Update
        public bool Update(int id, SpecificLiquorCreate updatedSpecificLiquor)
        {
            SpecificLiquor specificLiquor = _context.SpecificLiquors.Find(id);

            specificLiquor.Liquor = ConvertFromStringToLiquor(updatedSpecificLiquor.Liquor);
            specificLiquor.Brand = updatedSpecificLiquor.Brand;
            specificLiquor.CountryOfOrigin = updatedSpecificLiquor.CountryOfOrigin;

            return _context.SaveChanges() == 1;
        }


        //-- Delete
        public bool Delete(int id)
        {
            _context.SpecificLiquors.Remove(_context.SpecificLiquors.Find(id));
            return _context.SaveChanges() == 1;
        }

        // helper
        public Liquor ConvertFromStringToLiquor(string name)
        {
            return _context.Liquors.SingleOrDefault(e => e.Type == name && e.Subtype == null || e.Subtype == name);
        }

        // helper
        public string ConvertFromLiquorToString(Liquor liquor)
        {
            if (liquor.Subtype is null)
                return liquor.Type;
            return liquor.Subtype;
        }
        // helper
        public bool IsSpecificLiquorInDatabase(SpecificLiquorCreate model)
        {
            var liquor = ConvertFromStringToLiquor(model.Liquor);

            SpecificLiquor query = _context.SpecificLiquors.SingleOrDefault(q => q.Brand == model.Brand && q.CountryOfOrigin == model.CountryOfOrigin && q.Liquor.Type == liquor.Type && q.Liquor.Subtype == liquor.Subtype);
            
            if (query != null)
                return true;

            return false;
        }
        public bool IsLiquorInDatabase(SpecificLiquorCreate model)
        {
            var liquor = ConvertFromStringToLiquor(model.Liquor);
            //var query = _context.Liquors.SingleOrDefault(q => q.Type == liquor.Type && q.Subtype == liquor.Subtype);
            

            if (liquor != null)
                return true;

            return false;
        }
        public bool NoChangesWereMade(int id, SpecificLiquorCreate model)
        {
            SpecificLiquor liquor = _context.SpecificLiquors.Find(id);

            return liquor.Brand == model.Brand && liquor.CountryOfOrigin == model.CountryOfOrigin && ConvertFromLiquorToString(liquor.Liquor) == model.Liquor;            
        }
    }
}
