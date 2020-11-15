using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace calculator_api.Services
{
    public interface ICalculoIRService : IDisposable
    {        
        Task<CalculoIR> Get(Guid id);        

        Task<IEnumerable<CalculoIR>> GetAll();

        Task<CalculoIR> Save(CalculoIR calculoIR);
        
        Task<IEnumerable<CalculoIR>> SaveAll(IList<CalculoIR> calculos);

    }
}