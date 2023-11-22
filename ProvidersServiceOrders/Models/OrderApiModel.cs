using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Models
{
    public class OrderApiModel
    {
        public long JrId { get; set; }
        public long JournalId { get; set; } = 0;
        public long Object { get; set; }
        public DateTime Date { get; set; }
        public string DeclineNote { get; set; } = string.Empty;

        public OrderState OrderState { get; set; } = OrderState.New;
        public List<OrderProductApiModel> ProductPart { get; set; } = new List<OrderProductApiModel>();

        public ArrayList GetOrderProductPart()
        {
            return new ArrayList(ProductPart);
        }
        public void SetJournalId(long journalId)
        {
            JournalId = journalId;
        }

        public int GetJrId()
        {
            return (int)JrId;
        }

        public void AddProduct(OrderProductApiModel product)
        {
            ProductPart.Add(product);
        }
    }
}
