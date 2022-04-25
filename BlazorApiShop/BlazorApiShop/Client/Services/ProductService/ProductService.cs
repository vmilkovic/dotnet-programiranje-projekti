using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApiShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProductService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }   

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Product>>("api/products");
            if (result != null)
            {
                Products = result;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            var result = await _http.GetFromJsonAsync<Product>($"api/products/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Product not found!");
        }

        public async Task CreateProduct(Product product)
        {
            var result = await _http.PostAsJsonAsync("api/products", product);
            await SetProducts(result);
        }

        public async Task UpdateProduct(Product product)
        {
            var result = await _http.PutAsJsonAsync($"api/products/{product.Id}", product);
            await SetProducts(result);
        }

        public async Task DeleteProduct(int id)
        {
            var result = await _http.DeleteAsync($"api/products/{id}");
            await SetProducts(result);
        }

        private async Task SetProducts(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Product>>();
            Products = response;
            _navigationManager.NavigateTo("products");
        }
    }
}
