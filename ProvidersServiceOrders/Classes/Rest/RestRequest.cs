using ProvidersServiceOrders.Classes.Attributes;
using ProvidersServiceOrders.Classes.HttpMethods;
using ProvidersServiceOrders.Interfaces;
using ProvidersServiceOrders.Interfaces.HttpMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.Rest
{
    public class RestRequest<InputDataType>
    {
        public HttpMethods.HttpMethod Method { get; set; } = new Post();
        public InputDataType Data { get; set; } = default;
        private string _restMethod = string.Empty;
        public string RestMethod
        {
            get { return _restMethod; }
            set
            {
                //Перед тем как установить значение RestMethod проверяем, есть ли такой метод в интерфейсе
                var type = typeof(IRest);
                var methods = type.GetMethods();
                if (methods != null && methods.Length > 0)
                {
                    var method = methods.FirstOrDefault(m => m.Name == value);
                    if (method != null)
                    {
                        _restMethod = value;
                        //Вызываем метод, который по атрибуту метода получает тип Http запроса
                        Method = GetHttpMethodByRestMethod(method.ReturnType);
                    }
                }
            }
        }
        public ResponseType Execute<ResponseType>(string uri, HttpClient client)
        {
            //при инициализации RestMethod заполнялся тип http запроса (property Method), у каждого класса http запроса
            //есть метод Execute, который они наследуют от абстрактного класса HttpMethod
            return Method.Execute<InputDataType, ResponseType>($"{uri}/{RestMethod}", client, Data);
        }

        public HttpMethods.HttpMethod GetHttpMethodByRestMethod(Type t)
        {
            HttpMethodAttribute attribute = (HttpMethodAttribute)Attribute.GetCustomAttribute(t, typeof(HttpMethodAttribute));
            if (attribute == null)
            {
                return new Post();
            }
            else
            {
                return attribute.HttpMethod;
            }
        }
    }
}
