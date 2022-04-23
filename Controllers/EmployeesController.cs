using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryManager.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IEmployeeRepository _repo;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public EmployeesController(IEmployeeRepository repo)
        //{
        //    _repo = repo;
        //}

        public IActionResult Index()
        {
            //var list = _repo.GetAll();
            IEnumerable<Employee> listEmployees = _context.Employee;
            return View(listEmployees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //_repo.Create(language);

                _context.Employee.Add(employee);
                _context.SaveChanges();

                TempData["message"] = "Employee was saved properly";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            //var item = _repo.Get(Id);
            var item = _context.Employee.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.Employee.Update(employee);
                _context.SaveChanges();

                TempData["message"] = "employee was updated properly";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //var item = _repo.Get(Id);
            var item = _context.Employee.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(int? Id)
        {
            //var item = _repo.Get(Id);
            var item = _context.Employee.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.Employee.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "employee was deleted properly";

            return RedirectToAction("Index");
        }
    }
}
