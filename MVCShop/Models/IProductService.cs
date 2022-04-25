using System.Collections;

namespace Shop.Models;

public interface IProductService {
    Task<IEnumerable> All();
    Task<IEnumerable> OnDiscount();
    Task<IEnumerable> OnSale();
    Task<Product?> FindProduct(int? id);
    ShopContext db { get; }
}