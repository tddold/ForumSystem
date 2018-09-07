using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Areas.Adminisration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Navigation()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Car",
                    Price = 1000000
                },
                new Product
                {
                    Id = 2,
                    Name = "Chair",
                    Price = 100
                },
                new Product
                {
                    Id = 3,
                    Name = "Comp",
                    Price = 1000
                }
            };

            return View(products);
        }

    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}