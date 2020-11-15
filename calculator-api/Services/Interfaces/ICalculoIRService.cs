using calculator_api.DTO;
using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace calculator_api.Services
{
    public interface ICalculoIRService : IDisposable
    {        
        Task<CalculoIR> Get(Guid id);        

        Task<IEnumerable<CalculoDTO>> GetAll();

        Task<CalculoIR> Save(CalculoIR calculoIR);
        
        Task<IEnumerable<CalculoIR>> SaveAll(IEnumerable<CalculoIR> calculos);

    }
}