using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Models;
using EmployeeService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository repository;
        public EmployeesController(IEmployeeRepository _repository)
        {
            this.repository = _repository;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return repository.Get();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<Employee> Post([FromForm] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isAdded = repository.Add(emp);
                    if (isAdded)
                    {
                        return Created("employees", emp);
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

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromForm] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == employee.Id)
                    {
                        var existing = repository.Get(id);
                        if (existing == null)
                        {
                            return NotFound("Employye does not exist");
                        }
                        var isUpdated = repository.Update(employee);
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

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    return Ok("Employee deleted successfully");
                }
                else
                {
                    return NotFound("Employee does not exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("gender/{gender}")]
        // GET: api/employees/gender/
        public ActionResult<IEnumerable<Employee>> ByGender(Gender gender)
        {
            try
            {
                return Ok(repository.GetByGender(gender));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("search")]
        public string Search(string p1, string p2)
        {
            return "search result";
        }


    }
}
