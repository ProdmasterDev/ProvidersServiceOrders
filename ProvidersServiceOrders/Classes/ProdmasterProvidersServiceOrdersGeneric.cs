using Newtonsoft.Json;
using ProvidersServiceOrders.Classes.Extensions;
using ProvidersServiceOrders.Classes.Rest;
using ProvidersServiceOrders.Interfaces;
using ProvidersServiceOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes
{
    public class ProdmasterProvidersServiceOrdersGeneric : IRest
    {
        public ProdmasterProvidersServiceOrdersGeneric() { }

        //Расположенные ниже методы сначала используют мой Extension для класса MethodBase, который вызывает метод Configure у класса RestMethod, 
        //а дальше используется сам класс RestMethod, который берет данные откуда его вызывают и в соответствии с этим формирует вызовы Generic 
        //классов и методов для обращения к API

        public List<OrderApiModel> GetOrders()
        {
            return (List<OrderApiModel>)System.Reflection.MethodBase
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .Execute();
        }

        public OrderApiResponseModel CreateOrder(OrderApiModel order)
        {
            return (OrderApiResponseModel)System.Reflection.MethodBase
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .AddArguement(order)
                .Execute();
        }

        public void ApproveOrders(List<OrderApiModel> orders)
        {
            System.Reflection.MethodBase
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .AddArguement(orders)
                .Execute();
        }

        public void DeclineOrder(OrderApiModel order)
        {
            System.Reflection.MethodBase
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .AddArguement(order)
                .Execute();
        }
    }
}
