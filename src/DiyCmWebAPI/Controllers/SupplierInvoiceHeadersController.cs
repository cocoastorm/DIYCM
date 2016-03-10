using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;
using Microsoft.AspNet.Cors;

namespace DiyCmWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SupplierInvoiceHeaders")]
    [EnableCors("AllowAll")]
    public class SupplierInvoiceHeadersController : Controller
    {
        private DiyCmContext _context;

        public SupplierInvoiceHeadersController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/SupplierInvoiceHeaders
        [HttpGet]
        public IEnumerable<SupplierInvoiceHeader> GetSupplierInvoiceHeaders()
        {
            return _context.SupplierInvoiceHeaders;
        }

        // GET: api/SupplierInvoiceHeaders/5
        [HttpGet("{id}", Name = "GetSupplierInvoiceHeader")]
        public IActionResult GetSupplierInvoiceHeader([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            SupplierInvoiceHeader supplierInvoiceHeader = _context.SupplierInvoiceHeaders.Single(m => m.QuoteHeaderId == id);

            if (supplierInvoiceHeader == null)
            {
                return HttpNotFound();
            }

            return Ok(supplierInvoiceHeader);
        }

        // PUT: api/SupplierInvoiceHeaders/5
        [HttpPut("{id}")]
        public IActionResult PutSupplierInvoiceHeader(int id, [FromBody] SupplierInvoiceHeader supplierInvoiceHeader)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != supplierInvoiceHeader.QuoteHeaderId)
            {
                return HttpBadRequest();
            }

            _context.Entry(supplierInvoiceHeader).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierInvoiceHeaderExists(id))
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

        // POST: api/SupplierInvoiceHeaders
        [HttpPost]
        public IActionResult PostSupplierInvoiceHeader([FromBody] SupplierInvoiceHeader supplierInvoiceHeader)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.SupplierInvoiceHeaders.Add(supplierInvoiceHeader);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SupplierInvoiceHeaderExists(supplierInvoiceHeader.QuoteHeaderId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetSupplierInvoiceHeader", new { id = supplierInvoiceHeader.QuoteHeaderId }, supplierInvoiceHeader);
        }

        // DELETE: api/SupplierInvoiceHeaders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplierInvoiceHeader(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            SupplierInvoiceHeader supplierInvoiceHeader = _context.SupplierInvoiceHeaders.Single(m => m.QuoteHeaderId == id);
            if (supplierInvoiceHeader == null)
            {
                return HttpNotFound();
            }

            _context.SupplierInvoiceHeaders.Remove(supplierInvoiceHeader);
            _context.SaveChanges();

            return Ok(supplierInvoiceHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierInvoiceHeaderExists(int id)
        {
            return _context.SupplierInvoiceHeaders.Count(e => e.QuoteHeaderId == id) > 0;
        }
    }
}