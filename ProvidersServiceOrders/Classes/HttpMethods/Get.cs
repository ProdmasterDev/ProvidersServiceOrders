using Newtonsoft.Json;
using ProvidersServiceOrders.Interfaces.HttpMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.HttpMethods
{
    public class Get : HttpMethod
    {
        public override OutputDataType Execute<InputDataType, OutputDataType>(string uri, HttpClient client, InputDataType data)
        {
            var response = client.GetStringAsync(uri);
            response.Wait();

            return JsonConvert.DeserializeObject<OutputDataType>(response.Result);
        }
    }
}
