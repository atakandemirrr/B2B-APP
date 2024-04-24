using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2B_Deneme.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        public IActionResult MusteriList()
        {
            return View();
        }
    }
}
