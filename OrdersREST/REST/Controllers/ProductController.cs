using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using DataAccess.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private Repository Repo;
        public ProductController(Repository repo)
        {
            Repo = repo;
        }

        [HttpPost]
        public void Post(Product product)
        {
            Repo.ProductRepo.Create(product);
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return Repo.ProductRepo.GetById(id);
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return Repo.ProductRepo.GetAll();
        }

        [HttpPut]
        public void Put(Product product)
        {
            Product p = Repo.ProductRepo.GetByName(product.Name);
            if(p != null)
            {
                product.Id = p.Id;
            }

            Repo.ProductRepo.Update(product);
        }

    }
}