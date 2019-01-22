using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Models
{
    public class ProductView
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Inventory { get; set; }
    }
}
