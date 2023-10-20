using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Models
{
    public class Order
    {
        public long Id { get; set; }
        [JsonProperty("jridn")]
        public long JrId { get; set; }
        [JsonProperty("journalidn")]
        public long? JournalId { get; set; }
        [JsonProperty("object")]
        public long Object { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        public OrderState OrderState { get; set; } = OrderState.New;
        public string DeclineNote { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}