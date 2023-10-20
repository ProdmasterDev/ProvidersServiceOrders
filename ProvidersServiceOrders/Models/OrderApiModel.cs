using System;
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
        public List<OrderProductApiModel> ProductPart { get; set; } = new List<OrderProductApiModel>();
        public void SetJournalId(long journalId)
        {
            JournalId = journalId;
        }
    }
}
