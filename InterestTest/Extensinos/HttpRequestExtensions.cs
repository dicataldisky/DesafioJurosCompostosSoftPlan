using InterestTest.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InterestTest.Extensinos
{
    public static class HttpRequestExtensions
    {
        private static  readonly Type StringType = typeof(string);

        public static async Task<RequestResult<T>> GetContentAsync<T>(this HttpClient client, string url)
        {
            Type itemType = typeof(T);
            var result = new RequestResult<T>() { ResultCode = HttpStatusCode.InternalServerError };
            try
            {
                using (var response = await client.GetAsync(url))
                {
                    result.ResultCode = response.StatusCode;
                    if (result.ResultCode == HttpStatusCode.OK)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (itemType == StringType)
                        {
                            var obj = (object)content;
                            result.Result = (T)obj;
                        }
                        else
                        {
                            try
                            {
                                result.Result = JsonConvert.DeserializeObject<T>(content);
                            }
                            catch(Exception ex)
                            {
                                result.Exception = ex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

    }
}
