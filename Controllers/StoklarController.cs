using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2B_Deneme.Controllers
{
    [Authorize]
    public class StoklarController : Controller
    {
        public IActionResult Stoklar()
        {
            return View();
        }
    }
}
