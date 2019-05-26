using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magnetizer.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Magnetizer.Controllers
{
    /// <summary>
    /// The products controller, 
    /// that will handle all CRUD operations regarding magnetizing a product.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Magnet database context from Entity Framework
        /// </summary>
        private readonly MagnetizerContext _context;

        public ProductsController(MagnetizerContext context)
        {
            _context = context;
        }

        // GET: api/Products
        /// <summary>
        /// Gets all the products from the magnet database
        /// </summary>
        /// <returns>All products</returns>
        [SwaggerOperation(Summary = "", Description = "Gets all products in the database")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.Include(i => i.Location).ToListAsync();
        }

        // GET api/Products/Magnetic
        /// <summary>
        /// Gets all magnetized products.
        /// Meaning all products that are currently magnetized
        /// </summary>
        /// <returns>All magnetized products</returns>
        [SwaggerOperation(Summary = "", Description = "Get all products in the database which are set to magnetized true")]
        [HttpGet]
        [Route("/magnetonly")]
        public async Task<ActionResult<IEnumerable<Product>>> GetMagneticProducts()
        {
            var products = from item in _context.Product
                       where item.IsMagnetized
                       select item;
            return await products.Include(i => i.Location).ToListAsync();
        }

        // GET: api/Products/5
        /// <summary>
        /// Get the product from a products ID, saved as guid in this database
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Product</returns>
        [SwaggerOperation(Summary = "", Description = "Get the product with the matching GUID")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = _context.Product.Where(itm => itm.Guid == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        /// <summary>
        /// Updates a specific product, used when changing magnetic state
        /// </summary>
        /// <param name="id">The products ID - saved as productID in this database</param>
        /// <param name="product">The product to update</param>
        /// <returns>HTTP code</returns>
        [SwaggerOperation(Summary = "", Description = "Update a specific product")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        /// <param name="product">The new product</param>
        /// <returns>The newly created product</returns>
        [SwaggerOperation(Summary = "", Description = "Add new product to the database")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        /// <summary>
        /// Deletes a specific product
        /// </summary>
        /// <param name="id">Products ID - Maps to the productID in this database.</param>
        /// <returns>The deleted product</returns>
        [SwaggerOperation(Summary = "", Description = "Delete a product with the specific Id")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        /// <summary>
        /// Used to find if a product is registered in the database
        /// </summary>
        /// <param name="id">ProductID - Maps to ProductId in this database</param>
        /// <returns>he product if they excist.</returns>
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
