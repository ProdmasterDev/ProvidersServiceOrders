using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Models
{
    public class ApiAddresses
    {
        [JsonProperty("addresses")]
        public Dictionary<WorkMod, string> Addresses { get; set; } = new Dictionary<WorkMod, string>()
        {
            {WorkMod.ProdServer, "https://partner.prodmasterpro.ru/api" },
            {WorkMod.TestServer, "http://localhost:5656/api" },
            {WorkMod.TestLocal, "http://localhost:5022/api" },
        };

        public string GetAddressByWorkMod(WorkMod workMod)
        {
            var address = Addresses.FirstOrDefault(a => a.Key == workMod).Value;
            if (address == null) { return Addresses.First(a => a.Key == WorkMod.ProdServer).Value; }
            return Addresses.FirstOrDefault(a => a.Key == workMod).Value;
        }
    }
}
