using calculator_api.Data;
using calculator_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Repository
{
    public class AliquotaRepository : IAliquotaRepository, IDisposable
    {

        private CalculatorContext _context;

        public AliquotaRepository(CalculatorContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Aliquota>> GetAll()
        {
            return await _context.Aliquotas.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (disposing)
            {
                _context.Dispose();
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
