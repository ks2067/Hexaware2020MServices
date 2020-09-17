using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmsMvc.Models;
using EmsMvc.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmsMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private IRepository<Employee> repository;

        public EmployeesController(IRepository<Employee> repository)
        {
            this.repository = repository;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            return View(repository.Get());
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                //server side validation
                // model is valid
                if (ModelState.IsValid)
                {
                    var isAdded = repository.Add(employee);
                    if (isAdded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            //check if employee exist
            var employee = repository.Get(id);
            // does not exist
            if (employee == null)
            {
                //redirect Index
                return RedirectToAction(nameof(Index));
            }
            //emp exists
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //man in the middle attack
                    if (id == employee.Id)
                    {
                        var existingEmp = repository.Get(id);
                        // does not exist
                        if (existingEmp == null)
                        {
                            return NotFound("Employee not found");
                        }
                        var isUpdated = repository.Update(employee);
                        if (isUpdated)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                //check if emp exists
                //modelstate? SSV
                // repository.update()
                //if success
                
                // esle
                // remain on same view
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            //check if employee exist
            var employee = repository.Get(id);
            // does not exist
            if (employee == null)
            {
                //redirect Index
                return NotFound("Employee not found");
            }
            //emp exists
            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
