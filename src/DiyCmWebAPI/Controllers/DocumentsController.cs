using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;

namespace DiyCmWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Documents")]
    public class DocumentsController : Controller
    {
        private DiyCmContext _context;

        public DocumentsController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/Documents
        [HttpGet]
        public IEnumerable<Document> GetDocuments()
        {
            return _context.Documents;
        }

        // GET: api/Documents/5
        [HttpGet("{id}", Name = "GetDocument")]
        public IActionResult GetDocument([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Document document = _context.Documents.Single(m => m.DocumentId == id);

            if (document == null)
            {
                return HttpNotFound();
            }

            return Ok(document);
        }

        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public IActionResult PutDocument(int id, [FromBody] Document document)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != document.DocumentId)
            {
                return HttpBadRequest();
            }

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        [HttpPost]
        public IActionResult PostDocument([FromBody] Document document)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Documents.Add(document);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DocumentExists(document.DocumentId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetDocument", new { id = document.DocumentId }, document);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Document document = _context.Documents.Single(m => m.DocumentId == id);
            if (document == null)
            {
                return HttpNotFound();
            }

            _context.Documents.Remove(document);
            _context.SaveChanges();

            return Ok(document);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Count(e => e.DocumentId == id) > 0;
        }
    }
}