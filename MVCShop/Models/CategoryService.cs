using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models;

public class CategoryService : ICategoryService {
    public ShopContext db { get; }
    public CategoryService(ShopContext context) {
        db = context;
    }
    public async Task<IEnumerable> All() {
        return await db.Categories.ToListAsync();
    }
}