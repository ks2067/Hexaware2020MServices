using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Models;
using ProjectService.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectRepository repository;
        public ProjectController(IProjectRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return repository.Get();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public ActionResult<Project> Post([FromForm] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isAdded = repository.Add(project);
                    if (isAdded)
                    {
                        return Created("Project", project);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public ActionResult<Project> Put(int id, [FromForm] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == project.Id)
                    {
                        var existing = repository.Get(id);
                        if (existing == null)
                        {
                            return NotFound("Project does not exist");
                        }
                        var isUpdated = repository.Update(project);
                        if (isUpdated)
                        {
                            return Ok("Updated scuccessfully");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError);
                        }
                    }
                    else
                    {
                        return BadRequest("id do not match");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    return Ok("Project deleted successfully");
                }
                else
                {
                    return NotFound("Project does not exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
