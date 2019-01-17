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
        public Order Get(int id)
        {
            return Repo.OrderRepo.GetById(id);
        }
        [HttpGet]
        public List<Order> Get()
        {
            return Repo.OrderRepo.GetAll();
        }

        [HttpPut]
        public void Put(Order order)
        {
            Repo.OrderRepo.Update(order);
        }

    }
}