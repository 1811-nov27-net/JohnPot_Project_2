using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Models
{
    public class OrderView
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Order.OrderStatus Status { get; set; }
        public string Notes { get; set; }
        public int? OrderNumber { get; set; }

        public static OrderView Map(Order dbOrder, Repository repo)
        {
            OrderView vOrder = new OrderView
            {
                Notes = dbOrder.Notes,
                OrderNumber = dbOrder.OrderNumber,
                Quantity = dbOrder.Quantity,
                Status = dbOrder.Status
            };

            vOrder.Name = repo.ProductRepo.GetById(dbOrder.ProductId).Name;

            return vOrder;
        }
        public static Order Map(OrderView viewOrder, Repository repo)
        {
            Order dbOrder = new Order
            {
                Notes = viewOrder.Notes,
                OrderNumber = viewOrder.OrderNumber,
                Quantity = viewOrder.Quantity,
                Status = viewOrder.Status
            };

            dbOrder.ProductId = repo.ProductRepo.GetByName(viewOrder.Name).Id;
            
            var order = repo.OrderRepo.GetByProductId(dbOrder.ProductId);
            if (order != null)
                dbOrder.Id = order.Id;

            return dbOrder;
        }
    }
}
