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
    //Manges lending  records with authentication
    [Authorize]
    public class LendingRecordsController : Controller
    {
        private readonly Library_SystemDatabaseContext _context;

        public LendingRecordsController(Library_SystemDatabaseContext context)
        {
            _context = context;
        }


        //Gets all lending records using a lamda query.
        // GET: LendingRecords
        public IActionResult Index()
        {
            var library_SystemDatabaseContext = _context.LendingRecord.Include(l => l.Book).Include(l => l.Member);
            return View( library_SystemDatabaseContext.ToList());
        }

        //Get details using a lamda query.
        // GET: LendingRecords/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lendingRecord = _context.LendingRecord
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefault(m => m.Id == id);
            if (lendingRecord == null)
            {
                return NotFound();
            }

            return View(lendingRecord);
        }

        // GET: LendingRecords/Create

        //Gets the information for the lending record create form.
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "BookName");
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "MemberName");
            return View();
        }

        // POST: LendingRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates a lending record.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MemberId,BookId,ReturnByDate")] LendingRecord lendingRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lendingRecord);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lendingRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", lendingRecord.MemberId);
            return View(lendingRecord);
        }

        // GET: LendingRecords/Edit/5
        //Gets lending record for update using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lendingRecord = (from lending in _context.LendingRecord
                                 where lending.Id == id
                                 select lending).FirstOrDefault();
            if (lendingRecord == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "BookName", lendingRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "MemberName", lendingRecord.MemberId);
            return View(lendingRecord);
        }

        // POST: LendingRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates a lending record.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,MemberId,BookId,ReturnByDate")] LendingRecord lendingRecord)
        {
            if (id != lendingRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lendingRecord);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendingRecordExists(lendingRecord.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lendingRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", lendingRecord.MemberId);
            return View(lendingRecord);
        }

        // GET: LendingRecords/Delete/5
        //Gets lending record for deletion. uses a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lendingRecord =  _context.LendingRecord
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefault(m => m.Id == id);
            if (lendingRecord == null)
            {
                return NotFound();
            }

            return View(lendingRecord);
        }

        // POST: LendingRecords/Delete/5
        //Deletes a lending record.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var lendingRecord = (from lending in _context.LendingRecord
                                 where lending.Id == id
                                 select lending).FirstOrDefault();
            _context.LendingRecord.Remove(lendingRecord);
           _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks lending record using a lamda query.
        private bool LendingRecordExists(int id)
        {
            return _context.LendingRecord.Any(e => e.Id == id);
        }
    }
}
