using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M7.Models;

namespace M7.Controllers
{
    public class ShoppingController : Controller
    {
        private IShoppingRepository repo { get; set; }
        private Basket basket { get; set; }
        public ShoppingController(IShoppingRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Shopping());
        }

        [HttpPost]
        public IActionResult Checkout(Shopping shopping)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, its empty!");
            }
            if (ModelState.IsValid)
            {
                shopping.Lines = basket.Items.ToArray();
                repo.SaveShopping(shopping);
                basket.ClearBasket();

                return RedirectToPage("/ShoppingCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
