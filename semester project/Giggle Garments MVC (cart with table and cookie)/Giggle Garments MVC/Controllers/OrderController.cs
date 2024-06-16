using Giggle_Garments_MVC.Models;
using Giggle_Garments_MVC.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Giggle_Garments_MVC.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult viewCart()
        {
            if (HttpContext.Request.Cookies.ContainsKey("CartId"))
            {
                string cartid = HttpContext.Request.Cookies["CartId"];
                CartRepository cartRepository = new CartRepository();
                return View(cartRepository.getCart(cartid));
            }

            return View(new List<CartItem>());
        }
        
        public IActionResult addtoCart(CartItem cartitem)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = System.DateTime.Now.AddMonths(6);

            if (HttpContext.Request.Cookies.ContainsKey("CartId"))
            {
                int q = cartitem.Quantity;
                cartitem.CartId = HttpContext.Request.Cookies["CartId"];
                
                //Update Quantity

                int c = Convert.ToInt32(HttpContext.Request.Cookies["Quantity"]) + q;
                HttpContext.Response.Cookies.Append("Quantity", c.ToString(), option);
            }
            else
            {
                //new customer

                string id = Guid.NewGuid().ToString();
                int q = cartitem.Quantity;
                cartitem.CartId = id;
                HttpContext.Response.Cookies.Append("CartId", id, option);
                HttpContext.Response.Cookies.Append("Quantity", q.ToString(), option);
            }
            CartRepository cartRepository = new CartRepository();

            //if product already in cart just update quantity
            if (!cartRepository.isupdate(cartitem.CartId, cartitem.ProdId, cartitem.Quantity,cartitem.Size))
            {
                cartRepository.add(cartitem);
            }

            return RedirectToAction("specific", "Category",new { id = cartitem.ProdId });
        }
        public IActionResult removefromcart(int Id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = System.DateTime.Now.AddMonths(6);
            string cartid = HttpContext.Request.Cookies["CartId"];
            CartRepository cartRepository= new CartRepository();
            int quantity = cartRepository.getquantity(Id);

            //remove product from cart
            cartRepository.removefromCart(Id);

            int count = Convert.ToInt32(HttpContext.Request.Cookies["Quantity"]) - quantity ;

            //if cart become empty
            if (count == 0)
            {
                // delete cookie
                HttpContext.Response.Cookies.Delete("CartId");
                HttpContext.Response.Cookies.Delete("Quantity");
            }
            else
            {
                //Update Quantity
                HttpContext.Response.Cookies.Append("Quantity", count.ToString(), option);
            }
            return RedirectToAction("viewCart", "Order");
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
