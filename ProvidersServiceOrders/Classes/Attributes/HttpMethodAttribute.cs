using ProvidersServiceOrders.Classes.HttpMethods;
using ProvidersServiceOrders.Interfaces.HttpMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.Attributes
{
    //описание кастомного аттрибута типов Http запросов методов
    [AttributeUsage(AttributeTargets.All)]
    public class HttpMethodAttribute : System.Attribute
    {
        private HttpMethod _method = new Post();
        public HttpMethodAttribute(string name)
        {
            if (name.Trim().ToUpper() == "GET")
            {
                _method = new Get();
            }
            if (name.Trim().ToUpper() == "POST")
            {
                _method = new Post();
            }
        }
        public virtual HttpMethod HttpMethod { get { return _method; } }
    }
}