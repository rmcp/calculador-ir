using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using calculator_api.Models;
using System.Net.Mime;
using calculator_api.Data;

namespace calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuinteController : ControllerBase
    {
        private readonly CalculatorContext _context;

        public ContribuinteController(CalculatorContext context)
        {
            _context = context;
        }

        // GET: api/Contribuite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribuinte>>> GetContribuintes()
        {
            return await _context.Contribuintes.ToListAsync();
        }

        // GET: api/Contribuite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuinte>> GetContribuinte(Guid id)
        {
            var contribuinte = await _context.Contribuintes.FindAsync(id);

            if (contribuinte == null)
            {
                return NotFound();
            }

            return contribuinte;
        }

        // PUT: api/Contribuite/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribuinte(Guid id, Contribuinte contribuinte)
        {
            if (id != contribuinte.Id)
            {
                return BadRequest();
            }

            _context.Entry(contribuinte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContribuinteExists(id))
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

        // POST: api/Contribuite
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Contribuinte>> PostContribuinte(Contribuinte contribuinte)
        {
            _context.Contribuintes.Add(contribuinte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContribuinte), new { id = contribuinte.Id }, contribuinte);
        }

        // DELETE: api/Contribuite/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contribuinte>> DeleteContribuinte(Guid id)
        {
            var contribuinte = await _context.Contribuintes.FindAsync(id);
            if (contribuinte == null)
            {
                return NotFound();
            }

            _context.Contribuintes.Remove(contribuinte);
            await _context.SaveChangesAsync();

            return contribuinte;
        }

        private bool ContribuinteExists(Guid id)
        {
            return _context.Contribuintes.Any(e => e.Id == id);
        }
    }
}
