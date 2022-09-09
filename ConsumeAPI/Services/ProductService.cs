using ConsumeAPI.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConsumeAPI.Services
{
    public class ProductService
    {
        HttpClient client;
        public ProductService()
        {
            //client = new HttpClient();
        }
        public async Task<ICollection<Product>> GetAll()
        {
            List<Product> products = null;
            try
            {
                using (client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31457/");
                    var response = await client.GetAsync("api/Product");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        products = JsonConvert.DeserializeObject<List<Product>>(responseData);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return products;
        }
        public async Task<Product> Add(Product prod)
        {
            Product product = null;
            try
            {
                using (client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31457/");
                    var response = await client.PostAsJsonAsync("api/Product",prod);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        product = JsonConvert.DeserializeObject<Product>(responseData);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return product;
        }
     }
}
