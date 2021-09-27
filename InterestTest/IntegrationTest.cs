using InterestTest.Extensinos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace InterestTest
{
    [TestClass]
    public class IntegrationTest
    {
        const string GitHubPath = "github.com";
        private TestServer serverApi1;
        private TestServer serverApi2;
        private HttpClient clientApi1;
        private HttpClient clientApi2;

        [TestInitialize]
        public void Initialize()
        {
            serverApi1 = new TestServer(new WebHostBuilder().UseStartup<InterestReturnApi.Startup>());
            serverApi2 = new TestServer(new WebHostBuilder().UseStartup<InterestCalcApi.Startup>());
            clientApi1 = serverApi1.CreateClient();
            clientApi2 = serverApi2.CreateClient();
            InterestCalcApi.Helpers.Config.GitHubPath = GitHubPath;
            InterestCalcApi.Helpers.Config.Api1Url = "/taxajuros";
            InterestCalcApi.Helpers.Config.TestClient = clientApi1;
        }


        [TestMethod]
        public async Task TestarObterJuros()
        {
            InterestCalcApi.Helpers.Config.GitHubPath = "";
            var response = await clientApi1.GetContentAsync<double>("/taxaJuros");
            Assert.IsNull(response.Exception, $"A requisição retornou uma exceção: {response.Exception?.Message}.");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.ResultCode, "A requisição obteve um código de status inválido.");
            Assert.AreEqual(0.01d, response.Result, "A taxa de juros obtida está incorreta.");
        }

        [TestMethod]
        public async Task TestarCalcularJuros()
        {
            var response = await clientApi2.GetContentAsync<decimal>("/calculajuros?valorInicial=100&tempo=5");
            Assert.IsNull(response.Exception, $"A requisição retornou uma exceção: {response.Exception?.Message}.");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.ResultCode, "A requisição obteve um código de status inválido.");
            Assert.AreEqual(105.1m, response.Result, "O valor calculado dos juros está incorreto.");
        }

        [TestMethod]
        public async Task TestarShowMeTheCode()
        {
            var response = await clientApi2.GetContentAsync<string>("/showmethecode");
            Assert.IsNull(response.Exception, $"A requisição retornou uma exceção: {response.Exception?.Message}.");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.ResultCode, "A requisição obteve um código de status inválido.");
            var isValid = response.Result.Contains(GitHubPath);
            Assert.IsTrue(isValid, "O resultado obtido não é uma URL do Github.");
        }

    }
}
