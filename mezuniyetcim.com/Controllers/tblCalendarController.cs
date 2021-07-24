using mezuniyetcim.com.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Controllers
{
    [Authorize]
    public class tblCalendarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public tblCalendarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult etkinlikGetir()
        {
            var eventlar = _context.events.ToList();

            return new JsonResult(eventlar);
        }
    }
}
