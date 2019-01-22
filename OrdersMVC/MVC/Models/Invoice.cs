using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Invoice
    {
        public List<Order> Orders
        {
            get
            {
                return Order.GetByNumber(OrderNumber);
            }
        }

        public int OrderNumber { get; set; }
        public DateTime TimePlaced { get; set; }
        [DataType(DataType.Currency)]
        public float Total { get; set; }

        public static List<Invoice> Models = new List<Invoice>();

        public Invoice()
        {
            Id = NextId;
            Models.Add(this);
        }

        public int Id { get; set; }
        public static int NextId { get => (Models.Count <= 0) ? 1 : Models.Max(m => m.Id) + 1; }
        public string Name { get; set; }

        public static Invoice GetById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }
        public static Invoice GetByName(string name)
        {
            if (name == null)
                return null;

            return Models.FirstOrDefault(m => m.Name == name);
        }
        public static Invoice GetByNumber(int number)
        {
            return Models.FirstOrDefault(m => m.OrderNumber == number);
        }

        public async static Task Sync(HttpClient client, Uri serviceUri)
        {

            HttpResponseMessage response = await client.GetAsync(new Uri(serviceUri, "Invoice"));

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Handle error
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            Invoice.Models.Clear();
            List<Invoice> db_Invoices = JsonConvert.DeserializeObject<List<Invoice>>(responseBody);
            Invoice.Models = db_Invoices;
        }
    }
}
