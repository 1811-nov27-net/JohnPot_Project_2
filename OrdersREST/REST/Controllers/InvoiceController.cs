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
    public class InvoiceController : ControllerBase
    {
        private Repository Repo;
        public InvoiceController(Repository repo)
        {
            Repo = repo;

        }

        [HttpPost]
        public void Post(Invoice invoice)
        {
            Repo.InvoiceRepo.Create(invoice);
        }

        [HttpGet("{id}")]
        public Invoice Get(int id)
        {
            Invoice i = Repo.InvoiceRepo.GetById(id);
            return Repo.InvoiceRepo.GetById(id);
        }

        [HttpGet]
        public List<Invoice> Get()
        {
            return Repo.InvoiceRepo.GetAll();
        }
        
    }
}