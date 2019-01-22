using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Product
    {
        public float Price { get; set; }
        public int Inventory { get; set; }


        public static List<Product> Models = new List<Product>();
        
        public Product()
        {
            Id = NextId;
            Models.Add(this);
        }

        public int Id { get; set; }
        public static int NextId { get => (Models.Count <= 0) ? 1 : Models.Max(m => m.Id) + 1; }
        public string Name { get; set; }

        public static Product GetById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }
        public static Product GetByName(string name)
        {
            if (name == null)
                return null;

            return Models.FirstOrDefault(m => m.Name == name);
        }

        public async static Task Sync(HttpClient client, Uri serviceUri)
        {

            HttpResponseMessage response = await client.GetAsync(new Uri(serviceUri, "Product"));

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Handle error
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            Product.Models.Clear();
            List<Product> db_Products = JsonConvert.DeserializeObject<List<Product>>(responseBody);
            Product.Models = db_Products;

        }
    }
}
