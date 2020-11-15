using calculator_api.Data;
using calculator_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Repository
{
    public class CalculoIRRepository : ICalculoIRRepository, IDisposable
    {

        private CalculatorContext _context;

        public CalculoIRRepository(CalculatorContext context)
        {
            _context = context;
        }


        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CalculoIR> Get(Guid id)
        {
            return await _context.CalculoIRs.FindAsync(id);
        }

        public async Task<IList<CalculoIR>> GetAll()
        {
            return await _context.CalculoIRs.Include(c => c.Contribuinte).ToListAsync();
        }

        public CalculoIR Save()
        {
            throw new NotImplementedException();
        }

        public CalculoIR Update()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalculoIR>> SaveAll(IEnumerable<CalculoIR> calculos)
        {
            _context.CalculoIRs.AddRange(calculos);           
            
            await _context.SaveChangesAsync();

            return calculos;
            
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
