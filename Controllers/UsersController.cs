using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2B_Deneme.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
