using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.HttpMethods
{
    public class Post : HttpMethod
    {
        public override OutputDataType Execute<InputDataType, OutputDataType>(string uri, HttpClient client, InputDataType data)
        {
            var json = JsonConvert.SerializeObject(data);
            var requestData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, requestData);
            response.Wait();
            var responseRes = response.Result.Content.ReadAsStringAsync();
            responseRes.Wait();
            return JsonConvert.DeserializeObject<OutputDataType>(responseRes.Result);
        }
    }
}
