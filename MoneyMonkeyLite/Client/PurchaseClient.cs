using MoneyMonkeyLite.Models;
using System.Net.Http.Json;
using System.Net.Http.Formatting;
using System.Net;


namespace MoneyMonkeyLite.Client
{
    public class PurchaseClient
    {
        static HttpClient client = new HttpClient();

        //POST
        static async Task<Uri> CreatePurchaseAsync(Purchase purchase)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Purchases", purchase);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        //GET
        static async Task<Purchase> GetPurchaseAsync(string path)
        {
            Purchase purchase = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                purchase = await response.Content.ReadAsAsync<Purchase>();
            }
            return purchase;
        }

        //PUT
        static async Task<Purchase> UpdatePurchaseAsync(Purchase purchase)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Purchases/{purchase.Id}", purchase);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated purchase from the response body.
            purchase = await response.Content.ReadAsAsync<Purchase>();
            return purchase;
        }

        //DELETE
        static async Task<HttpStatusCode> DeletePurchaseAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Purchases/{id}");
            return response.StatusCode;
        }

    }
}
