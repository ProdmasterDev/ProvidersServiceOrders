using Newtonsoft.Json;
using ProvidersServiceOrders.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes
{
    public class DisanOrdersConfiguration
    {
        private readonly string _filePath;
        public WorkMod WorkMod { get; set; } = WorkMod.None;
        public ApiAddresses ApiAddresses { get; set; }
        public string ActualApiUri { get; set; } = "";
        public DisanOrdersConfiguration() { }
        public DisanOrdersConfiguration(string path) 
        {
            _filePath = path;
            if (!File.Exists(_filePath))
            {
                CreateConfigFile(null);
            }

            WorkMod = WorkMod.None;
            ApiAddresses = GetConfigFromFile();
            ActualApiUri = "";
        }

        public void SetWorkMod(WorkMod workMod)
        {
            WorkMod = workMod;
            ActualApiUri = ApiAddresses.GetAddressByWorkMod(workMod);
        }

        public void Save()
        {
            CreateConfigFile(this);
        }
        private ApiAddresses GetConfigFromFile()
        {
            using (StreamReader sr = new StreamReader(_filePath))
            {
                return JsonConvert.DeserializeObject<ApiAddresses>(sr.ReadToEnd());
            }
        }

        private void CreateConfigFile(DisanOrdersConfiguration config = null)
        {
            config = config ?? new DisanOrdersConfiguration()
            {
                ApiAddresses = new ApiAddresses(),
            };
            using (StreamWriter sw = new StreamWriter(_filePath, false))
            {
                sw.Write(JsonConvert.SerializeObject(config.ApiAddresses));
            }
        }
    }
}
