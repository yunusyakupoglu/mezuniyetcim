using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mezuniyetcim.com.Data;
using mezuniyetcim.com.Entities;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace mezuniyetcim.com.Controllers
{
    [Authorize]
    public class tblProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public tblProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: tblProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.products.Include(x => x.productImages).Include(c => c.productCategory).ToListAsync());
        }

        // GET: tblProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.products.Include(x => x.productImages).Include(c => c.productCategory)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: tblProducts/Create
        public IActionResult Create()
        {
            var categories = _context.productCategories.ToList();
            ViewBag.categoryView = new SelectList(categories, "productCategoryId", "productCategoryName");
            return View();
        }

        // POST: tblProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductDescription,ProductPrice,Files,productCategoryID, productCategory")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Images"); //Kaydedilen dosya yolu yani wwwroot/Images
                if (!Directory.Exists(filePath)) //Eğer wwwroot/Images yoksa
                {
                    Directory.CreateDirectory(filePath); //wwwroot/Images oluştur
                }

                foreach (var item in tblProduct.Files)
                {
                    var fullFileName = Path.Combine(filePath, item.FileName);//c://httpdocs/wwwroot/Images/deneme.png
                    using (var fileStream = new FileStream(fullFileName, FileMode.Create))//gc  beklemeden kaynağı yok eder.
                    {
                        await item.CopyToAsync(fileStream);
                    }//Yani sunucuyu yormamak için iş bitince kaynağı yok eder
                    tblProduct.productImages.Add(new tblProductImage { fileName = item.FileName });
                }
                tblProduct.productCategory = _context.productCategories.Find(tblProduct.productCategoryID);
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProduct);
        }

        // GET: tblProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categories = _context.productCategories.ToList();
            ViewBag.categoryView = new SelectList(categories, "productCategoryId", "productCategoryName");
            var tblProduct = await _context.products.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            return View(tblProduct);
        }

        // POST: tblProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductDescription,ProductPrice,productCategoryID, productCategory")] tblProduct tblProduct)
        {
            if (id != tblProduct.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tblProduct.productCategory = _context.productCategories.Find(tblProduct.productCategoryID);
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblProductExists(tblProduct.ProductID))
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
            return View(tblProduct);
        }

        // GET: tblProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.products.Include(c => c.productCategory)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: tblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduct = await _context.products.Include(img => img.productImages).FirstOrDefaultAsync(m => m.ProductID == id);
            foreach (var item in tblProduct.productImages)
            {
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Images"); //Kaydedilen dosya yolu yani wwwroot/Images
                var fullFileName = Path.Combine(filePath, item.fileName);//c://httpdocs/wwwroot/Images/deneme.png
                System.IO.File.Delete(fullFileName);
                _context.productImages.Remove(item);
            }
            _context.products.Remove(tblProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblProductExists(int id)
        {
            return _context.products.Any(e => e.ProductID == id);
        }
    }
}
