using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Order
    {
        public enum OrderStatus
        {
            Pending,
            Successful,
            Failed
        };
        public enum Sort
        {
            Name,
            Quantity,
            Status,
            Notes,
            OrderNumber,
            Time
        };

        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public string Notes { get; set; }
        public int? OrderNumber { get; set; }

        public static List<Order> Models = new List<Order>();

        public Order()
        {
            Id = NextId;
            Models.Add(this);
        }

        public int Id { get; set; }
        public static int NextId { get => (Models.Count <= 0) ? 1 : Models.Max(m => m.Id) + 1; }
        public string Name { get; set; }

        public static Order GetById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }
        public static Order GetByName(string name)
        {
            if (name == null)
                return null;

            var orders = Models.Where(m => m.Name == name);

            // Attempt to return pending orders first. 
            if (orders.Count() > 1)
            {
                var pendingOrder = orders.FirstOrDefault(o => o.Status == Order.OrderStatus.Pending);
                if (pendingOrder != null)
                    return pendingOrder;

            }

            return Models.FirstOrDefault(m => m.Name == name);
        }
        public static List<Order> GetByNumber(int orderNumber)
        {
            if (orderNumber == 0)
                return null;

            return Models.Where(o => o.OrderNumber == orderNumber).ToList();
        }

        public async static Task Sync(HttpClient client, Uri serviceUri)
        {
            HttpResponseMessage response = await client.GetAsync(new Uri(serviceUri, "Order"));

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Handle error
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            Order.Models.Clear();
            List<Order> db_Orders = JsonConvert.DeserializeObject<List<Order>>(responseBody);
            Order.Models = db_Orders;
        }
    }
}
