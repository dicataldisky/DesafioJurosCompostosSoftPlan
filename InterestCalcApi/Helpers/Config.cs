using System.Net.Http;

namespace InterestCalcApi.Helpers
{
    public static class Config
    {
        public static string Api1Url { get; set; }
        public static string GitHubPath { get; set; }
        public static HttpClient TestClient { get; set; } = null;

    }
}
