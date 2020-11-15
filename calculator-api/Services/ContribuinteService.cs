using calculator_api.Models;
using calculator_api.Repository;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace calculator_api.Services
{
    public class ContribuinteService : IContribuinteService, IDisposable
    {

        private readonly IContribuinteRepository _contribuinteRepository;        

        public ContribuinteService(IContribuinteRepository contribuinteRepository)
        {
            _contribuinteRepository = contribuinteRepository;
        }

        public async Task<Contribuinte> Get(Guid id){
            return await _contribuinteRepository.Get(id);           
        }

        public async Task<Contribuinte> GetByCpf(string cpf){
            var contribuintes = await _contribuinteRepository.GetAll();        

            return contribuintes.FirstOrDefault(c => c.Cpf.Equals(cpf));
        }

        public async Task<IEnumerable<Contribuinte>> GetAll()
        {
            return await _contribuinteRepository.GetAll();            
        }

        public async Task<Contribuinte> Save(Contribuinte contribuinte)
        {
            return await _contribuinteRepository.Save(contribuinte);
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (disposing)
            {
                _contribuinteRepository.Dispose();
            }                           
        }
       
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        
    }
}