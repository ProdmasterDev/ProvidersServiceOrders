using ProvidersServiceOrders.Classes.Attributes;
using ProvidersServiceOrders.Models;
using System.Collections.Generic;

namespace ProvidersServiceOrders.Interfaces
{
    public interface IRest
    {
        //названия методов должны совпадать с соответствующими названиями на сайте
        [HttpMethod("Post")]
        OrderApiResponseModel CreateOrder(OrderApiModel order);
        [HttpMethod("Post")]
        List<OrderApiModel> GetOrders();
        [HttpMethod("Post")]
        void ApproveOrders(List<OrderApiModel> orders);
        [HttpMethod("Post")]
        void DeclineOrder(OrderApiModel order);
    }
}
