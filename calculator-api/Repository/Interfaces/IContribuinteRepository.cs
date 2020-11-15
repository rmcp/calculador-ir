using calculator_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace calculator_api.Repository
{
    public interface IContribuinteRepository : IDisposable
    {   
        Task<Contribuinte> Get(Guid id);    
        Task<IList<Contribuinte>> GetAll();

        Task<Contribuinte> Save(Contribuinte contribuinte);
                
    }
}
