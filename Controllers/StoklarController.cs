using Microsoft.AspNetCore.Mvc;

namespace B2B_Deneme.Controllers
{
    public class StoklarController : Controller
    {
        public IActionResult Stoklar()
        {
            return View();
        }
    }
}
