using ProvidersServiceOrders.Classes.Extensions;
using ProvidersServiceOrders.Interfaces;
using ProvidersServiceOrders.Models;
using System.Collections.Generic;

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
            return this
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .Execute()
                .PerformTypeConversion<List<OrderApiModel>>();
        }

        public OrderApiResponseModel CreateOrder(OrderApiModel order)
        {
            return this
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .AddArguement(order)
                .Execute()
                .PerformTypeConversion<OrderApiResponseModel>();
        }

        public void ApproveOrders(List<OrderApiModel> orders)
        {
            this
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .AddArguement(orders)
                .Execute();
        }

        public void DeclineOrder(OrderApiModel order)
        {
            this
                .GetCurrentMethod()
                .Configure()
                .AddApiUri(DisanOrdersGlobalSettings.GetConfiguration().ActualApiUri)
                .AddArguement(order)
                .Execute();
        }
    }
}
