using System.Net.Http;

namespace ProvidersServiceOrders.Interfaces.HttpMethods
{
    public interface IHttpMethod
    {
        OutputDataType Execute<InputDataType, OutputDataType>(string uri, HttpClient client, InputDataType data);
    }
}