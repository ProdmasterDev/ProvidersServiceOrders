using Newtonsoft.Json;
using ProvidersServiceOrders.Classes.Extensions;
using ProvidersServiceOrders.Classes.Rest;
using ProvidersServiceOrders.Interfaces;
using ProvidersServiceOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes
{
    public class ProdmasterProvidersServiceOrders : IRest
    {
        public ProdmasterProvidersServiceOrders() { }

        public List<OrderApiModel> GetOrders()
        {
            return Execute<object, List<OrderApiModel>>(nameof(IRest.GetOrders), new object()) ?? new List<OrderApiModel>();
        }

        public OrderApiResponseModel CreateOrder(OrderApiModel order)
        {
            return Execute<OrderApiModel, OrderApiResponseModel>(nameof(IRest.CreateOrder), order) ?? new OrderApiResponseModel();
        }

        public void ApproveOrders(List<OrderApiModel> orders)
        {
            Execute<List<OrderApiModel>, object>(nameof(IRest.ApproveOrders), orders);
        }

        public void DeclineOrder(OrderApiModel order)
        {
            Execute<OrderApiModel, object>(nameof(IRest.DeclineOrder), order);
        }

        private OutputType Execute<InputType, OutputType>(string restMethodName, InputType data)
        {
            using (var client = new RestClient() { ApiUri = DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri })
            {
                var request = new RestRequest<InputType>();
                request.RestMethod = restMethodName;
                request.Data = data;
                return client.ExecuteRequest<InputType, OutputType>(request);
            }
        }
    }
}
