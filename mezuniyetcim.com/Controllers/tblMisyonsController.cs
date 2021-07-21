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
    public class tblMisyonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblMisyonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblMisyons
        public async Task<IActionResult> Index()
        {
            return View(await _context.misyons.ToListAsync());
        }

        // GET: tblMisyons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMisyon = await _context.misyons
                .FirstOrDefaultAsync(m => m.misyonId == id);
            if (tblMisyon == null)
            {
                return NotFound();
            }

            return View(tblMisyon);
        }

        // GET: tblMisyons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblMisyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("misyonId,misyonTitle,misyonDescription")] tblMisyon tblMisyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMisyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMisyon);
        }

        // GET: tblMisyons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMisyon = await _context.misyons.FindAsync(id);
            if (tblMisyon == null)
            {
                return NotFound();
            }
            return View(tblMisyon);
        }

        // POST: tblMisyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("misyonId,misyonTitle,misyonDescription")] tblMisyon tblMisyon)
        {
            if (id != tblMisyon.misyonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMisyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblMisyonExists(tblMisyon.misyonId))
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
            return View(tblMisyon);
        }

        // GET: tblMisyons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMisyon = await _context.misyons
                .FirstOrDefaultAsync(m => m.misyonId == id);
            if (tblMisyon == null)
            {
                return NotFound();
            }

            return View(tblMisyon);
        }

        // POST: tblMisyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMisyon = await _context.misyons.FindAsync(id);
            _context.misyons.Remove(tblMisyon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblMisyonExists(int id)
        {
            return _context.misyons.Any(e => e.misyonId == id);
        }
    }
}
