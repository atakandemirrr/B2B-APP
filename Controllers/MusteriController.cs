﻿using Microsoft.AspNetCore.Mvc;

namespace B2B_Deneme.Controllers
{
    public class MusteriController : Controller
    {
        public IActionResult MusteriList()
        {
            return View();
        }
    }
}