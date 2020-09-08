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
    }
}