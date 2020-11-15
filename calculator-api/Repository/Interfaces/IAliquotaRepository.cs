using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Repository
{
    public interface IAliquotaRepository : IDisposable
    {        
        Task<IEnumerable<Aliquota>> GetAll();
    }
}
