using ProvidersServiceOrders.Classes.Rest;
using System.Reflection;

namespace ProvidersServiceOrders.Classes.Extensions
{
    //Extension для MethodBase, чтобы можно было красивее и проще создавать экземпляр RestMethod
    public static class RestMethodHelper
    {
        public static RestMethod Configure(this MethodBase method, object inputValue = null)
        {
            return new RestMethod(method).Configure(inputValue);
        }
    }
}