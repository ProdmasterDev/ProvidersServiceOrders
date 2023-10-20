using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Models
{
    public class OrderListManager
    {
        private List<OrderApiModel> _orders;
        public OrderListManager() 
        {
            _orders = new List<OrderApiModel>();
        }
        public void AddOrder(OrderApiModel model)
        {
            _orders.Add(model);
        }
        public List<OrderApiModel> GetOrders()
        {
            return _orders;
        }
    }
}
