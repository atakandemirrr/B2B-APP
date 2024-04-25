using B2B_Deneme.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace B2B_Deneme.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        public readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var UserList = _context.Users.ToList();
            return View(UserList);
        }

        [HttpPost]
        public IActionResult UserStatuUpdate(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            user.IsPasivve = !user.IsPasivve;
            _context.SaveChanges();
         
            var UserList = _context.Users.ToList();
            return View("Users",UserList);
           
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
       
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User a)
        {
            List<string> existingEmails = _context.Musteri().AsEnumerable().Select(row => row.Field<string>("cari_EMail")).ToList();
            if (existingEmails.Contains(a.Email))
            {
                var data = _context.Users.FirstOrDefault(x => x.Email == a.Email);
            if (data == null)
            {
                    _context.Users.Add(a);
                    _context.SaveChanges();
                    return RedirectToAction("Users", "Users");
            }
            return View();
            }
            return View();
        }
    }
}
