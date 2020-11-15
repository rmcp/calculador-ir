using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using calculator_api.Models;
using calculator_api.Services;
using calculator_api.DTO;

namespace calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoIRController : ControllerBase
    {        
        private readonly ICalculoIRService _calculoIRService;

        public CalculoIRController(ICalculoIRService calculoIRService)
        {
            _calculoIRService = calculoIRService;            
        }

        // GET: api/CalculoIR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculoDTO>>> GetCalculoIRs()
        {
            var novosCalculos = await _calculoIRService.GetAll();

            return novosCalculos.ToList();            
        }

        // GET: api/CalculoIR/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalculoIR>> GetCalculoIR(Guid id)
        {
            var calculoIR = await _calculoIRService.Get(id);

            if (calculoIR == null)
            {
                return NotFound();
            }

            return calculoIR;
        }       

    }
}
