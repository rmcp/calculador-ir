using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using calculator_api.Models;
using calculator_api.Services;
using calculator_api.DTO;
using Microsoft.Extensions.Logging;
using calculator_api.Extensions;

namespace calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoIRController : ControllerBase
    {        
        private readonly ICalculoIRService _calculoIRService;
        private readonly ILogger<CalculoIRController> _logger;

        public CalculoIRController(ICalculoIRService calculoIRService, ILogger<CalculoIRController> logger)
        {
            _calculoIRService = calculoIRService;
            _logger = logger;
        }

        // GET: api/CalculoIR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculoDTO>>> GetCalculoIRs()
        {
            try
            {
                var novosCalculos = await _calculoIRService.GetAll();

                return novosCalculos.ToList();
            } catch (Exception ex)
            {
                _logger.LogCritical(ex, "Erro ao obter os calculos de impostos dos contribuintes informados");
                return StatusCode(500, "Erro ao obter os calculos de impostos dos contribuintes informados");
            }
            
        }

        // GET: api/CalculoIR/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalculoIR>> GetCalculoIR(Guid id)
        {

            try
            {
                var calculoIR = await _calculoIRService.Get(id);

                if (calculoIR == null)
                {
                    return NotFound();
                }

                return calculoIR;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Erro ao obter os calculos de impostos informado");
                return StatusCode(500, "Erro ao obter os calculos de impostos informado");
            }            
        }       

    }
}
