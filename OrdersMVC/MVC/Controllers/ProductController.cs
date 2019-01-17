using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private HttpClient Client;
        private Uri ServiceUri;

        public ProductController(Uri serviceUri, HttpClient client)
        {
            Client = client;
            ServiceUri = serviceUri;
        }
        
        public async Task<ActionResult> ProductIndex()
        {
            HttpResponseMessage response = await Client.GetAsync(new Uri(ServiceUri, "Product"));

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Handle error
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            List<Product> db_Products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

            return View(db_Products);
        }
        
    }
}