using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mezuniyetcim.com.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mezuniyetcim.com.Data;
using Microsoft.EntityFrameworkCore;

namespace mezuniyetcim.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            homeViewModel home = new homeViewModel();
            home.products = _context.products.ToList();
            home.productCategories = _context.productCategories.ToList();
            home.productImages = _context.productImages.ToList();
            home.vizyons = _context.vizyons.ToList();
            home.misyons = _context.misyons.ToList();
            home.addresses = _context.addresses.ToList();
            home.phones = _context.phones.ToList();
            home.mails = _context.mails.ToList();
            return View(home);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.products.Include(x => x.productImages).Include(y=>y.productCategory)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
