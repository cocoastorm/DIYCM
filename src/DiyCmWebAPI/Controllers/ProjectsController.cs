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
    [Route("api/Projects")]
    [EnableCors("AllowAll")]
    public class ProjectsController : Controller
    {
        private DiyCmContext _context;

        public ProjectsController(DiyCmContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects;
        }

        // GET: api/Projects/5
        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult GetProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Project project = _context.Projects.Single(m => m.ProjectId == id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public IActionResult PutProject(int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != project.ProjectId)
            {
                return HttpBadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [HttpPost]
        public IActionResult PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Projects.Add(project);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProjectExists(project.ProjectId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProject", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Project project = _context.Projects.Single(m => m.ProjectId == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return Ok(project);
        }

        // GET: api/Homepage
        [HttpGet]
        [Route("api/Homepage")]
        public IEnumerable<Project> GetHomepage() {
            return _context.Projects;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Count(e => e.ProjectId == id) > 0;
        }
    }
}