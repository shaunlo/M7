using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M7.Models;


namespace M7.Components
{
    public class BasketSummaryViewComponent : ViewComponent
    {   
        private Basket basket;

        public BasketSummaryViewComponent(Basket basketService)
        {
            basket = basketService;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
