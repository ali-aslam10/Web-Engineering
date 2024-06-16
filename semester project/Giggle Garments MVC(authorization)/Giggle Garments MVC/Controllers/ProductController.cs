using Giggle_Garments_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Giggle_Garments_MVC.Controllers

{
    [Authorize(Policy= "onlyadmin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _env;

        public ProductController(ILogger<ProductController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public ViewResult Index()
        {
            productRepository productRepository = new productRepository();

            return View(productRepository.getAll());
        }
        public ViewResult viewStock()
        {
            StockRepository stockRepository = new StockRepository();
            return View(stockRepository.getAll());
        }
        [HttpGet]
        public ViewResult addProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addProduct(Product p, IFormFile myfile)
        {
            if(ModelState.IsValid)
            {
                string wwwrootpath = _env.WebRootPath;
               
                string folder;
                if (p.category_Id == 1)
                    folder = "Boys images";
                else if (p.category_Id == 2)
                    folder = "Girls images";
                else if (p.category_Id == 3)
                    folder = "Newborn images";
                else
                    folder = "NewIn images";

                string path = Path.Combine(wwwrootpath, folder);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (myfile.Length > 0)
                {
                    string uniquename = Guid.NewGuid().ToString() + "_" + myfile.FileName;
                    string filepath = Path.Combine(path, uniquename);
                    using (var FileStream = new FileStream(filepath, FileMode.Create))
                    {
                        myfile.CopyTo(FileStream);
                    }
                    p.imagePath = filepath;
                }

                productRepository productRepository = new productRepository();
                productRepository.add(p);

                return View("addStock");
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ViewResult UpdateProduct(int id)
        {
            productRepository productRepository = new productRepository();
            Product p=productRepository.getbyId(id);
            return View("UpdateProduct", p);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                productRepository productRepository = new productRepository();
                productRepository.UpdateProduct(p);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ViewResult addStock()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addStock(Stock s)
        {
           
            StockRepository stockRepository = new StockRepository();
            stockRepository.add(s);

            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public ViewResult UpdateStock(int id)
        {
            StockRepository stockRepository = new StockRepository();
            Stock s = stockRepository.getbyId(id);
            return View("UpdateStock", s);
        }
        [HttpPost]
        public IActionResult UpdateStock(Stock s)
        {
            StockRepository stockRepository = new StockRepository();
            stockRepository.update(s);
            return RedirectToAction("viewStock", "Product");

        }
        public IActionResult removeProdct(int id)
        {
            productRepository productRepository = new productRepository();
            Product p = productRepository.getbyId(id);
            string imagePath = p.imagePath;
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            productRepository.removeProduct(id);

            return RedirectToAction("Index", "Product");
        }
        public ViewResult editProduct()
        {
            return View();
        }
    }
}
