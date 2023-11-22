using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.Rest
{
    public class RestClient : IDisposable
    {
        public string ApiUri { get; set; } = string.Empty;

        protected HttpClient Client { get; set; } = new HttpClient();
        public RestClient()
        {
            ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
        }
        public RestClient(string uri)
        {
            ApiUri = uri;
            ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
        }

        public OutputDataType ExecuteRequest<InputDataType, OutputDataType>(RestRequest<InputDataType> request)
        {
            return request.Execute<OutputDataType>(ApiUri, Client);
        }

        public object ExecuteRequestGeneric<InputDataType, OutputDataType>(object request)
        {
            return request.GetType()
                .GetRuntimeMethod("Execute", new Type[] { typeof(OutputDataType) })
                .MakeGenericMethod(new Type[] { typeof(OutputDataType) })
                .Invoke(this, new object[] { ApiUri, Client });
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
