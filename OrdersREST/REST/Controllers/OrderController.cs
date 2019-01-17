using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using REST.Models;
using DataAccess.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private Repository Repo;

        public OrderController(Repository repo)
        {
            Repo = repo;
        }

        [HttpPost]
        public void Post(Order order)
        {
            Repo.OrderRepo.Create(order);
        }

        [HttpGet("{id}")]
        public OrderView Get(int id)
        {
            return OrderView.Map(Repo.OrderRepo.GetById(id), Repo);
        }
        [HttpGet]
        public List<OrderView> Get()
        {
            List<Order> dbOrders = Repo.OrderRepo.GetAll();

            return Repo.OrderRepo.GetAll().Select(o => OrderView.Map(o, Repo)).ToList();
        }

        [HttpPut]
        public void Put(Order order)
        {
            Repo.OrderRepo.Update(order);
        }

    }
}