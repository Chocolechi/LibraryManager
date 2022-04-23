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
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IAuthorRepository _repo;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public AuthorsController(IAuthorRepository repo)
        //{
        //    _repo = repo;
        //}

        public IActionResult Index()
        {
            //var list = _repo.GetAll();
            IEnumerable<Author> listAuthors = _context.Author;
            return View(listAuthors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                //_repo.Create(author);

                _context.Author.Add(author);
                _context.SaveChanges();

                TempData["message"] = "Book was saved properly";

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
            var item = _context.Author.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.Author.Update(author);
                _context.SaveChanges();

                TempData["message"] = "Book was updated properly";

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
            var item = _context.Author.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? Id)
        {
            //var item = _repo.Get(Id);
            var item = _context.Author.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.Author.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "Book was deleted properly";

            return RedirectToAction("Index");
        }
    }

}
