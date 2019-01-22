
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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
            entity.Id = 0;
            Context.Orders.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            foreach (var p in Context.Orders)
            {
                var entity = Context.Entry(p);
                entity.Reload();
                entity.State = EntityState.Detached;
            }

            Context.SaveChanges();

            return Context.Orders.AsNoTracking().ToList();
        }

        public Order GetById(int id)
        {
            return Context.Orders.AsNoTracking().FirstOrDefault(o => o.Id == id);
        }

        public Order GetByProductId(int id)
        {
            var orders = Context.Orders.AsNoTracking().Where(o => o.ProductId == id);
            if(orders.Count() > 1)
            {
                var order = orders.AsNoTracking().FirstOrDefault(or => or.Status == Order.OrderStatus.Pending);
                if (order != null)
                    return order;
            }

            return orders.FirstOrDefault();
        }

        public void Update(Order entity)
        {
            var orderEntity = Context.Update(entity);
            Context.SaveChanges();
            orderEntity.State = EntityState.Detached;
        }
    }
}
