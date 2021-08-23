using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_System.Models;
using Microsoft.AspNetCore.Authorization;

namespace Library_System.Controllers
{
    //Manages books with authentication.
  
    [Authorize]
    public class BooksController : Controller
    {
        private readonly Library_SystemDatabaseContext _context;

        public BooksController(Library_SystemDatabaseContext context)
        {
            _context = context;
        }

        // GET: Books
        //Gets all books using a linq query
        public IActionResult Index()
        {
            return View((from book in _context.Book  select book).ToList());
        }

        // GET: Books/Details/5

         //Gets the book details using a lamda query
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  _context.Book
                .FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create

        //Gets the information for the create books form.
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(Enum.GetValues(typeof(BookCategory)));
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates a book record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,BookName,Category")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        //Gets  a book for  update  using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = (from books in _context.Book
                        where books.Id == id
                        select books).FirstOrDefault();

            ViewData["Categories"] = new SelectList(Enum.GetValues(typeof(BookCategory)), book.Category);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates a book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,BookName,Category")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        //Gets a book for deleton using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Book
                .FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //Deletes a book uses a linq query to get the book.
        public IActionResult DeleteConfirmed(int id)
        {
            var book = (from books in _context.Book
                        where books.Id == id
                        select books).FirstOrDefault();
            _context.Book.Remove(book);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Check book exists using lamda.
        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
