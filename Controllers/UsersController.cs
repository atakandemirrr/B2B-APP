using Microsoft.AspNetCore.Mvc;

namespace B2B_Deneme.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
