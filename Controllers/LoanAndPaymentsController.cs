using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class LoanAndRepaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoanAndRepaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> listBooks = _context.Book;
            return View(listBooks);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(LoanAndRepayment loanAndRepayment)
        {
           
            
            if (ModelState.IsValid)
            {
                _context.LoanAndRepayment.Add(loanAndRepayment);
                _context.SaveChanges();

                TempData["message"] = "LoanAndRepayment was saved properly";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
