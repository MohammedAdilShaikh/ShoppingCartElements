using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> _products = new List<Product>();

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _products.Add(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            var existingProduct = _products.Find(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            // Update other properties as needed
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productToRemove = _products.Find(p => p.Id == id);
            if (productToRemove == null)
            {
                return NotFound();
            }
            _products.Remove(productToRemove);
            return Ok();
        }
    }
}
