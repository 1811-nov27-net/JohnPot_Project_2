using System;
using System.Collections.Generic;
using System.Linq;
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

            return Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
