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
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.productCategories.ToListAsync());
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductCategory = await _context.productCategories
                .FirstOrDefaultAsync(m => m.productCategoryId == id);
            if (tblProductCategory == null)
            {
                return NotFound();
            }

            return View(tblProductCategory);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productCategoryId,productCategoryName")] tblProductCategory tblProductCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProductCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProductCategory);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductCategory = await _context.productCategories.FindAsync(id);
            if (tblProductCategory == null)
            {
                return NotFound();
            }
            return View(tblProductCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productCategoryId,productCategoryName")] tblProductCategory tblProductCategory)
        {
            if (id != tblProductCategory.productCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProductCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblProductCategoryExists(tblProductCategory.productCategoryId))
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
            return View(tblProductCategory);
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProductCategory = await _context.productCategories
                .FirstOrDefaultAsync(m => m.productCategoryId == id);
            if (tblProductCategory == null)
            {
                return NotFound();
            }

            return View(tblProductCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProductCategory = await _context.productCategories.FindAsync(id);
            _context.productCategories.Remove(tblProductCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblProductCategoryExists(int id)
        {
            return _context.productCategories.Any(e => e.productCategoryId == id);
        }
    }
}
