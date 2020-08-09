using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XMLEditor.Models;
using XMLEditor.Repository;

namespace XMLEditor.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(User usr)
        {
            var password = usr.Password;
            var user = new UserRepository().GetUserByLoginName(usr.Login);
            if (user != null && user.VerifyPassword(usr.Password))
            {
                HttpContext.Session.SetObjectAsJson("user", user);
                return Ok("OK");

            }
            return View("Index");
            
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return View("Index");

        }
    }
}