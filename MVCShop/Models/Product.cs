using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class Product {
    public int Id { get; set; }

    [Display(Name = "Naziv proizvoda")]  
    public string? Title { get; set; }

    [Display(Name = "Opis proizvoda")]  
    public string? Description { get; set; }

    [Display(Name = "Cijena")]  
    public decimal Price { get; set; }

    [Display(Name = "Količina")] 
    public int Quantity { get; set; }

    [Display(Name = "Popust")]  
    public bool OnDiscount { get; set; }

    [Display(Name = "Rasrodaja")]  
    public bool OnSale { get; set; }

    [Display(Name = "Cijena popusta")]  
    public decimal SalePrice { get; set; }

    [Display(Name = "Kategorija")]
    public int CategoryId { get; set; }
    
    public Category? Category { get; set; }
}