using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repo
{
    public class OrderRepository : IRepo<Order>
    {
        public OrderContext Context;
        public OrderRepository(OrderContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Context.Database.EnsureCreated();
        }

        public void Create(Order entity)
        {
            Context.Orders.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return Context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return Context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Order entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
    }
}
