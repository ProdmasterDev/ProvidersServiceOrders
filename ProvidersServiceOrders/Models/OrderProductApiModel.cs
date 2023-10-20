using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Models
{
    public class OrderProductApiModel
    {
        public long DisanId { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
