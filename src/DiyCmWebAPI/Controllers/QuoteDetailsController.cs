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
    [Route("api/QuoteDetails")]
    [EnableCors("AllowAll")]
    [Authorize("Bearer")]
    public class QuoteDetailsController : Controller
    {
        private DiyCmContext _context;

        public QuoteDetailsController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/QuoteDetails
        [HttpGet]
        public IEnumerable<QuoteDetail> GetQuoteDetails()
        {
            return _context.QuoteDetails;
        }

        // GET: api/QuoteDetails/5
        [HttpGet("{id}", Name = "GetQuoteDetail")]
        public IActionResult GetQuoteDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            QuoteDetail quoteDetail = _context.QuoteDetails.Single(m => m.QuoteDetailId == id);

            if (quoteDetail == null)
            {
                return HttpNotFound();
            }

            return Ok(quoteDetail);
        }

        // PUT: api/QuoteDetails/5
        [HttpPut("{id}")]
        public IActionResult PutQuoteDetail(int id, [FromBody] QuoteDetail quoteDetail)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != quoteDetail.QuoteDetailId)
            {
                return HttpBadRequest();
            }

            // Get the old price so we can check the difference and update accordingly.
            decimal oldPrice = _context.QuoteDetails.Where(q => q.QuoteDetailId == id).FirstOrDefault().UnitPrice;
            decimal deltaPrice = quoteDetail.UnitPrice - oldPrice;

            var subCategory = _context.SubCategories.Where(s => s.SubCategoryId == quoteDetail.SubCategoryId).FirstOrDefault();
            // Update the budget
            subCategory.BudgetAmount += deltaPrice;
            // Update the variance amount
            var oldVariance = subCategory.VarianceAmount;
            subCategory.VarianceAmount = subCategory.ActualAmount - subCategory.BudgetAmount;
            var deltaVariance = subCategory.VarianceAmount - oldVariance;
            // Update the main category
            var category = _context.Categories.Where(c => c.CategoryId == subCategory.CategoryId).FirstOrDefault();
            category.BudgetAmount += deltaPrice;
            category.VarianceAmount += deltaVariance;

            _context.Entry(quoteDetail).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteDetailExists(id))
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

        // POST: api/QuoteDetails
        [HttpPost]
        public IActionResult PostQuoteDetail([FromBody] QuoteDetail quoteDetail)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.QuoteDetails.Add(quoteDetail);
            // Update the subcategory budget
            var subCategory = _context.SubCategories.Where(s => s.SubCategoryId == quoteDetail.SubCategoryId).FirstOrDefault();
            subCategory.BudgetAmount += quoteDetail.UnitPrice;
            // Calculate variance amount
            var oldVariance = subCategory.VarianceAmount;
            subCategory.VarianceAmount = subCategory.ActualAmount - subCategory.BudgetAmount;
            var deltaVariance = subCategory.VarianceAmount - oldVariance;
            // Update the main category
            var category = _context.Categories.Where(c => c.CategoryId == subCategory.CategoryId).FirstOrDefault();
            category.BudgetAmount += quoteDetail.UnitPrice;
            category.VarianceAmount += deltaVariance;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuoteDetailExists(quoteDetail.QuoteDetailId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetQuoteDetail", new { id = quoteDetail.QuoteDetailId }, quoteDetail);
        }

        // DELETE: api/QuoteDetails/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQuoteDetail(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            QuoteDetail quoteDetail = _context.QuoteDetails.Single(m => m.QuoteDetailId == id);
            if (quoteDetail == null)
            {
                return HttpNotFound();
            }

            // Update the subcategory budget
            var subCategory = _context.SubCategories.Where(s => s.SubCategoryId == quoteDetail.SubCategoryId).FirstOrDefault();
            subCategory.BudgetAmount -= quoteDetail.UnitPrice;
            // Calculate variance amount
            var oldVariance = subCategory.VarianceAmount;
            subCategory.VarianceAmount = subCategory.ActualAmount - subCategory.BudgetAmount;
            var deltaVariance = subCategory.VarianceAmount - oldVariance;
            // Update the main category
            var category = _context.Categories.Where(c => c.CategoryId == subCategory.CategoryId).FirstOrDefault();
            category.BudgetAmount -= quoteDetail.UnitPrice;
            category.VarianceAmount += deltaVariance;

            _context.QuoteDetails.Remove(quoteDetail);
            _context.SaveChanges();

            return Ok(quoteDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteDetailExists(int id)
        {
            return _context.QuoteDetails.Count(e => e.QuoteDetailId == id) > 0;
        }
    }
}