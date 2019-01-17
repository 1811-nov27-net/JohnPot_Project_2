using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public float Total { get; set; }
        public DateTime TimePlaced { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
