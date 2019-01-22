using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class InvoiceController : Controller
    {

        public async Task<ActionResult> InvoiceIndex()
        {

            return View(Invoice.Models);
        }

    }
}