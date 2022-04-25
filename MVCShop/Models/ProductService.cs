using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models;

public class ProductService : IProductService {
    public ShopContext db { get; }

    public ProductService(ShopContext context) {
        db = context;
    }

    public async Task<IEnumerable> All()
    {
        return await db.Products
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable> OnDiscount()
    {
        return await db.Products
            .Where(product => product.OnDiscount == true)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable> OnSale()
    {
        return await db.Products
            .Where(product => product.OnSale == true)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<Product?> FindProduct(int? id)
    {
        return await db.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}