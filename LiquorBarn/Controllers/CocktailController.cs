using LiquorBarn.Models;
using LiquorBarn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace LiquorBarn.Controllers
{
    public class CocktailController : ApiController
    {
        private readonly CocktailService _service = new CocktailService();

        [HttpPost]
        public IHttpActionResult Post(CocktailCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.GetByName(model.Name) != null)
                return Conflict();

            if (!_service.IsLiquorInDatabase(model.LiquorsInCocktail))
                return InternalServerError(new SystemException("Liquor is not in database."));

            if (!_service.AddCocktail(model))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var liquors = _service.GetAll();
            return Ok(liquors);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _service.GetByID(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Cocktail/ByName/{name}")]
        public IHttpActionResult Get([FromUri]string name)
        {
            var result = _service.GetByName(name);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, [FromBody]CocktailCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.GetByID(id) is null)
                return NotFound();

            if (!_service.IsLiquorInDatabase(model.LiquorsInCocktail))
                return InternalServerError(new SystemException("Liquor is not in database."));

            if (_service.ChangesWereNotMade(id, model))
                return Ok("No changes were made.");

            if (!_service.UpdateByID(id, model))
                return InternalServerError();


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (_service.GetByID(id) is null)
                return NotFound();

            if (!_service.DeleteCocktail(id))
                return InternalServerError();

            return Ok();
        }
    }
}