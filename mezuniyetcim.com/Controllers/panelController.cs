﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Controllers
{
    [Authorize]
    public class panelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
