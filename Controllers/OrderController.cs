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
            var email = User.Identity.Name;


            VMMusteriler model = new VMMusteriler();

            model.CariSipBilgileri = _context.CariSipBilgileri(email).AsEnumerable().ToList(); ;
             return View(model);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var email = User.Identity.Name;


            VMMusteriler model = new VMMusteriler();

            model.CariBilgileri = _context.CariBilgileri(email);
            if(model.CariBilgileri.Rows.Count==0)
            {

                return RedirectToAction("Orders", "Order");
               
            }
            return View(model);


        }
    }
}
