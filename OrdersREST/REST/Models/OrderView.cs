using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Models
{
    public class OrderView
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Order.OrderStatus Status { get; set; }
        public string Notes { get; set; }
        public int? OrderNumber { get; set; }

        public static OrderView Map(Order dbOrder)
        {
            OrderView vOrder = new OrderView
            {
                Notes = dbOrder.Notes,
                OrderNumber = dbOrder.OrderNumber,
                Quantity = dbOrder.Quantity,
                Status = dbOrder.Status
            };

            //vOrder.ProductName = 

            return vOrder;
        }
    }
}
