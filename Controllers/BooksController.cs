using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> listBooks = _context.Book
                .Include(b => b.Science)
                .Include(b => b.Language)
                .Include(b => b.Author)
                .Include(b => b.Bibliography)
                .Include(b => b.Editorial);
            return View(listBooks);
        }

        public IActionResult Create()
        {
            List<Author> author = _context.Author.ToList();
            List<SelectListItem> authors = new List<SelectListItem>();
            foreach (var item in author)
            {
                authors.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name }); ;
            }

            List<Editorial> editorial = _context.Editorial.ToList();
            List<SelectListItem> editorials = new List<SelectListItem>();
            foreach (var item in editorial)
            {
                editorials.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name }); ;
            }

            List<Science> science = _context.Science.ToList();
            List<SelectListItem> sciences = new List<SelectListItem>();
            foreach (var item in science)
            {
                sciences.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name }); ;
            }

            List<Language> language = _context.Language.ToList();
            List<SelectListItem> languages = new List<SelectListItem>();
            foreach (var item in language)
            {
                languages.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name }); ;
            }
            
            List<Bibliography> bibliography = _context.Bibliography.ToList();
            List<SelectListItem> bibliographies = new List<SelectListItem>();
            foreach (var item in bibliography)
            {
                bibliographies.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name }); ;
            }

            ViewBag.author = authors;
            ViewBag.editorial = editorials;
            ViewBag.science = sciences;
            ViewBag.language = languages;
            ViewBag.bibliography = bibliographies;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
           
            
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
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
            var item = _context.Book.Find(Id);


            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.Book.Update(book);
                _context.SaveChanges();

                TempData["message"] = "book was updated properly";

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
            var item = _context.Book.Find(Id);

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
            var item = _context.Book.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.Book.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "book was deleted properly";

            return RedirectToAction("Index");
        }
    }
}

