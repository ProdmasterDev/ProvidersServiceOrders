using ProvidersServiceOrders;
using ProvidersServiceOrders.Classes;
using ProvidersServiceOrders.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testorders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var api = new DisanOrders();
            api.SetDebugMode();
            var orders = api.GetOrders();

            var order = new OrderApiModel()
            {
                Date = DateTime.Now,
                JrId = 999,
                Object = 759900,
                OrderState = 0,
                DeclineNote = "",
                ProductPart = new List<OrderProductApiModel> { new OrderProductApiModel() { DisanId = 1, Price = 1, Quantity = 1, StockId = 1, } },
                JournalId = 0
            };

            var s = api.CreateOrder(order);
        }
    }
}
