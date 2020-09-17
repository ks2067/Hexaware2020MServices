using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentService.Models;
using DepartmentService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepartmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentRepository repository;
        public DepartmentsController(IDepartmentRepository _deptRepository)
        {
            this.repository = _deptRepository;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return repository.Get();
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public ActionResult<Department> Post([FromForm] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isAdded = repository.Add(department);
                    if (isAdded)
                    {
                        return Created("Department", department);
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

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Department> Put(int id, [FromForm] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == department.Id)
                    {
                        var existing = repository.Get(id);
                        if (existing == null)
                        {
                            return NotFound("Department does not exist");
                        }
                        var isUpdated = repository.Update(department);
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

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    return Ok("Department deleted successfully");
                }
                else
                {
                    return NotFound("Department does not exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
