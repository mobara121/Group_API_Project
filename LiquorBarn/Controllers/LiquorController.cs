using LiquorBarn.Models;
using LiquorBarn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace LiquorBarn.Controllers
{
    public class LiquorController : ApiController
    {
        private readonly LiquorService _service = new LiquorService();

        [HttpPost]
        public IHttpActionResult Post(LiquorCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.IsLiquorInDatabase(model))
                return Conflict();

            if (!_service.AddLiquor(model))
                return InternalServerError();

            return Ok();
        }
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var liquors = _service.GetAllLiquor();
            return Ok(liquors);
        }

        [HttpGet]
        public IHttpActionResult GetLiquorByID(int id)
        {
            var result = _service.GetLiquorByID(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IHttpActionResult UpdateLiquor([FromUri]int id, [FromBody]LiquorCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_service.GetLiquorByID(id) is null)
                return NotFound();

            if (_service.ChangesWereNotMade(id, model))
                return Ok("No changes were made.");

            if (_service.IsLiquorInDatabase(model))
                return Conflict();

            if (!_service.UpdateLiquor(id, model))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (_service.GetLiquorByID(id) is null)
                return NotFound();

            if (_service.IsLiquorInAnyCocktails(id))
                return Content<string>(HttpStatusCode.Forbidden, "WARNING: This liquor is currently being used in cocktails. Delete or edit those cocktails first if you want to proceed.");

            if (!_service.DeleteLiquor(id))
                return InternalServerError();

            return Ok();
        }
    }
}