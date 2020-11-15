using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace calculator_api.Services
{
    public interface IAliquotaService :IDisposable
    {        
         Task<Aliquota> Get(decimal salarioMin, decimal rendaLiquida);

        Task<IEnumerable<Aliquota>> GetAll();
    }
}