using InterestCalcApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InterestCalcApi.Controllers
{
    [Route("")]
    [ApiController]
    public class API2Controller : ControllerBase
    {
        private readonly IApi2Service api2Service;

        public API2Controller(IApi2Service api2Service)
        {
            this.api2Service = api2Service;
        }

        [HttpGet("calculajuros")]
        [ProducesResponseType(typeof(decimal), 200)]
        public async Task<ActionResult> GetJuros(decimal valorInicial, int tempo)
        {            
            return Ok(await api2Service.CalcularJuros(valorInicial, tempo));
        }

        [HttpGet("showmethecode")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<ActionResult> GetCodeUrl()
        {
            return await Task<ActionResult>.Run(() =>
            {
                return Ok("https://github.com/dicataldisky/DesafioJurosCompostosSoftPlan");
            });
        }

    }
}
