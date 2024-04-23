using Microsoft.AspNetCore.Mvc;

namespace B2B_Deneme.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult SingUpPage()
        {
            return View();
        }
    }
}
