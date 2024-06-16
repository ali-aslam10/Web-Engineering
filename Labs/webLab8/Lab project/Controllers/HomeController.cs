using Lab_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult contact()
        {
            return View();
        }
    }
}
