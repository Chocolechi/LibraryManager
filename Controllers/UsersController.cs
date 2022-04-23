using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IUserRepository _repo;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public UsersController(IUserRepository repo)
        //{
        //    _repo = repo;
        //}

        public IActionResult Index()
        {
            //var list = _repo.GetAll();
            IEnumerable<User> listUsers = _context.User
                .Include(t => t.TypePerson);
            return View(listUsers);
        }

        public IActionResult Create()
        {
            List<TypePerson> typePerson = _context.TypePerson.ToList();
            List<SelectListItem> typePeople = new List<SelectListItem>();

            foreach (var item in typePerson)
            {
                typePeople.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name }); ;
            }

            ViewBag.typePerson = typePeople;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            //user.TypePeople = 
            if (ModelState.IsValid)
            {
                //_repo.Create(language);

                _context.User.Add(user);
                _context.SaveChanges();

                TempData["message"] = "User was saved properly";

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
            var item = _context.User.Find(Id);


            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                //var item = _repo.Update(author);
                _context.User.Update(user);
                _context.SaveChanges();

                TempData["message"] = "user was updated properly";

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
            var item = _context.User.Find(Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int? Id)
        {
            //var item = _repo.Get(Id);
            var item = _context.User.Find(Id);
            if (item == null)
            {
                NotFound();
            }



            _context.User.Remove(item);
            _context.SaveChanges();

            TempData["message"] = "user was deleted properly";

            return RedirectToAction("Index");
        }
    }
}
