using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using B2B_Deneme.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;



namespace B2B_Deneme.Controllers
{

    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginPage(User p)
        {
           
            var data = _context.Users.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (data != null) 
            {
               
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");

            }
            return View();
        }

        public IActionResult SingUpPage()
        {
            return View();
        }
    }
}
