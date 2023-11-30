using Newtonsoft.Json;
using System.Net.Http;

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
