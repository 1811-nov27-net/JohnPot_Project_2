using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private HttpClient Client;
        private Uri ServiceUri;

        public ProductController(Uri serviceUri, HttpClient client)
        {
            Client = client;
            ServiceUri = serviceUri;
        }

        public async Task<ActionResult> ProductIndex()
        {
            if(Product.Models.Count == 0)
            {
                var init = new Initialize();
                await init.Sync(Client, ServiceUri);
            }

            return View(Product.Models);
        }

        public async Task<ActionResult> Sync()
        {
            await Product.Sync(Client, ServiceUri);
            return RedirectToAction("ProductIndex", "Index");
        }
        
    }
}