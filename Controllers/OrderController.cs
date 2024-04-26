using B2B_Deneme.Models;
using B2B_Deneme.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace B2B_Deneme.Controllers
{

    public class OrderController : Controller
    {
        public readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Orders()
        {


            return View();
        }
    }
}
