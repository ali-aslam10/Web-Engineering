using Microsoft.AspNetCore.Mvc;

namespace Giggle_Garments_MVC.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult viewCart()
        {
            return View();
        }
        public ViewResult addtoCart()
        {
            return View();
        }
        public ViewResult removefromCart()
        {
            return View();
        }
        [HttpGet]
        public ViewResult checkout()
        {
            return View();
        }
        [HttpPost]
        public ViewResult checkout(string country, string fname, string lname, string address, string city, string postalcode, string phone)
        {
            return View();
        }
    }
}
