using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC
{
    public class Initialize
    {

        public async Task Sync(HttpClient client, Uri serviceUri)
        {
            await Product.Sync(client, serviceUri);
            await Invoice.Sync(client, serviceUri);
            await Order.Sync(client, serviceUri);
        }
    }
}
