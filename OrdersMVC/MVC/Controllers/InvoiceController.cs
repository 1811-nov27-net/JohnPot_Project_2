using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private HttpClient Client;
        private Uri ServiceUri;

        public InvoiceController(Uri serviceUri, HttpClient client)
        {
            Client = client;
            ServiceUri = serviceUri;
        }

        public ActionResult InvoiceIndex()
        {
            return View(Invoice.Models);
        }

        public ActionResult InvoiceView(int id)
        {
            return View(Invoice.GetById(id));
        }

        public async Task<ActionResult> Sync()
        {
            await Invoice.Sync(Client, ServiceUri);
            return RedirectToAction("InvoiceIndex", "Invoice");
        }

    }
}