using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DiyCmDataModel.Construction;

namespace DiyCmWebAPI.Controllers
{
        [Route("api/[controller]")]
        public class DocumentsController : Controller
        {
            private DiyCmContext _context { get; set; }

            public DocumentsController(DiyCmContext context)
            {
                _context = context;
            }

            // GET: api/student
            [HttpGet]
            public IEnumerable<Document> Get()
            {
                return _context.Documents.ToList();
            }

            // GET api/student/5
            [HttpGet("{id}")]
            public Document Get(int id)
            {
                return _context.Documents.FirstOrDefault(s => s.DocumentId == id);
            }

            // POST api/student
            [HttpPost]
            public void Post([FromBody]Document document)
            {
                _context.Documents.Add(document);
                _context.SaveChanges();
            }

            // PUT api/student/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody]Document document)
            {
                _context.Documents.Update(document);
                _context.SaveChanges();
            }

            // DELETE api/student/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var student = _context.Documents.FirstOrDefault(t => t.DocumentId == id);
                if (student != null)
                {
                    _context.Documents.Remove(student);
                    _context.SaveChanges();
                }
            }
        }
}
