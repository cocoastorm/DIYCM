using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;

namespace DiyCmWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/QuoteDetails")]
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