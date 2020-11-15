using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using calculator_api.Models;
using calculator_api.Repository;
using calculator_api.Data;

namespace calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoIRController : ControllerBase
    {
        private readonly CalculatorContext _context;
        private readonly ICalculoIRRepository _calculadorIRRepository;

        public CalculoIRController(CalculatorContext context)
        {
            _context = context;

            _calculadorIRRepository = new CalculoIRRepository(_context);
        }

        // GET: api/CalculoIR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculoIR>>> GetCalculoIRs()
        {
            return await _context.CalculoIRs.ToListAsync();
        }

        // GET: api/CalculoIR/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalculoIR>> GetCalculoIR(Guid id)
        {
            var calculoIR = await _context.CalculoIRs.FindAsync(id);

            if (calculoIR == null)
            {
                return NotFound();
            }

            return calculoIR;
        }

        // PUT: api/CalculoIR/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculoIR(Guid id, CalculoIR calculoIR)
        {
            if (id != calculoIR.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculoIR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculoIRExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CalculoIR
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CalculoIR>> PostCalculoIR(CalculoIR calculoIR)
        {
            _context.CalculoIRs.Add(calculoIR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculoIR", new { id = calculoIR.Id }, calculoIR);
        }

        // DELETE: api/CalculoIR/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CalculoIR>> DeleteCalculoIR(Guid id)
        {
            var calculoIR = await _context.CalculoIRs.FindAsync(id);
            if (calculoIR == null)
            {
                return NotFound();
            }

            _context.CalculoIRs.Remove(calculoIR);
            await _context.SaveChangesAsync();

            return calculoIR;
        }

        private bool CalculoIRExists(Guid id)
        {
            return _context.CalculoIRs.Any(e => e.Id == id);
        }
    }
}
