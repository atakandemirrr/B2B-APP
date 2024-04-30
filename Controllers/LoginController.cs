using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using B2B_Deneme.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;
using Microsoft.EntityFrameworkCore;



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

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> LoginPage(User p)
        //{

        //    var data = _context.Users.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password && x.IsPasivve==false);
        //    if (data != null)
        //    {

        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, p.Email)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var principal = new AuthenticationProperties
        //        {

        //            IsPersistent = true,
        //            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
        //        };

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity), principal);
        //        return RedirectToAction("Index", "Home");

        //    }
        //    return View();
        //}
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginPage(User p)
        {
            if (p.Email == "admin@gmail.com" && p.Password == "Admin2024")
            {
                // İlk Veritabanı oluşturma, B2BAPP veritabanını kontrol et
                var databaseExists = _context.Database.GetDbConnection().State != ConnectionState.Closed;

                if (!databaseExists)
                {
                    // B2BAPP veritabanı yok, oluştur
                    _context.Database.EnsureCreated();
                    // Tabloları oluşturmak için gerekli işlemleri yap
                    // Örnek: _context.Database.Migrate() kullanarak mevcut migration'ları uygulayabilirsiniz.

                    // Şimdi tekrar kullanıcıyı kontrol et


                    if (p.Email == "admin@gmail.com" && p.Password == "Admin2024")
                    {
                        // Kullanıcı bulundu, oturum açma işlemini gerçekleştir
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.Email)
                };
                        var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity), principal);
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            else
            {
                var data = _context.Users.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password && x.IsPasivve == false);
                if (data != null)
                {

                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, p.Email)
                        };
                    var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new AuthenticationProperties
                    {

                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity), principal);
                    return RedirectToAction("Index", "Home");

                }
                return View();
            }

            return View();


        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUpPage()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignUpPage(CandidateUser a)
        {

            List<string> existingEmails = _context.Musteri().AsEnumerable().Select(row => row.Field<string>("cari_EMail")).ToList();
            if (existingEmails.Contains(a.Email))
            {
                var data = _context.CandidateUsers.FirstOrDefault(x => x.Email == a.Email);
                if (data == null)
                {
                    _context.CandidateUsers.Add(a);
                    _context.SaveChanges();
                    return RedirectToAction("LoginPage", "Login");
                }
                return View();
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> LogOut() /*Çıkış İşlemi İçin Kullanılıcak*/
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginPage", "Login");

        }
    }
}
