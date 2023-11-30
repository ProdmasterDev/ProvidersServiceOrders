using ProvidersServiceOrders.Classes.Rest;
using ProvidersServiceOrders.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ProvidersServiceOrders.Classes.Extensions
{
    //Extension для MethodBase, чтобы можно было красивее и проще создавать экземпляр RestMethod
    public static class RestMethodHelper
    {
        public static RestMethod Configure(this MethodBase method, object inputValue = null)
        {
            return new RestMethod(method).Configure(inputValue);
        }
        public static MethodBase GetCurrentMethod(this IRest rest, [CallerMemberName] string memberName = "")
        {
            return MethodBase.GetMethodFromHandle(rest.GetType().GetMethods().First(m => m.Name == memberName).MethodHandle);
        }
        public static ReturnType PerformTypeConversion<ReturnType>(this object obj)
        {
            return (ReturnType)obj;
        }
    }
}