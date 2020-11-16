using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using calculator_api.DTO;
using calculator_api.Extensions;
using calculator_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadorIRController : ControllerBase
    {
        private readonly ICalculadorIRService _calculadorService;
        private readonly ILogger<CalculadorIRController> _logger;


        public CalculadorIRController(ICalculadorIRService calculadorService, ILogger<CalculadorIRController> logger)
        {
            _calculadorService = calculadorService;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Erro ao calcular o imposto dos contribuintes informados");
                return StatusCode(500, "Error ao obter os calculos de imposto de rendas.");
            }
            finally
            {
                _calculadorService.Dispose();
            }
            
        }
    }
}
