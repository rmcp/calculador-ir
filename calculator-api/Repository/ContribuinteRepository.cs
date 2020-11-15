using calculator_api.Data;
using calculator_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Repository
{
    public class ContribuinteRepository : IContribuinteRepository, IDisposable
    {

        private CalculatorContext _context;

        public ContribuinteRepository(CalculatorContext context)
        {
            _context = context;
        }
        
        public async Task<Contribuinte> Get(Guid id)
        {
            return await _context.Contribuintes.FindAsync(id);
        }

        public async Task<IList<Contribuinte>> GetAll()
        {
            return await _context.Contribuintes.ToListAsync();
        }

        public async Task<Contribuinte> Save(Contribuinte contribuinte)
        {
            var contribuinteDb = _context.Contribuintes.FirstOrDefault(c => c.Cpf.Equals(contribuinte.Cpf));

            if (contribuinteDb != null)
            {
                contribuinteDb.Nome = contribuinte.Nome;
                contribuinteDb.Dependentes = contribuinte.Dependentes;
                contribuinteDb.Renda = contribuinte.Renda;
                _context.Entry(contribuinteDb).State = EntityState.Modified;
                contribuinte = contribuinteDb;
            }
            else
            {
                _context.Contribuintes.Add(contribuinte);
            }

            await _context.SaveChangesAsync();

            return contribuinte;
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
