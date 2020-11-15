using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using calculator_api.Models;
using calculator_api.Services;

namespace calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliquotaController : ControllerBase
    {
        private readonly IAliquotaService _aliquotaService;

        public AliquotaController(IAliquotaService aliquotaService)
        {
            _aliquotaService = aliquotaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aliquota>> GetAliquotas()
        {
            return _aliquotaService.GetAll().Result.ToList();

        }


        // GET: api/Formula/5
        [HttpGet("{salarioMinimo}/{rendaLiquida}")]
        public async Task<ActionResult<Aliquota>> GetAliquota(decimal salarioMinimo, decimal rendaLiquida)
        {            

            var aliquota = await _aliquotaService.Get(salarioMinimo, rendaLiquida);

            if (aliquota == null)
            {
                return NotFound();
            }

            return aliquota;
        }
        
    }
}
