using Adess.Padron.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adess.Padron.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadronController : ControllerBase
    {
        private readonly IPadronService _padronService;
        public PadronController(IPadronService padronService)
        {
            _padronService = padronService;
        }

        [HttpPost(Name = "GetPadron")]
        public async Task<IActionResult> GetPadron(string cedula)
        {
            var guiId = Guid.NewGuid().ToString();

            return Ok(await _padronService.GetPadronInfo(cedula));
        }

        //[HttpPost(Name = "ProcesarCedulas")]
        //public async Task<IActionResult> Procesar()
        //{
        //    return Ok(await _padronService.Procesar());
        //}

    }
}
