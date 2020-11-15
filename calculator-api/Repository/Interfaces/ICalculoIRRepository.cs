using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Repository
{
    public interface ICalculoIRRepository : IDisposable
    {
        CalculoIR Save();

        Task<IEnumerable<CalculoIR>> SaveAll(IList<CalculoIR> calculos);

        Task<CalculoIR> Get(Guid id);

        Task<IList<CalculoIR>> GetAll();

        CalculoIR Update();

        bool Delete(Guid id);
    }
}
