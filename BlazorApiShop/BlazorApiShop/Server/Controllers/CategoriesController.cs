using BlazorApiShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApiShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return Ok(await GetDatabaseCategories());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var dbCategory = await GetCategoryById(id);
            if (dbCategory == null)
            {
                return NotFound("No category found.");
            }
            return Ok(dbCategory);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(await GetDatabaseCategories());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category, int id)
        {
            var dbCategory = await GetCategoryById(id);
            if (dbCategory == null)
            {
                return NotFound("No category found.");
            }

            dbCategory.Name = category.Name;

            await _context.SaveChangesAsync();

            return Ok(await GetDatabaseCategories());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var dbCategory = await GetCategoryById(id);
            if (dbCategory == null)
            {
                return NotFound("No category found.");
            }

            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();

            return Ok(await GetDatabaseCategories());
        }

        private async Task<List<Category>> GetDatabaseCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        private async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
