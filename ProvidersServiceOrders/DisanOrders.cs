using Newtonsoft.Json;
using ProvidersServiceOrders.Classes;
using ProvidersServiceOrders.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProvidersServiceOrders
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("1F1C97C3-A107-4563-A9A3-3DD0EDC05092")]
    [ProgId("ProvidersServiceOrders.DisanOrders")]
    [ComVisible(true)]
    public class DisanOrders : IDisanOrders
    {
        private bool _debug = false;
        public void SetDebugMode() { _debug = true; }
        public DisanOrders() { }
        public OrderApiResponseModel CreateOrder(OrderApiModel order)
        {
            var service = new ProdmasterProvidersServiceOrders(_debug);
            return service.CreateOrder(order);
        }

        public ArrayList GetOrders()
        {
            var service = new ProdmasterProvidersServiceOrders(_debug);
            var orders = service.GetOrders();
            var list = new ArrayList();
            foreach (var order in orders)
            {
                list.Add(order);
            }
            return list;
        }

        public void ApproveOrders(OrderListManager listManager)
        {
            var service = new ProdmasterProvidersServiceOrders(_debug);
            var orders = listManager.GetOrders();
            service.ApproveOrders(orders);
        }

        public void DeclineOrder(OrderApiModel order)
        {
            var service = new ProdmasterProvidersServiceOrders(_debug);
            service.DeclineOrder(order);
        }

        public OrderListManager GetListOfOrderApiModelInstance()
        {
            return new OrderListManager();
        }

        public OrderProductApiModel GetOrderProductApiModelInstance()
        {
            return new OrderProductApiModel();
        }

        public OrderApiModel GetOrderApiModelInstance()
        {
            return new OrderApiModel();
        }

        public string SerializeIntoJson(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
