using ProvidersServiceOrders.Interfaces.HttpMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.HttpMethods
{
    public abstract class HttpMethod : IHttpMethod
    {
        public abstract OutputDataType Execute<InputDataType, OutputDataType>(string uri, HttpClient client, InputDataType data);
    }
}
