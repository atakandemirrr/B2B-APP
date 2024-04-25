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

        [HttpGet]
        public IActionResult UpdateUser(int Id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == Id);

            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(User A)
        {


            var user = _context.Users.FirstOrDefault(x => x.UserId == A.UserId);
            List<string> existingEmails = _context.Musteri().AsEnumerable().Select(row => row.Field<string>("cari_EMail")).ToList();
            if (existingEmails.Contains(A.Email))
            {
                user.UpdateDate = A.UpdateDate;
                user.Name = A.Name;
                user.Surname = A.Surname;
                user.Email = A.Email;
                user.Password = A.Password;
                user.IsAdmin = A.IsAdmin;
                _context.SaveChanges();
                return RedirectToAction("Users", "Users");
            }
            return View();

        }

        [HttpGet]
        public IActionResult CandidateUsers()
        {
            var UserList = _context.CandidateUsers.ToList();
            return View(UserList);
        }

        [HttpPost]
        public IActionResult CandidateUsers(int userId, int Statu)
        { 
            if (Statu == 2)
            {
                var cadidateuser = _context.CandidateUsers.FirstOrDefault(x => x.UserId == userId);
                cadidateuser.Statu = Statu;
                _context.SaveChanges(); 

            }
            else
            {

                var cadidateuser = _context.CandidateUsers.FirstOrDefault(x => x.UserId == userId);
                cadidateuser.Statu = Statu;
                _context.SaveChanges();

                Models.User User = new User();

                User.Name = cadidateuser.Name;
                User.Surname = cadidateuser.Surname;
                User.Email = cadidateuser.Email;
                User.CreDate = DateTime.Now;
                User.Password = cadidateuser.Password;
                User.IsPasivve = false;
                User.IsAdmin = false;
                _context.Users.Add(User);
                _context.SaveChanges();
                 
            }
            return RedirectToAction("CandidateUsers", "Users");
          
        }
      


    }
}
