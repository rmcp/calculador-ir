using calculator_api.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace calculator_api.Services
{
    public interface ICalculadorIRService : IDisposable
    {
        Task<IEnumerable<CalculoDTO>> Calcular(IList<DadosCalculoDTO> dados);
        
    }
}