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
        private const string URL = "https://fias.nalog.ru/WebServices/Public/GetAllDownloadFileInfo";
        private readonly HttpClient Client;

        public FIASClient()
        {
            Client = new HttpClient();
        }

        public async Task<List<FIASInfo>> GetAllDownloadFileInfo()
        {
            var HRM = await Client.GetAsync(URL);
            var Content = await HRM.Content.ReadAsStringAsync();

            var Info = JsonConvert.DeserializeObject<List<FIASInfo>>(Content);
            return Info;
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