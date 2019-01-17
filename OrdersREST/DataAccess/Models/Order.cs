using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Order
    {
        public enum OrderStatus
        {
            Pending,
            Successful,
            Failed
        };

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public string Notes { get; set; }
        public int? OrderNumber { get; set; }

        public virtual Product Product { get; set; }
    }
}
