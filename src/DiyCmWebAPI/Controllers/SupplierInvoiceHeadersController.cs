using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;
using Microsoft.AspNet.Cors;
using System;

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
            /*   
               var listOfQuotes = _context.QuoteHeaders;
               foreach(QuoteHeader quote in listOfQuotes)
               {
                   if(quote.IsAccept != null) // check if yes or no but seeded database is wrong, delete
                   {
                       SupplierInvoiceHeader invoiceHeader = getInvoiceHeader(quote);
                       var listOfValidInvoiceDetails = getInvoiceDetail(quote, invoiceHeader);

                       _context.SupplierInvoiceHeaders.Add(invoiceHeader);
                       foreach (SupplierInvoiceDetail invoiceDetail in listOfValidInvoiceDetails)
                       {
                           _context.SupplierInvoiceDetails.Add(invoiceDetail);
                       }
                       try
                       {
                           _context.SaveChanges();
                       }
                       catch (DbUpdateException)
                       {
                           if (SupplierInvoiceHeaderExists(invoiceHeader.QuoteHeaderId))
                           {
                               //return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                           }
                           else
                           {
                               throw;
                           }
                       }

                   }
               }

               */


            //return _context.SupplierInvoiceHeaders;
            return _context.SupplierInvoiceHeaders;
        }

        public SupplierInvoiceHeader getInvoiceHeader(QuoteHeader quote)
        {
            var curDay = DateTime.Now.ToString("M/d/yyyy");
            DateTime startDate = DateTime.Parse(curDay);
            DateTime expiryDate = startDate.AddDays(30);
            SupplierInvoiceHeader invoiceHeader = new SupplierInvoiceHeader()
            {
                InvoiceId = quote.QuoteHeaderId,
                SupplierName = quote.Supplier,
                QuoteHeaderId = quote.QuoteHeaderId,
                Date = quote.Date,
                ContactName = quote.ContactName,
                PhoneNumber = quote.PhoneNumber,
                ReferredBy = quote.ReferredBy,
                AddressCity = quote.AddressCity,
                AddressStreet = quote.AddressStreet,
                AddressCountry = quote.AddressCountry,
                AddressPostalCode = quote.AddressPostalCode,
                AddressProvince = quote.AddressProvince,
                AmountPaid = 'N',
                PaymentDate = expiryDate,
                SH_AMOUNT_PAID = 0,
                SH_AMOUNT = getTotalQuote(quote.QuoteHeaderId)
            };
            return invoiceHeader;
        }

        public List<SupplierInvoiceDetail> getInvoiceDetail(QuoteHeader quote, SupplierInvoiceHeader invoiceHeader)
        {
            var listOfQuoteDetails = _context.QuoteDetails;
            var lineNumber = 0;
            List<SupplierInvoiceDetail> validInvoiceDetail = new List<SupplierInvoiceDetail>();

            foreach (QuoteDetail quoteDetail in listOfQuoteDetails)
            {
                if (quoteDetail.QuoteHeaderId == quote.QuoteHeaderId)
                {
                    SupplierInvoiceDetail invoiceDetail = new SupplierInvoiceDetail()
                    {
                        InvoiceId = quote.QuoteHeaderId.ToString(),
                        SupplierInvoiceHeader = invoiceHeader,
                        LineNumber = lineNumber,
                        PartNumber = quoteDetail.PartId,
                        PartDescription = quoteDetail.PartDescription,
                        Area = quoteDetail.Area,
                        AreaId = quoteDetail.AreaId,
                        Category = quoteDetail.Category,
                        CategoryId = quoteDetail.CategoryId,
                        Notes = quoteDetail.Notes,
                        SubCategory = quoteDetail.SubCategory,
                        SubCategoryId = quoteDetail.SubCategoryId,
                        UnitPrice = quoteDetail.UnitPrice
                    };
                    lineNumber++;
                    validInvoiceDetail.Add(invoiceDetail);
                }
            }

            return validInvoiceDetail;
        }

        public decimal getTotalQuote(int quoteHeaderId)
        {
            var listOfQuoteDetails = _context.QuoteDetails;
            decimal total = 0;
            foreach(QuoteDetail quoteDetail in listOfQuoteDetails)
            {
                if(quoteDetail.QuoteHeaderId == quoteHeaderId)
                    total += (quoteDetail.UnitPrice);
            }
            return total;
        }

        [Route("update")]
        // GET: api/SupplierInvoiceHeaders/update
        public string update(string id)
        {
            var listOfQuotes = _context.QuoteHeaders;
            DateTime localDate = DateTime.Now;
            foreach (QuoteHeader quote in listOfQuotes)
            {
                if ((quote.IsAccept == 'Y' || quote.IsAccept == 'y') && localDate >= quote.ExpiryDate) // check if yes or no but seeded database is wrong, delete
                {
                    SupplierInvoiceHeader invoiceHeader = getInvoiceHeader(quote);
                    var listOfValidInvoiceDetails = getInvoiceDetail(quote, invoiceHeader);

                    _context.SupplierInvoiceHeaders.Add(invoiceHeader);
                    foreach (SupplierInvoiceDetail invoiceDetail in listOfValidInvoiceDetails)
                    {
                        _context.SupplierInvoiceDetails.Add(invoiceDetail);
                    }
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        if (SupplierInvoiceHeaderExists(invoiceHeader.QuoteHeaderId))
                        {
                            return "ERROR: EXIST";
                            //return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                        }
                        else
                        {
                            throw;
                        }
                    }

                }
            }
            return "Updated";
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