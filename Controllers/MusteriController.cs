using B2B_Deneme.Models;
using B2B_Deneme.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq; 

namespace B2B_Deneme.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        public readonly DataContext _context;

        public MusteriController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MusteriList()
        {
            VMMusteriler model = new VMMusteriler();

           model.Musteriler  = _context.Musteri().AsEnumerable().ToList();

            return View(model);
        }
    }
}
