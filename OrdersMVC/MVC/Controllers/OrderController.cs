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
        
        public ActionResult OrderIndex()
        {
            return View(Order.Models);
        }

        public async Task<ActionResult> AddProduct(int id)
        {
            Product product = Product.GetById(id) as Product;
            Order order = Order.GetByName(product.Name) as Order;

            if(order == null || order.Status != Order.OrderStatus.Pending)
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

        public ActionResult SortBy(Order.Sort sort)
        {
            switch(sort)
            {
                case Order.Sort.Name:
                    {
                        Order.Models = Order.Models.OrderBy(m => m.Name).ToList();
                        break;
                    }
                case Order.Sort.Quantity:
                    {
                        Order.Models = Order.Models.OrderBy(m => m.Quantity).ToList();
                        break;
                    }
                case Order.Sort.Status:
                    {
                        Order.Models = Order.Models.OrderBy(m => m.Status).ToList();
                        break;
                    }
                case Order.Sort.Notes:
                    {
                        Order.Models = Order.Models.OrderBy(m => m.Notes).ToList();
                        break;
                    }
                case Order.Sort.Time:
                    {
                        Order.Models = Order.Models.OrderByDescending(m => 
                        (m.OrderNumber!=null) ? 
                            Invoice.GetByNumber((int)m.OrderNumber).TimePlaced : 
                            DateTime.Now).ToList();

                        break;
                    }
                case Order.Sort.OrderNumber:
                    {
                        Order.Models = Order.Models.OrderByDescending(m => m.OrderNumber).ToList();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return RedirectToAction("OrderIndex", "Order");
        }

        public async Task<ActionResult> Sync()
        {
            await Invoice.Sync(Client, ServiceUri);
            await Order.Sync(Client, ServiceUri);
            return RedirectToAction("OrderIndex", "Order");
        }
    }
}