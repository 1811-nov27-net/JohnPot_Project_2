using DataAccess;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST
{
    public class Repository
    {
        public ProductRepository ProductRepo;
        public OrderRepository OrderRepo;
        public InvoiceRepository InvoiceRepo;

        public Repository(OrderContext context)
        {
            ProductRepo = new ProductRepository(context);
            OrderRepo = new OrderRepository(context);
            InvoiceRepo = new InvoiceRepository(context);
        }

    }
}
