using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class Product {
    public int Id { get; set; }

    [Display(Name = "Naziv")]  
    public string? Title { get; set; }
    [Display(Name = "Opis")]  
    public string? Description { get; set; }
    [Display(Name = "Cijena")]  
    public decimal Price { get; set; }
    [Display(Name = "Količina")] 
    public int Quantity { get; set; }
    [Display(Name = "Rasrodaja")]  
    public bool OnSale { get; set; }
    [Display(Name = "Cijena popusta")]  
    public decimal SalePrice { get; set; }
}