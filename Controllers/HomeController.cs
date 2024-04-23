﻿using B2B_Deneme.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B2B_Deneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult SingUpPage()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MusteriList()
        {
            return View();
        }

        public IActionResult Stoklar()
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