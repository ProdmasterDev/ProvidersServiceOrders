using ProvidersServiceOrders.Models.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProvidersServiceOrders.Models
{
    public class OrderApiModel : OrderBase
    {
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
