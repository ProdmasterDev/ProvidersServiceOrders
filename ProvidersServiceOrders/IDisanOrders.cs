using ProvidersServiceOrders.Models;
using System.Collections;
using System.Collections.Generic;

namespace ProvidersServiceOrders
{
    public interface IDisanOrders
    {
        OrderApiResponseModel CreateOrder(OrderApiModel order);
        ArrayList GetOrders();
        void ApproveOrders(OrderListManager orders);
        void DeclineOrder(OrderApiModel order);
        OrderListManager GetListOfOrderApiModelInstance();
        OrderApiModel GetOrderApiModelInstance();
        string SerializeIntoJson(object o);
    }
}
