using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Order : AViewModel
    {
        public enum OrderStatus
        {
            Pending,
            Successful,
            Failed
        };

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public string Notes { get; set; }
        public int? OrderNumber { get; set; }
    }
}
