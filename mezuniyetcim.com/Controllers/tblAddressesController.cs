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
    public class tblAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.addresses.ToListAsync());
        }

        // GET: tblAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAddress = await _context.addresses
                .FirstOrDefaultAsync(m => m.adresId == id);
            if (tblAddress == null)
            {
                return NotFound();
            }

            return View(tblAddress);
        }

        // GET: tblAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("adresId,Sehir,İlce,Mahalle,Cadde,Sokak,adresTanımı")] tblAddress tblAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAddress);
        }

        // GET: tblAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAddress = await _context.addresses.FindAsync(id);
            if (tblAddress == null)
            {
                return NotFound();
            }
            return View(tblAddress);
        }

        // POST: tblAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("adresId,Sehir,İlce,Mahalle,Cadde,Sokak,adresTanımı")] tblAddress tblAddress)
        {
            if (id != tblAddress.adresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblAddressExists(tblAddress.adresId))
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
            return View(tblAddress);
        }

        // GET: tblAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAddress = await _context.addresses
                .FirstOrDefaultAsync(m => m.adresId == id);
            if (tblAddress == null)
            {
                return NotFound();
            }

            return View(tblAddress);
        }

        // POST: tblAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAddress = await _context.addresses.FindAsync(id);
            _context.addresses.Remove(tblAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblAddressExists(int id)
        {
            return _context.addresses.Any(e => e.adresId == id);
        }
    }
}
