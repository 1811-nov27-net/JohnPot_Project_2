using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Invoice
    {
        private List<string> orders = new List<string>();
        public List<Order> Orders
        {
            get
            {
                List<Order> orderList = new List<Order>();
                orders.ForEach(o => orderList.Add(Order.GetByName(o) as Order));
                return orderList;
            }
        }

        public int OrderNumber { get; set; }
        public DateTime TimePlaced { get; set; }
        public float Total { get; set; }

        public static List<Invoice> Models = new List<Invoice>();

        public Invoice()
        {
            Id = NextId;
            Models.Add(this);
        }

        public int Id { get; set; }
        public static int NextId { get => (Models.Count <= 0) ? 1 : Models.Max(m => m.Id) + 1; }
        public string Name { get; set; }

        public static Invoice GetById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }
        public static Invoice GetByName(string name)
        {
            if (name == null)
                return null;

            return Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
