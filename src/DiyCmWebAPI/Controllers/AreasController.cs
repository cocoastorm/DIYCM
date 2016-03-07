using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;

namespace DiyCmWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Areas")]
    public class AreasController : Controller
    {
        private DiyCmContext _context;

        public AreasController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/Areas
        [HttpGet]
        public IEnumerable<Area> GetAreas()
        {
            return _context.Areas;
        }

        // GET: api/Areas/5
        [HttpGet("{id}", Name = "GetArea")]
        public IActionResult GetArea([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Area area = _context.Areas.Single(m => m.AreaId == id);

            if (area == null)
            {
                return HttpNotFound();
            }

            return Ok(area);
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public IActionResult PutArea(int id, [FromBody] Area area)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != area.AreaId)
            {
                return HttpBadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Areas
        [HttpPost]
        public IActionResult PostArea([FromBody] Area area)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Areas.Add(area);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AreaExists(area.AreaId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetArea", new { id = area.AreaId }, area);
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteArea(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Area area = _context.Areas.Single(m => m.AreaId == id);
            if (area == null)
            {
                return HttpNotFound();
            }

            _context.Areas.Remove(area);
            _context.SaveChanges();

            return Ok(area);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AreaExists(int id)
        {
            return _context.Areas.Count(e => e.AreaId == id) > 0;
        }
    }
}