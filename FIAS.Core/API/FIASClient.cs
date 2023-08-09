using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIAS.Core.API
{
    /// <summary>
    /// Клиент для API ФИАС
    /// </summary>
    public class FIASClient : IDisposable
    {
        private readonly HttpClient Client;
        private readonly Uri Endpoint = new Uri("https://fias.nalog.ru/WebServices/Public/");

        public FIASClient()
        {
            Client = new HttpClient { BaseAddress = Endpoint };
        }

        /// <summary>
        /// Получить список всех архивов
        /// </summary>
        /// <returns></returns>
        public async Task<List<FIASInfo>> GetAllDownloadFileInfo()
        {
            using (var HRM = await Client.GetAsync("GetAllDownloadFileInfo"))
            {
                var Content = await HRM.Content.ReadAsStringAsync();
                var Info = JsonConvert.DeserializeObject<List<FIASInfo>>(Content);
                return Info;
            }
        }

        /// <summary>
        /// Получить список архивов после указанной даты
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<List<FIASInfo>> GetAllDownloadFileInfo(DateTime date)
        {
            var Info = await GetAllDownloadFileInfo();
            return Info.Where(I => I.Date > date).ToList();
        }

        /// <summary>
        /// Получить список архивов после указанной версии
        /// </summary>
        /// <param name="version">Версия</param>
        /// <returns></returns>
        public async Task<List<FIASInfo>> GetAllDownloadFileInfo(int version)
        {
            var Info = await GetAllDownloadFileInfo();
            return Info.Where(I => I.VersionId > version).ToList();
        }

        #region IDisposable Support

        public void Dispose() => Client.Dispose();

        #endregion IDisposable Support
    }
}