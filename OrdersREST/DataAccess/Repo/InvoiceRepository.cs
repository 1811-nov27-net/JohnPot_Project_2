using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repo
{
    public class InvoiceRepository : IRepo<Invoice>
    {
        public OrderContext Context;
        public InvoiceRepository(OrderContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Context.Database.EnsureCreated();
        }

        public void Create(Invoice entity)
        {
            Context.Invoices.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAll()
        {
            return Context.Invoices.ToList();
        }

        public Invoice GetById(int id)
        {
            return Context.Invoices.FirstOrDefault(i => i.Id == id);
        }

        public void Update(Invoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
