using ProvidersServiceOrders.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes
{
    public static class DisanOrdersGlobalSettings
    {
        private static DisanOrdersConfiguration _configuration = null;
        private static readonly string _filePath = $"{Directory.GetCurrentDirectory()}\\config.json";
        public static DisanOrdersConfiguration GetConfiguration()
        {
            _configuration = _configuration ?? new DisanOrdersConfiguration(_filePath);
            return _configuration;
        }
        public static void SetWorkMod(WorkMod workMod) 
        {
            _configuration.SetWorkMod(workMod);
        }
        public static void InitDebug()
        {
            _configuration.SetWorkMod(WorkMod.TestServer);
        }
        public static void InitDebugLocal()
        {
            _configuration.SetWorkMod(WorkMod.TestLocal);
        }
        public static void InitProd()
        {
            _configuration.SetWorkMod(WorkMod.ProdServer);
        }
    }
}
