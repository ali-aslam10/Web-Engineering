using lab10.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab10.Controllers
{
    public class UserController : Controller
    {
        //public IActionResult Index()
        //{
           
        //}
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(User u)
        {
           
            if (!(u.password=="Abc.123" && u.email=="xyz@gmail.com"))

            {
                return View("login");

            }
            else
            {
                HttpContext.Response.Cookies.Append("Email", u.email.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                HttpContext.Response.Cookies.Append("Password", u.password.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                HttpContext.Response.Cookies.Append("Color", u.color.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                return RedirectToAction("home", "Home");
            }

        }
        public IActionResult logout()
        {
            Response.Cookies.Delete("Email");
            Response.Cookies.Delete("Password");
            Response.Cookies.Delete("Color");
            return RedirectToAction("index","Home");
        }

    }
}
