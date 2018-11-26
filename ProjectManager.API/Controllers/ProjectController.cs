using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Business;
using ProjectManager.Entities;
using System.Collections.Generic;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectBL _projectBL;

        public ProjectController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }

        // GET: api/Project
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _projectBL.GetProjects();
        }

        // GET: api/Project/GetById
        [HttpGet]
        [Route("GetById")]
        public Project GetById(int id)
        {
            return _projectBL.GetProjectById(id);
        }

        // GET: api/Project/Search
        [HttpGet]
        [Route("Search")]
        public IEnumerable<Project> Search(string searchText)
        {
            return _projectBL.SearchProjects(searchText);
        }

        // POST: api/Project
        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                _projectBL.AddProject(project);
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Project/5
        [HttpPut]
        public IActionResult Put([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                _projectBL.UpdateProject(project);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/Project/5
        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _projectBL.DeleteProject(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
