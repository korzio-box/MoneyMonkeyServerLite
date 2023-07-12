using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MoneyMonkeyLite.Models;


namespace MoneyMonkeyLite.Client
{
    public class CategoryClient
    {
        static HttpClient client = new HttpClient();

        //POST
        static async Task<Uri> CreateCategoryAsync(Category category)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Categories", category);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        //GET
        static async Task<Category> GetCategoryAsync(string path)
        {
            Category category = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                category = await response.Content.ReadAsAsync<Category>();
            }
            return category;
        }

        //PUT
        static async Task<Category> UpdateCategoryAsync(Category category)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Categories/{category.Id}", category);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated category from the response body.
            category = await response.Content.ReadAsAsync<Category>();
            return category;
        }

        //DELETE
        static async Task<HttpStatusCode> DeleteCategoryAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Categories/{id}");
            return response.StatusCode;
        }

    }
}
