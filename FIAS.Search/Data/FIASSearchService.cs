using FIAS.API;
using FIAS.API.Models;

namespace FIAS.Search.Data
{
    public class FIASSearchService
    {
        private readonly FIASStore Store = new();

        public Task<List<FIASRegistryAddress>> Search(string s)
        {
            return Store.Search(API.Enums.FIASDivision.mun, s, null, null);
        }
    }
}