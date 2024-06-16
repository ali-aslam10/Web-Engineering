using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_MVC.Controllers
{
    public class UserController : Controller
    {
        public ViewResult signin()
        {
            return View();
        }
        public ViewResult register()
        {
            return View();
        }
    }
}
