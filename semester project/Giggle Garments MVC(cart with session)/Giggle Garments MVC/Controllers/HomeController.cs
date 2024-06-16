using Giggle_Garments_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Giggle_Garments_MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
