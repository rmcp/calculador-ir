using calculator_api.Models;
using calculator_api.Repository;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace calculator_api.Services
{
    public class CalculoIRService : ICalculoIRService, IDisposable
    {

        private readonly ICalculoIRRepository _calculoIRRepository;        

        public CalculoIRService(ICalculoIRRepository calculoIRRepository)
        {
            _calculoIRRepository = calculoIRRepository;
        }

        public async Task<CalculoIR> Get(Guid id){
            return await _calculoIRRepository.Get(id);           
        }        

        public async Task<IEnumerable<CalculoIR>> GetAll()
        {
            return await _calculoIRRepository.GetAll();            
        }

        Task<CalculoIR> ICalculoIRService.Save(CalculoIR calculoIR)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalculoIR>> SaveAll(IList<CalculoIR> calculos)
        {
            return await _calculoIRRepository.SaveAll(calculos);
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (disposing)
            {
                _calculoIRRepository.Dispose();
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