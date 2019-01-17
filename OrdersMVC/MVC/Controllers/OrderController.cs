using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private HttpClient Client;
        private Uri ServiceUri;

        public OrderController(Uri serviceUri, HttpClient client)
        {
            Client = client;
            ServiceUri = serviceUri;
        }
        
        public async Task<ActionResult> OrderIndex()
        {
            HttpResponseMessage response = await Client.GetAsync(new Uri(ServiceUri, "Order"));

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Handle error
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            List<Order> db_Orders = JsonConvert.DeserializeObject<List<Order>>(responseBody);

            return View(db_Orders);
            
        }
    }
}