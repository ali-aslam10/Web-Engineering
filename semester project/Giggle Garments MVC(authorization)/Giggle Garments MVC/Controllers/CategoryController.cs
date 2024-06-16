using Giggle_Garments_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Giggle_Garments_MVC.Controllers
{
    public class CategoryController : Controller
    {
        public ViewResult NewIn()
        {
            return View();
        }
        public ViewResult Boys()
        {
            productRepository productRepository = new productRepository();
            return View(productRepository.getbycategoryId(1));
        }
        public ViewResult Girls()
        {
            productRepository productRepository = new productRepository();
            return View(productRepository.getbycategoryId(2));
        }
        public ViewResult NewBorn()
        {
            productRepository productRepository = new productRepository();
            return View(productRepository.getbycategoryId(3));
        }
        public ViewResult specific(int id) 
        {
            productRepository productRepository = new productRepository();
            Product p = productRepository.getbyId(id);
            return View(p);  
        }
    }
}
