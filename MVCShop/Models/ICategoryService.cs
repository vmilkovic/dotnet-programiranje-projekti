using System.Collections;

namespace Shop.Models;

public interface ICategoryService {
    Task<IEnumerable> All();
    ShopContext db { get; }
}