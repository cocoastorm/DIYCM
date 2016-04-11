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
    [Route("api/QuoteHeaders")]
    [EnableCors("AllowAll")]
    [Authorize("Bearer")]
    public class QuoteHeadersController : Controller
    {
        private DiyCmContext _context;

        public QuoteHeadersController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/QuoteHeaders
        [HttpGet]
        public IEnumerable<QuoteHeader> GetQuoteHeaders()
        {
            return _context.QuoteHeaders;
        }

        // GET: api/QuoteHeaders/5
        [HttpGet("{id}", Name = "GetQuoteHeader")]
        public IActionResult GetQuoteHeader([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            QuoteHeader quoteHeader = _context.QuoteHeaders.Single(m => m.QuoteHeaderId == id);

            if (quoteHeader == null)
            {
                return HttpNotFound();
            }

            return Ok(quoteHeader);
        }

        // PUT: api/QuoteHeaders/5
        [HttpPut("{id}")]
        public IActionResult PutQuoteHeader(int id, [FromBody] QuoteHeader quoteHeader)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != quoteHeader.QuoteHeaderId)
            {
                return HttpBadRequest();
            }

            _context.Entry(quoteHeader).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteHeaderExists(id))
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

        // POST: api/QuoteHeaders
        [HttpPost]
        public IActionResult PostQuoteHeader([FromBody] QuoteHeader quoteHeader)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.QuoteHeaders.Add(quoteHeader);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuoteHeaderExists(quoteHeader.QuoteHeaderId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetQuoteHeader", new { id = quoteHeader.QuoteHeaderId }, quoteHeader);
        }

        // DELETE: api/QuoteHeaders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQuoteHeader(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            QuoteHeader quoteHeader = _context.QuoteHeaders.Single(m => m.QuoteHeaderId == id);
            if (quoteHeader == null)
            {
                return HttpNotFound();
            }

            _context.QuoteHeaders.Remove(quoteHeader);
            _context.SaveChanges();

            return Ok(quoteHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteHeaderExists(int id)
        {
            return _context.QuoteHeaders.Count(e => e.QuoteHeaderId == id) > 0;
        }
    }
}