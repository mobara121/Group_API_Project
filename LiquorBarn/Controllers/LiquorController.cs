using LiquorBarn.Models;
using LiquorBarn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}