using DataAccess.Models;
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
            return Context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return Context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            Context.Products.Update(entity);
            Context.SaveChanges();
        }
    }
}
