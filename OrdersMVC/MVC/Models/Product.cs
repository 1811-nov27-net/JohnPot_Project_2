using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Product : AViewModel
    {
        public float Price { get; set; }
        public int Inventory { get; set; }
    }
}
