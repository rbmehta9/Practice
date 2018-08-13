using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id1)
        {
            var product = products.FirstOrDefault((p) => p.Id == id1);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
