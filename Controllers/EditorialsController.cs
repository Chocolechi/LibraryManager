using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class EditorialsController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IEditorialRepository _repo;

        public EditorialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public EditorialsController(IEditorialRepository repo)
        //{
        //    _repo = repo;
        //}

        public IActionResult Index()
        {
            //var list = _repo.GetAll();
            IEnumerable<Editorial> listEditorials = _context.Editorial;
            return View(listEditorials);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                //_repo.Create(author);

                _context.Editorial.Add(editorial);
                _context.SaveChanges();

                TempData["message"] = "Editorial was saved properly";

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
            var item = _context.Editorial.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.Editorial.Update(editorial);
                _context.SaveChanges();

                TempData["message"] = "editorial was updated properly";

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
            var item = _context.Editorial.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEditorial(int? Id)
        {
            //var item = _repo.Get(Id);
            var item = _context.Editorial.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.Editorial.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "editorial was deleted properly";

            return RedirectToAction("Index");
        }
    }

}
