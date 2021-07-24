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
    public class tblPhonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblPhonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblPhones
        public async Task<IActionResult> Index()
        {
            return View(await _context.phones.ToListAsync());
        }

        // GET: tblPhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhone = await _context.phones
                .FirstOrDefaultAsync(m => m.phoneId == id);
            if (tblPhone == null)
            {
                return NotFound();
            }

            return View(tblPhone);
        }

        // GET: tblPhones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblPhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("phoneId,phoneNumber")] tblPhone tblPhone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPhone);
        }

        // GET: tblPhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhone = await _context.phones.FindAsync(id);
            if (tblPhone == null)
            {
                return NotFound();
            }
            return View(tblPhone);
        }

        // POST: tblPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("phoneId,phoneNumber")] tblPhone tblPhone)
        {
            if (id != tblPhone.phoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblPhoneExists(tblPhone.phoneId))
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
            return View(tblPhone);
        }

        // GET: tblPhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhone = await _context.phones
                .FirstOrDefaultAsync(m => m.phoneId == id);
            if (tblPhone == null)
            {
                return NotFound();
            }

            return View(tblPhone);
        }

        // POST: tblPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPhone = await _context.phones.FindAsync(id);
            _context.phones.Remove(tblPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblPhoneExists(int id)
        {
            return _context.phones.Any(e => e.phoneId == id);
        }
    }
}
