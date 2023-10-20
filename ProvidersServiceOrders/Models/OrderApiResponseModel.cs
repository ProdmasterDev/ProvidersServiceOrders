using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Models
{
    public class OrderApiResponseModel
    {
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
        [JsonProperty("personalTempLink")]
        public string PersonalTempLink { get; set; } = string.Empty;
        [JsonProperty("linkExpirationTime")]
        public DateTime LinkExpirationTime { get; set; } = DateTime.Now;


        public OrderApiResponseModel() { }
        public OrderApiResponseModel(Order order)
        {
            if (order.Token != null)
            {
                Token = order.Token;
                PersonalTempLink = $"https://partner.prodmasterpro.ru/order/vieworderanonymous?token={order.Token}";
            }
            LinkExpirationTime = order.CreatedAt + TimeSpan.FromDays(1);
        }
    }
}
