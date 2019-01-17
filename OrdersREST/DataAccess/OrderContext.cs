using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order>   Orders   { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

    }
}
