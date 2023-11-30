using Newtonsoft.Json;
using ProvidersServiceOrders.Models.Base;
using System;

namespace ProvidersServiceOrders.Models
{
    public class Order : OrderBase
    {
        public long Id { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
        [JsonProperty("date")]
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}