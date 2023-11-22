using ProvidersServiceOrders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes
{
    public class RestFactory<ServiceClass> where ServiceClass : class, IRest, new()
    {
        public RestFactory() { }
        public IRest GetServiceInstance() { return new ServiceClass(); }
    }
}
