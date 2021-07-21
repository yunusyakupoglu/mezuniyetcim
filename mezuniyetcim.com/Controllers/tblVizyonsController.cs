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
    public class tblVizyonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblVizyonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblVizyons
        public async Task<IActionResult> Index()
        {
            return View(await _context.vizyons.ToListAsync());
        }

        // GET: tblVizyons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVizyon = await _context.vizyons
                .FirstOrDefaultAsync(m => m.vizyonId == id);
            if (tblVizyon == null)
            {
                return NotFound();
            }

            return View(tblVizyon);
        }

        // GET: tblVizyons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblVizyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vizyonId,vizyonTitle,vizyonDescription")] tblVizyon tblVizyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblVizyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblVizyon);
        }

        // GET: tblVizyons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVizyon = await _context.vizyons.FindAsync(id);
            if (tblVizyon == null)
            {
                return NotFound();
            }
            return View(tblVizyon);
        }

        // POST: tblVizyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vizyonId,vizyonTitle,vizyonDescription")] tblVizyon tblVizyon)
        {
            if (id != tblVizyon.vizyonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblVizyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblVizyonExists(tblVizyon.vizyonId))
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
            return View(tblVizyon);
        }

        // GET: tblVizyons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVizyon = await _context.vizyons
                .FirstOrDefaultAsync(m => m.vizyonId == id);
            if (tblVizyon == null)
            {
                return NotFound();
            }

            return View(tblVizyon);
        }

        // POST: tblVizyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblVizyon = await _context.vizyons.FindAsync(id);
            _context.vizyons.Remove(tblVizyon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblVizyonExists(int id)
        {
            return _context.vizyons.Any(e => e.vizyonId == id);
        }
    }
}
