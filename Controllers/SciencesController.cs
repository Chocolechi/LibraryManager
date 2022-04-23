using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryManager.Controllers
{
    public class SciencesController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IScienceRepository _repo;

        public SciencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public SciencesController(IScienceRepository repo)
        //{
        //    _repo = repo;
        //}

        public IActionResult Index()
        {
            //var list = _repo.GetAll();
            IEnumerable<Science> listSciences = _context.Science;
            return View(listSciences);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Science science)
        {
            if (ModelState.IsValid)
            {
                //_repo.Create(language);

                _context.Science.Add(science);
                _context.SaveChanges();

                TempData["message"] = "Science was saved properly";

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
            var item = _context.Science.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Science science)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.Science.Update(science);
                _context.SaveChanges();

                TempData["message"] = "science was updated properly";

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
            var item = _context.Science.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteScience(int? Id)
        {
            //var item = _repo.Get(Id);
            var item = _context.Science.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.Science.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "science was deleted properly";

            return RedirectToAction("Index");
        }
    }
}
