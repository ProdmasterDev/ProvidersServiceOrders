using ProvidersServiceOrders.Models;
using System.Collections;
using System.Collections.Generic;

namespace ProvidersServiceOrders
{
    public interface IDisanOrders
    {
        void SetDebugMode();
        OrderApiResponseModel CreateOrder(OrderApiModel order);
        ArrayList GetOrders();
        void ApproveOrders(OrderListManager orders);
        void DeclineOrder(OrderApiModel order);
        OrderListManager GetListOfOrderApiModelInstance();
        OrderProductApiModel GetOrderProductApiModelInstance();
        OrderApiModel GetOrderApiModelInstance();
        string SerializeIntoJson(object o);
    }
}
