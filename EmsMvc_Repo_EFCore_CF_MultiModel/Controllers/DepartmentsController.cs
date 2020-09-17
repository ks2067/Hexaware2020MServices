using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmsMvc_Repo_EFCore_CF_MultiModel.Models;
using EmsMvc_Repo_EFCore_CF_MultiModel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmsMvc_Repo_EFCore_CF_MultiModel.Controllers
{
    public class DepartmentsController : Controller
    {
        private IRepository<Department> repository;
        public DepartmentsController(IRepository<Department> repository)
        {
            this.repository = repository;
        }
        // GET: DepartmentsController
        public ActionResult Index()
        {
            return View(repository.Get());

        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isAdded = repository.Add(department);
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

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
