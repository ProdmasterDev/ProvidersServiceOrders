using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersServiceOrders.Classes.HttpMethods
{
    public class Post : HttpMethod
    {
        public override OutputDataType Execute<InputDataType, OutputDataType>(string uri, HttpClient client, InputDataType data)
        {
            try
            {
                //иногда возникают проблемы с памятью, поэтому я решил прогонять 
                //Garbage Collector перед сериализацией, чтобы было побольше памяти и она была дефрагментирована
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                var json = JsonConvert.SerializeObject(data);
                var requestData = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, requestData);
                response.Wait();
                var responseRes = response.Result.Content.ReadAsStringAsync();
                responseRes.Wait();
                //и ещё разок для десериализации
                GC.Collect(1, GCCollectionMode.Forced, true, true);
                return JsonConvert.DeserializeObject<OutputDataType>(responseRes.Result);
            }
            catch (Exception ex)
            {
                using (var sw = new StreamWriter("ErrorLog_ProvidersServiceOrders.txt", true))
                {
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(ex.Message);
                    sw.WriteLine(ex.Source);
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine("-------------------------------------------");
                    sw.Close();
                }
                throw;
            }
        }
    }
}
