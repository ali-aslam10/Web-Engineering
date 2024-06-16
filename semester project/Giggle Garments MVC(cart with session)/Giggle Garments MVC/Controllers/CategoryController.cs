using Giggle_Garments_MVC.Models;
using Giggle_Garments_MVC.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Giggle_Garments_MVC.Controllers
{
    public class CategoryController : Controller
    {
        public ViewResult NewIn()
        {
            productRepository productRepository = new productRepository();
            return View(productRepository.getNewIn());
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
            Product p = productRepository.GetById(id);
            return View(p);  
        }
    }
}
