using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess
{
    public class OrderInitializer
    {
        public void Seed(OrderContext context)
        {
            var products = new List<Product>
            {
                new Product{Name="Chai",                     Price=20.00f, Inventory=50},
                new Product{Name="Chang",                    Price=19.00f, Inventory=50},
                new Product{Name="Chartreuse verte",         Price=18.00f, Inventory=50},
                new Product{Name="Cote de Blaye",            Price=263.00f,Inventory=50},
                new Product{Name="Guarana Fantastica",       Price=4.50f,  Inventory=50},
                new Product{Name="Ipoh Coffee",              Price=46.00f, Inventory=50},
                new Product{Name="Lakkalikoori",             Price=18.00f, Inventory=50},
                new Product{Name="Laughing Lumberjack Lager",Price=14.00f, Inventory=50}
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{ProductId=1,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001},
                new Order{ProductId=2,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001},
                new Order{ProductId=3,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001},
                new Order{ProductId=4,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001},
                new Order{ProductId=5,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001},
                new Order{ProductId=6,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001},
                new Order{ProductId=7,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001},
                new Order{ProductId=8,Quantity=10,Status=Order.OrderStatus.Pending,Notes="Notes",OrderNumber=001}
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();

            var invoices = new List<Invoice>
            {
                new Invoice{OrderNumber=001,TimePlaced=DateTime.Now,Total=500.00f},
                new Invoice{OrderNumber=002,TimePlaced=DateTime.Now,Total=550.00f},
                new Invoice{OrderNumber=003,TimePlaced=DateTime.Now,Total=200.00f},
                new Invoice{OrderNumber=004,TimePlaced=DateTime.Now,Total=100.00f},
                new Invoice{OrderNumber=005,TimePlaced=DateTime.Now,Total=670.00f}
            };
            invoices.ForEach(i => context.Invoices.Add(i));
            context.SaveChanges();

        }
    }
}
