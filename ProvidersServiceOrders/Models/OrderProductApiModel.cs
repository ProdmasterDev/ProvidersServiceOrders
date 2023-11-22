using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Models
{
    public class OrderProductApiModel
    {
        public long? DisanId { get; set; }
        public long? StockId { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }


        public int GetDisanId()
        {
            return (int)DisanId;
        }
        public double GetQuantity()
        {
            return Quantity;
        }
        public void SetDisanId(int disanId)
        {
            DisanId = disanId;
        }

        public void SetStockId(int stockId)
        {
            StockId = stockId;
        }

        public void SetPrice(double price)
        {
            Price = price;
        }

        public void SetQuantity (double quantity)
        {
            Quantity = quantity;
        }
    }
}
