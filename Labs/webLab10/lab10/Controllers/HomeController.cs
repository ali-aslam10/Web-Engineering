using lab10.Models;
using lab10.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Email"))
            {
                return RedirectToAction("home", "Home");
            }

            return RedirectToAction("login", "User");
        }
        public IActionResult home()
        {
            List<productOrder> productOrders = new List<productOrder>();
            Order order1 = new Order();
            order1.Id = 01;
            order1.amount = 51200;
            order1.createdat = "12/5/2020";
            List<Product> products= new List<Product>();
            Product p1=new Product();
            p1.Id = 1;
            p1.Name = "Laptop";
            p1.Description = "Hp Laptop";
            p1.Price = 50000;
            Product p2 = new Product();
            p2.Id = 2;
            p2.Name = "Laptop Bag";
            p2.Description = "Hp Laptop Bag";
            p2.Price = 1200;
            products.Add(p1);
            products.Add(p2);
            productOrder productOrder1 = new productOrder();
            productOrder1.order=order1;
            productOrder1.products=products;

            productOrders.Add(productOrder1 );

            Order order2 = new Order();
            order2.Id = 02;
            order2.amount = 51200;
            order2.createdat = "12/5/2020";
            List<Product> products1 = new List<Product>();
            Product p3 = new Product();
            p3.Id = 3;
            p3.Name = "Laptop";
            p3.Description = "Dell Laptop";
            p3.Price = 50000;
            Product p4 = new Product();
            p4.Id = 4;
            p4.Name = "Laptop Bag";
            p4.Description = "Dell Laptop Bag";
            p4.Price = 1200;
            products1.Add(p3);
            products1.Add(p4);

            productOrder productOrder2 = new productOrder();
            productOrder2.order = order2;
            productOrder2.products = products1;
            productOrders.Add(productOrder2);


            return View(productOrders);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
