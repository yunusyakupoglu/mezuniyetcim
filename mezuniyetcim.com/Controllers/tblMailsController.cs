using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mezuniyetcim.com.Data;
using mezuniyetcim.com.Entities;
using Microsoft.AspNetCore.Authorization;

namespace mezuniyetcim.com.Controllers
{
    [Authorize]
    public class tblMailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblMailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblMails
        public async Task<IActionResult> Index()
        {
            return View(await _context.mails.ToListAsync());
        }

        // GET: tblMails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMail = await _context.mails
                .FirstOrDefaultAsync(m => m.mailId == id);
            if (tblMail == null)
            {
                return NotFound();
            }

            return View(tblMail);
        }

        // GET: tblMails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblMails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mailId,mail")] tblMail tblMail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMail);
        }

        // GET: tblMails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMail = await _context.mails.FindAsync(id);
            if (tblMail == null)
            {
                return NotFound();
            }
            return View(tblMail);
        }

        // POST: tblMails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mailId,mail")] tblMail tblMail)
        {
            if (id != tblMail.mailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblMailExists(tblMail.mailId))
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
            return View(tblMail);
        }

        // GET: tblMails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMail = await _context.mails
                .FirstOrDefaultAsync(m => m.mailId == id);
            if (tblMail == null)
            {
                return NotFound();
            }

            return View(tblMail);
        }

        // POST: tblMails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMail = await _context.mails.FindAsync(id);
            _context.mails.Remove(tblMail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblMailExists(int id)
        {
            return _context.mails.Any(e => e.mailId == id);
        }
    }
}
