using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class Category {
    public int Id { get; set; }
    

    [Display(Name = "Naziv kategorije")]
    public string? Title { get; set; }

    
    [Display(Name = "Opis kategorije")]  
    public string? Description { get; set; }

    public List<Product>? Products { get; set; }
}