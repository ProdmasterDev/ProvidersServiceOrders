using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Interfaces.HttpMethods
{
    public interface IHttpMethod
    {
        OutputDataType Execute<InputDataType, OutputDataType>(string uri, HttpClient client, InputDataType data);
    }
}
