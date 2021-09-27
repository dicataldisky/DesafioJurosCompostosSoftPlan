using InterestCalcApi.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InterestCalcApi.Helpers
{
    public static class ApiHelper
    {
        public static async Task<string> GetAsync(string apiName, string requestAddress)
        {
            string result = null;
            using (var client = Config.TestClient ?? new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(requestAddress))
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = responseContent;
                        }
                        else
                        {
                            throw new BusinessException($"Erro consultando API {apiName}: {responseContent}");
                        }
                    }
                }
                catch (Exception)
                {
                    throw new BusinessException($"Erro consultando API {apiName}: Não foi possível conectar ao endereço { requestAddress.ToString() }");
                }
            }
            return result;
        }

    }
}
