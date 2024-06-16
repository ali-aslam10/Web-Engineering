using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab_project_2.Controllers
{
    public class DepartmentsController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "SEonly")]
        public IActionResult SE()
        {
            return View();
        }
        [Authorize(Policy = "CSonly")]
        public IActionResult CS()
        {
            return View();
        }
        [Authorize(Policy = "ITonly")]
        public IActionResult IT()
        {
            return View();
        }

    }
}
