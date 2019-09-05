using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web_API_Demo.Models;

namespace Web_API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _context.Products.ToList();
        }

        // GET api/product/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            Product product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST api/product
        [HttpPost]
        public string Post(Product product)
        {
            if (!product.IsValid())
            {
                return "Input data invalid";
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return "Product ID: \"" + product.ID.ToString() + "\"";
        }

        // PUT api/product/{id}
        [HttpPut("{id}")]
        public string Put(Product model)
        {
            Product product = _context.Products.Find(model.ID);

            if(product == null)
            {
                return "Product not found";
            }

            product.Name = model.Name;
            product.Price = model.Price;

            if (!product.IsValid())
            {
                return "Input data invalid. Product was not changed";
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return "Product successfully updated";
        }

        // DELETE api/product/{id}
        [HttpDelete("{id}")]
        public string Delete(Guid id)
        {
            Product product = _context.Products.Find(id);

            if (product == null)
            {
                return "Product not found";
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return "Product removed";
        }
    }
}
