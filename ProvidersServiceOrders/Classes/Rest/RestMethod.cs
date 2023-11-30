using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.Rest
{
    public class RestMethod
    {
        private readonly MethodBase _mb;
        private string _name;
        private object _inputData;
        private string _apiUri;
        private Type _returnType;
        public RestMethod(MethodBase mb)
        {
            _mb = mb;
        }
        public RestMethod Configure(object inputValue = null)
        {
            //Заполняем экземпляр класса данными
            _name = _mb.Name;
            AddArguement(inputValue);
            var type = ((MethodInfo)_mb).ReturnType;
            _returnType = (type == typeof(void)) ? typeof(object) : type;
            return this;
        }

        public RestMethod AddArguement(object inputValue = null)
        {
            var parameters = _mb.GetParameters();
            if (!parameters.Any())
            {
                _inputData = new object();
            }
            else
            {
                _inputData = inputValue;
            }
            return this;
        }

        public RestMethod AddApiUri(string uri)
        {
            _apiUri = uri;
            return this;
        }

        public object Execute(string uri = "")
        {
            //пытаемся получить uri для доступа к api
            if(uri.Equals(string.Empty)) 
            {
                if (_apiUri.Equals(string.Empty) || _apiUri.Equals(null))
                    throw new ArgumentException("Empty uri");
                else
                    uri = _apiUri;
            }
            //инициализируем RestClient конструкцией using, потому что он имплементирует IDisposable
            //и имеет в себе HttpClient, который нужно уничтожать
            using (var client = new RestClient() { ApiUri = uri })
            {
                //создаём инстанс Generic класса RestRequest
                var requestType = typeof(RestRequest<>).MakeGenericType(new Type[] { _inputData.GetType() });
                var request = Activator.CreateInstance(requestType);

                //заполняем поля таким интересным способом, поскольку до рантайма request не будет знать о том,
                //что он RestRequest
                request.GetType().GetRuntimeProperty("RestMethod").SetValue(request, _name);
                request.GetType().GetRuntimeProperty("Data").SetValue(request, _inputData);

                //Конфигурируем и вызываем Generic метод RestClient'а, используя в качестве аргумента заполненный request
                return client.GetType()
                    .GetMethod(nameof(RestClient.ExecuteRequest))
                    .MakeGenericMethod(new Type[] { _inputData.GetType(), _returnType })
                    .Invoke(client, new object[] { request });
            }
        }
    }
}
