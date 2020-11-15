using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace calculator_api.Services
{
    public interface IContribuinteService : IDisposable
    {        
        Task<Contribuinte> Get(Guid id);

        Task<Contribuinte> GetByCpf(string cpf);

        Task<IEnumerable<Contribuinte>> GetAll();

        Task<Contribuinte> Save(Contribuinte contribuinte);

    }
}