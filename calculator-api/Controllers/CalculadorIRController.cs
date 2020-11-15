using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using calculator_api.DTO;
using calculator_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadorIRController : ControllerBase
    {
        private readonly ICalculadorIRService _calculadorService;

        public CalculadorIRController(ICalculadorIRService calculadorService)
        {
            _calculadorService = calculadorService;
        }

        // POST: api/Calcular
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<CalculoDTO>>> Calcular(IList<DadosCalculoDTO> dados)
        {
            try
            {
                var novosCalculos = await _calculadorService.Calcular(dados);                

                return novosCalculos.ToList();
            }            
            finally
            {
                _calculadorService.Dispose();
            }
            
        }
    }
}
