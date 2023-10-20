using Newtonsoft.Json;
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
        #if DEBUG
                    public string ApiUri { get; set; } = "http://localhost:5656/api";
        #else
                public string ApiUri { get; set; } = "https://partner.prodmasterpro.ru/api";
        #endif


        public List<OrderApiModel> GetOrders()
        {
            var result = Execute<object, List<OrderApiModel>>(nameof(IRest.GetOrders), new object());
            if (result != null)
                return result;
            else
                return new List<OrderApiModel>();
        }

        public OrderApiResponseModel CreateOrder(OrderApiModel order)
        {
            var result = Execute<OrderApiModel, OrderApiResponseModel>(nameof(IRest.CreateOrder), order);
            if (result != null)
                return result;
            else
                return new OrderApiResponseModel();
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
            try
            {
                using (var client = new RestClient() { ApiUri = ApiUri })
                {
                    var request = new RestRequest<InputType>();
                    request.RestMethod = restMethodName;
                    request.Data = data;
                    return client.ExecuteRequest<InputType, OutputType>(request);
                }
            }
            catch (Exception)
            {
                throw;
                return default;
            }
        }
    }
}
