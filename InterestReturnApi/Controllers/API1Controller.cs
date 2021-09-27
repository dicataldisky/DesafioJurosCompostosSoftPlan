using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InterestReturnApi.Controllers
{
    [Route("")]
    [ApiController]
    public class API1Controller : ControllerBase
    {

        [HttpGet("taxaJuros")]
        [ProducesResponseType(typeof(double), 200)]
        public async Task<ActionResult> GetTaxa()
        {
            return Ok(await Task.Run<double>(() =>
            {
                return 0.01d;
            }));
        }

    }
}
