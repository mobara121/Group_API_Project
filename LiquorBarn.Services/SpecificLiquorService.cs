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
                _context.SpecificLiquors.Where(e => e.Brand == brand).Select(s => new SpecificLiquorListItem
                {
                    Id = s.Id,
                    Liquor = ConvertFromLiquorToString(s.Liquor),
                    Brand = s.Brand,
                    CountryOfOrigin = s.CountryOfOrigin
                }).ToList();

            return specificLiquorList;
        }

        //-- Get All From Country
        public List<SpecificLiquorListItem> GetByCountry(string country)
        {
            List<SpecificLiquorListItem> specificLiquorList =
                _context.SpecificLiquors.Where(e => e.CountryOfOrigin == country).Select(s => new SpecificLiquorListItem
                {
                    Id = s.Id,
                    Liquor = ConvertFromLiquorToString(s.Liquor),
                    Brand = s.Brand,
                    CountryOfOrigin = s.CountryOfOrigin
                }).ToList();

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
    }
}
