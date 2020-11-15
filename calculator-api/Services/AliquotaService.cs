using calculator_api.Models;
using calculator_api.Repository;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace calculator_api.Services
{
    public class AliquotaService : IAliquotaService, IDisposable
    {

        private readonly IAliquotaRepository _aliquotaRepository;        

        public AliquotaService(IAliquotaRepository aliquotaRepository)
        {
            _aliquotaRepository = aliquotaRepository;
        }

        public async Task<Aliquota> Get(decimal salarioMin, decimal rendaLiquida){
            var aliquotas = await _aliquotaRepository.GetAll();

            var fator = rendaLiquida / salarioMin;


            return aliquotas.FirstOrDefault(aliquotas => fator > aliquotas.SalarioMin && fator <= aliquotas.SalarioMax);
        }

        public async Task<IEnumerable<Aliquota>> GetAll()
        {
            return await _aliquotaRepository.GetAll();            
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (disposing)
            {
                _aliquotaRepository.Dispose();
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