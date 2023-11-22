using Newtonsoft.Json;
using ProvidersServiceOrders.Classes;
using ProvidersServiceOrders.Interfaces;
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
        private readonly IRest _restService;
        public void SetDebugMode() { DisanOrdersGlobalSettings.InitDebug(); }
        public DisanOrders() 
        {
            DisanOrdersGlobalSettings.GetConfiguration();
            //инициализируем сервис для rest с помощью фабрики
            //надо проверить, что будет лучше работать, обычный
            //или generic сервис
            //а может вообще кто-то решится мою запутанную
            //систему переписать и сделает свой
            _restService = new RestFactory<ProdmasterProvidersServiceOrdersGeneric>().GetServiceInstance();
        }
        public OrderApiResponseModel CreateOrder(OrderApiModel order)
        {
            return _restService.CreateOrder(order);
        }
        public ArrayList GetOrders()
        {
            var orders = _restService.GetOrders();
            var list = new ArrayList();
            foreach (var order in orders)
            {
                list.Add(order);
            }
            return list;
        }

        public void ApproveOrders(OrderListManager listManager)
        {
            var orders = listManager.GetOrders();
            _restService.ApproveOrders(orders);
        }

        public void DeclineOrder(OrderApiModel order)
        {
            _restService.DeclineOrder(order);
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

        public int GetOrderStateValueByName(string name)
        {
            return (int)Enum.Parse(typeof(OrderState), name);
        }
    }
}
