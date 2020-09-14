using LiquorBarn.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LiquorBarn.Controllers
{
    public class PreferenceController : ApiController
    {
        private readonly CocktailService _cocktailService = new CocktailService();
        private PreferenceService CreatePreferenceService()
        {
            return new PreferenceService(User.Identity.GetUserId());
        }

        [HttpPost]
        public IHttpActionResult Post(int id)
        {
            var service = CreatePreferenceService();

            if (_cocktailService.GetByID(id) is null)
                return NotFound();

            if (service.IsCocktailInList(id))
                return Conflict();

            if (!service.AddToPreferences(id))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreatePreferenceService();
            var userCocktails = service.GetAll();
            return Ok(userCocktails);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePreferenceService();

            if (!service.IsCocktailInList(id))
                return NotFound();

            if (!service.RemoveFromPreferences(id))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete()
        {
            var service = CreatePreferenceService();

            if (!service.ClearList())
                return InternalServerError();

            return Ok();
        }
    }
}