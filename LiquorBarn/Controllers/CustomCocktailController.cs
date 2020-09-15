using LiquorBarn.Models;
using LiquorBarn.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Razor.Parser;
using System.Xml.XPath;

namespace LiquorBarn.Controllers
{
    public class CustomCocktailController : ApiController
    {
        private CustomCocktailService CreateCustomCocktailService()
        {
            return new CustomCocktailService(User.Identity.GetUserId());
        }

        [HttpPost]
        public IHttpActionResult Post(CocktailCreate model)
        {
            var service = CreateCustomCocktailService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (service.DoesCocktailAlreadyExist(model))
                return Conflict();

            if (!service.IsLiquorInDatabase(model.LiquorsInCocktail))
                return InternalServerError(new SystemException("Liquor is not in the database."));

            if (!service.Create(model))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreateCustomCocktailService();

            var customCocktails = service.GetAll();
            return Ok(customCocktails);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var service = CreateCustomCocktailService();

            var result = service.GetById(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/CustomCocktail/ByName/{name}")]
        public IHttpActionResult Get([FromUri]string name)
        {
            var service = CreateCustomCocktailService();

            var result = service.GetByName(name.Replace('_', ' '));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, [FromBody]CocktailCreate model)
        {
            var service = CreateCustomCocktailService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (service.GetById(id) is null)
                return NotFound();

            if (!service.IsLiquorInDatabase(model.LiquorsInCocktail))
                return InternalServerError(new SystemException("Liquor is not in database."));

            if (service.ChangesWereNotMade(id, model))
                return Ok("No changes were made.");

            if (service.DoesCocktailAlreadyExist(model))
                return Conflict();

            if (!service.Update(id, model))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCustomCocktailService();

            if (service.GetById(id) is null)
                return NotFound();

            if (!service.Delete(id))
                return InternalServerError();

            return Ok();
        }
    }
}