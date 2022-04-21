#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Pages_Products
{
    public class PriceModel : PageModel
    {
        private readonly ShopContext _context;

        public PriceModel(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Product = await _context.Product.OrderByDescending(p => p.Price).ToListAsync();

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IList<Product> Product { get;set; }
    }
}
