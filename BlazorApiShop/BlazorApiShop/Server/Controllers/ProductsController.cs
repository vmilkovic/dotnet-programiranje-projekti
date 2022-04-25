using BlazorApiShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApiShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await GetDatabaseProducts());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound("No product found.");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            product.Category = null;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return Ok(await GetDatabaseProducts());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product, int id)
        {
            var dbProduct = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct == null)
            {
                return NotFound("No product found.");
            }

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Quantity = product.Quantity;
            dbProduct.InStock = product.InStock;
            dbProduct.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();

            return Ok(await GetDatabaseProducts());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var dbProduct = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct == null)
            {
                return NotFound("No product found.");
            }

            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return Ok(await GetDatabaseProducts());
        }

        private async Task<List<Product>> GetDatabaseProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
