using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repo
{
    public class ProductRepository : IRepo<Product>
    {
        private OrderContext Context;
        public ProductRepository(OrderContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Context.Database.EnsureCreated();
        }

        public void Create(Product entity)
        {
            Context.Products.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            foreach (var p in Context.Products)
            {
                var entity = Context.Entry(p);
                entity.Reload();
                entity.State = EntityState.Detached;
            }

            Context.SaveChanges();

            return Context.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return Context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }
        
        public Product GetByName(string name)
        {
            return Context.Products.AsNoTracking().FirstOrDefault(p => p.Name == name);
        }

        public void Update(Product entity)
        {
            var p = Context.Products.Update(entity);
            Context.SaveChanges();
            p.State = EntityState.Detached;
        }
    }
}
