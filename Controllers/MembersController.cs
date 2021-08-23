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
    //Manages members with authentication.
    [Authorize]
    public class MembersController : Controller
    {
        private readonly Library_SystemDatabaseContext _context;

        public MembersController(Library_SystemDatabaseContext context)
        {
            _context = context;
        }

        // GET: Members
        //Gets all members using a linq query.
        public IActionResult Index()
        {
            return View((from members in _context.Member select members).ToList());
        }

        // GET: Members/Details/5
        //Gets member details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _context.Member
                .FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        //Gets the member create form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //Creates the member.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MemberName,ContactNumber")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        //Gets member for update. using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = (from members in _context.Member
                          where members.Id == id
                          select members).FirstOrDefault();
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //Updates a member.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,MemberName,ContactNumber")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        //Gets a member for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member =  _context.Member
                .FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        //Deletes the member uses a linq query to get the member.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var member = (from members in _context.Member
                          where members.Id == id
                          select members).FirstOrDefault();
            _context.Member.Remove(member);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the member using lamda.
        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.Id == id);
        }
    }
}
