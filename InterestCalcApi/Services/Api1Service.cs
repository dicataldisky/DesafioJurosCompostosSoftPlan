using InterestCalcApi.Helpers;
using InterestCalcApi.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InterestCalcApi.Services
{
    public class Api1Service : IApi1Service
    {
        public async Task<double> ObterTaxaDeJuros()
        {
            var result = await ApiHelper.GetAsync("Api1", Config.Api1Url);
            return JsonConvert.DeserializeObject<double>(result);
        }

    }
}
