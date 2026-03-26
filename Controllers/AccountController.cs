using Microsoft.AspNetCore.Mvc;
using collegemainatanceportal.Models;
using collegemainatanceportal.Data;
using System.Linq;

namespace collegemainatanceportal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            var users = _context.Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (users != null)
            {
                HttpContext.Session.SetString("Role", users.Role);
                return RedirectToAction("Index", "Complaint");
               
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user, string AdminKey)
        {
            if (user.Role == "Staff")
            {
                return RedirectToAction("StaffPage", "Complaint");
            }
          
            {
                if (user.Role == "Admin")
                {
                    if (AdminKey != "ADMIN123")
                    {
                        ViewBag.Error = "Invalid Admin Key";
                        return View();
                    }
                }
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
