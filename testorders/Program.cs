using ProvidersServiceOrders;
using ProvidersServiceOrders.Models;
using System;
using System.Collections.Generic;

namespace testorders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var api = new DisanOrders();
            api.SetDebugModeLocal();
            var orders = api.GetOrders();

            var orderList = api.GetListOfOrderApiModelInstance();
            foreach (var order in orders)
            {
                var orderToList = new OrderApiModel() { JrId = 675860101, Object = 6875301, JournalId = 1970516101, OrderState = OrderState.ConfirmedByProvider };
                orderList.AddOrder(orderToList);
            }
            api.ApproveOrders(orderList);

            //var order = new OrderApiModel()
            //{
            //    Date = DateTime.Now,
            //    JrId = 999,
            //    Object = 4420301,
            //    OrderState = OrderState.New,
            //    DeclineNote = "",
            //    ProductPart = new List<OrderProductApiModel> { new OrderProductApiModel() { DisanId = 1, Price = 1, Quantity = 2, StockId = 1, } },
            //    JournalId = 0
            //};

            //var s = api.CreateOrder(order);
        }
    }
}
