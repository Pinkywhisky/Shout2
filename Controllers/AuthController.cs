using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shout.DAL;
using Shout.Models;

namespace Shout.Controllers
{
    public class AuthController : Controller
    {
        private readonly ShoutContext _context;

        public AuthController()
        {
            _context = new ShoutContext();
        }

        public IActionResult Index()
        {
            return RedirectToAction("SignIn");
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserAuth auth)
        {
            UserAuth user = _context.UserAuth
                .Where(u => u.Username == auth.Username)
                .FirstOrDefault();

            if (user != null && user.Password == auth.Password)
            {
                HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag["error"] = true;
                return View();
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserAuth user)
        {
            _context.UserAuth.Add(user);
            _context.SaveChanges();

            return RedirectToAction("SignIn");
        }
    }
}
