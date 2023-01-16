using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIAS.Core.API
{
    public class FIASClient : IDisposable
    {
        private readonly HttpClient Client;
        private readonly Uri Endpoint = new Uri("https://fias.nalog.ru/WebServices/Public/");

        public FIASClient()
        {
            Client = new HttpClient() { BaseAddress = Endpoint };
        }

        public async Task<List<FIASInfo>> GetAllDownloadFileInfo()
        {
            using (var HRM = await Client.GetAsync("GetAllDownloadFileInfo"))
            {
                var Content = await HRM.Content.ReadAsStringAsync();
                var Info = JsonConvert.DeserializeObject<List<FIASInfo>>(Content);
                return Info;
            }
        }

        public async Task<List<FIASInfo>> GetAllDownloadFileInfo(DateTime Date)
        {
            var Info = await GetAllDownloadFileInfo();
            return Info.Where(I => I.Date >= Date).ToList();
        }

        #region IDisposable Support

        public void Dispose() => Client.Dispose();

        #endregion IDisposable Support
    }
}