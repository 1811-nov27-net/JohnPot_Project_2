using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            Order.Models.Clear();
            List<Order> db_Orders = JsonConvert.DeserializeObject<List<Order>>(responseBody);
            Order.Models = db_Orders;

            return View(db_Orders);
            
        }

        public async Task<ActionResult> AddProduct(int id)
        {
            Product product = Product.GetById(id) as Product;
            Order order = Order.GetByName(product.Name) as Order;

            if(order == null)
            {
                order = new Order()
                {
                    Name = product.Name,
                    Quantity = 1,
                    
                };
                // Order does not exist, use POST
                StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await Client.PostAsync(new Uri(ServiceUri, "Order"), content);

            }
            else
            {
                // Order exists, use PUT 
                order.Quantity++;
                StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await Client.PutAsync(new Uri(ServiceUri, "Order"), content);
            }

            return RedirectToAction("OrderIndex", "Order");
        }
    }
}