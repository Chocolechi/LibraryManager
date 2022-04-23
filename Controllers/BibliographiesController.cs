using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryManager.Controllers
{
    public class BibliographiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IBibliographyRepository _repo;

        public BibliographiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public BibliographysController(IBibliographyRepository repo)
        //{
        //    _repo = repo;
        //}

        public IActionResult Index()
        {
            //var list = _repo.GetAll();
            IEnumerable<Bibliography> listBibliographys = _context.Bibliography;
            return View(listBibliographys);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bibliography bibliography)
        {
            if (ModelState.IsValid)
            {
                //_repo.Create(language);

                _context.Bibliography.Add(bibliography);
                _context.SaveChanges();

                TempData["message"] = "Bibliography was saved properly";

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
            var item = _context.Bibliography.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bibliography bibliography)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.Bibliography.Update(bibliography);
                _context.SaveChanges();

                TempData["message"] = "bibliography was updated properly";

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
            var item = _context.Bibliography.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBibliography(int? Id)
        {
            //var item = _repo.Get(Id);
            var item = _context.Bibliography.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.Bibliography.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "bibliography was deleted properly";

            return RedirectToAction("Index");
        }
    }
}
