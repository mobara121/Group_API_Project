using LiquorBarn.Models;
using LiquorBarn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LiquorBarn.Controllers
{
    public class SpecificLiquorController : ApiController
    {
        private readonly SpecificLiquorService _service = new SpecificLiquorService();
        
        //Post
        [HttpPost]
        public IHttpActionResult Post(SpecificLiquorCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_service.IsLiquorInDatabase(model))
                return InternalServerError(new SystemException($"{model.Liquor} does not exist in database"));

            if (_service.IsSpecificLiquorInDatabase(model))
                return Conflict();

            if (!_service.AddSpecificLiquor(model))
                return InternalServerError();

            return Ok();
        }
        //Get
        [HttpGet]
        public IHttpActionResult GetAll()
        {             
            return Ok(_service.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet]
        [Route("api/SpecificLiquor/ByBrand")]
        public IHttpActionResult GetByBrand(SpecificLiquorBrand model)
        {
            var result = _service.GetByBrand(model.Brand);

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/SpecificLiquor/ByCountry")]
        public IHttpActionResult GetByCountry(SpecificLiquorCountry model)
        {
            var result = _service.GetByCountry(model.CountryOfOrigin);

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }
        //Put
        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, [FromBody] SpecificLiquorCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.GetById(id) is null)
                return NotFound();

            if (!_service.IsLiquorInDatabase(model))
                return InternalServerError(new SystemException("Liquor is not in the database."));

            if (_service.NoChangesWereMade(id, model))
                return Ok("No changes were made.");

            if (_service.IsSpecificLiquorInDatabase(model))
                return Conflict();

            if (!_service.Update(id, model))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (_service.GetById(id) is null)
                return NotFound();

            if (_service.IsSpecificLiquorInAnyCocktails(id))
                return Content<string>(System.Net.HttpStatusCode.Forbidden, "WARNING: This liquor is currently being used in cocktails. Delete or edit those cocktails first if you want to proceed.");

            if (!_service.Delete(id))
                return InternalServerError();

            return Ok();
        }

    }
}