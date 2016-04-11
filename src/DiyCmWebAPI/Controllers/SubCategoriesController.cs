using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Authorization;

namespace DiyCmWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SubCategories")]
    [EnableCors("AllowAll")]
    [Authorize("Bearer")]
    public class SubCategoriesController : Controller
    {
        private DiyCmContext _context;

        public SubCategoriesController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet]
        public IEnumerable<SubCategory> GetSubCategories()
        {
            return _context.SubCategories;
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}", Name = "GetSubCategory")]
        public IActionResult GetSubCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            SubCategory subCategory = _context.SubCategories.Single(m => m.SubCategoryId == id);

            if (subCategory == null)
            {
                return HttpNotFound();
            }

            return Ok(subCategory);
        }

        // PUT: api/SubCategories/5
        [HttpPut("{id}")]
        public IActionResult PutSubCategory(int id, [FromBody] SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != subCategory.SubCategoryId)
            {
                return HttpBadRequest();
            }

            _context.Entry(subCategory).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST: api/SubCategories
        [HttpPost]
        public IActionResult PostSubCategory([FromBody] SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.SubCategories.Add(subCategory);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SubCategoryExists(subCategory.SubCategoryId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetSubCategory", new { id = subCategory.SubCategoryId }, subCategory);
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            SubCategory subCategory = _context.SubCategories.Single(m => m.SubCategoryId == id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }

            _context.SubCategories.Remove(subCategory);
            _context.SaveChanges();

            return Ok(subCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoryExists(int id)
        {
            return _context.SubCategories.Count(e => e.SubCategoryId == id) > 0;
        }
    }
}