using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;

namespace DiyCmWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SupplierInvoiceDetails")]
    public class SupplierInvoiceDetailsController : Controller
    {
        private DiyCmContext _context;

        public SupplierInvoiceDetailsController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/SupplierInvoiceDetails
        [HttpGet]
        public IEnumerable<SupplierInvoiceDetail> GetSupplierInvoiceDetails()
        {
            return _context.SupplierInvoiceDetails;
        }

        // GET: api/SupplierInvoiceDetails/5
        [HttpGet("{id}", Name = "GetSupplierInvoiceDetail")]
        public IActionResult GetSupplierInvoiceDetail([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            SupplierInvoiceDetail supplierInvoiceDetail = _context.SupplierInvoiceDetails.Single(m => m.InvoiceId == id);

            if (supplierInvoiceDetail == null)
            {
                return HttpNotFound();
            }

            return Ok(supplierInvoiceDetail);
        }

        // PUT: api/SupplierInvoiceDetails/5
        [HttpPut("{id}")]
        public IActionResult PutSupplierInvoiceDetail(string id, [FromBody] SupplierInvoiceDetail supplierInvoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != supplierInvoiceDetail.InvoiceId)
            {
                return HttpBadRequest();
            }

            _context.Entry(supplierInvoiceDetail).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierInvoiceDetailExists(id))
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

        // POST: api/SupplierInvoiceDetails
        [HttpPost]
        public IActionResult PostSupplierInvoiceDetail([FromBody] SupplierInvoiceDetail supplierInvoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.SupplierInvoiceDetails.Add(supplierInvoiceDetail);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SupplierInvoiceDetailExists(supplierInvoiceDetail.InvoiceId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetSupplierInvoiceDetail", new { id = supplierInvoiceDetail.InvoiceId }, supplierInvoiceDetail);
        }

        // DELETE: api/SupplierInvoiceDetails/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplierInvoiceDetail(string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            SupplierInvoiceDetail supplierInvoiceDetail = _context.SupplierInvoiceDetails.Single(m => m.InvoiceId == id);
            if (supplierInvoiceDetail == null)
            {
                return HttpNotFound();
            }

            _context.SupplierInvoiceDetails.Remove(supplierInvoiceDetail);
            _context.SaveChanges();

            return Ok(supplierInvoiceDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierInvoiceDetailExists(string id)
        {
            return _context.SupplierInvoiceDetails.Count(e => e.InvoiceId == id) > 0;
        }
    }
}