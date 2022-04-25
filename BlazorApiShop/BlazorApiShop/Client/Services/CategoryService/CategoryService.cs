using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApiShop.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public CategoryService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/categories");
            if (result != null)
            {
                Categories = result;
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var result = await _http.GetFromJsonAsync<Category>($"api/categories/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Category not found!");
        }

        public async Task CreateCategory(Category category)
        {
            var result = await _http.PostAsJsonAsync("api/categories", category);
            await SetCategories(result);
        }

        public async Task UpdateCategory(Category category)
        {
            var result = await _http.PutAsJsonAsync($"api/categories/{category.Id}", category);
            await SetCategories(result);
        }

        public async Task DeleteCategory(int id)
        {
            var result = await _http.DeleteAsync($"api/categories/{id}");
            await SetCategories(result);
        }

        private async Task SetCategories(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Category>>();
            Categories = response;
            _navigationManager.NavigateTo("categories");
        }
    }
}
