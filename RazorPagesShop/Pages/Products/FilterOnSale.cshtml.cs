#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Pages_Products
{
    public class FilterOnSaleModel : PageModel
    {
        private readonly ShopContext _context;

        public FilterOnSaleModel(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Product = await _context.Product.Where(p => p.OnSale == OnSale).ToListAsync();

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        [Display(Name = "Rasprodaja")]
        public bool OnSale { get; set; }
        public IList<Product> Product { get; set; }
    }
}
