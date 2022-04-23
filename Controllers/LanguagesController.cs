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
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ILanguageRepository _repo;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public LanguagesController(ILanguageRepository repo)
        //{
        //    _repo = repo;
        //}

        public IActionResult Index()
        {
            //var list = _repo.GetAll();
            IEnumerable<Language> listLanguages = _context.Language;
            return View(listLanguages);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Language language)
        {
            if (ModelState.IsValid)
            {
                //_repo.Create(author);

                _context.Language.Add(language);
                _context.SaveChanges();

                TempData["message"] = "Language was saved properly";

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
            var item = _context.Language.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Language language)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.Language.Update(language);
                _context.SaveChanges();

                TempData["message"] = "language was updated properly";

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
            var item = _context.Language.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLanguage(int? Id)
        {
            //var item = _repo.Get(Id);
            var item = _context.Language.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.Language.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "language was deleted properly";

            return RedirectToAction("Index");
        }
    }

}
