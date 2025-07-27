using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurismoBackend.DataContext;
using TurismoServices.Models;

namespace TurismoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosController : ControllerBase
    {
        private readonly TurismoContext _context;

        public DestinosController(TurismoContext context)
        {
            _context = context;
        }

        // GET: api/Destinos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destino>>> GetDestinos()
        {
            return await _context.Destinos.ToListAsync();
        }

        // GET: api/Destinos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destino>> GetDestino(int id)
        {
            var Destino = await _context.Destinos.FindAsync(id);

            if (Destino == null)
            {
                return NotFound();
            }

            return Destino;
        }

        // PUT: api/Destinos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestino(int id, Destino Destino)
        {
            if (id != Destino.Id)
            {
                return BadRequest();
            }

            _context.Entry(Destino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoExists(id))
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

        // POST: api/Destinos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destino>> PostDestino(Destino Destino)
        {
            _context.Destinos.Add(Destino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestino", new { id = Destino.Id }, Destino);
        }

        // DELETE: api/Destinos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestino(int id)
        {
            var Destino = await _context.Destinos.FindAsync(id);
            if (Destino == null)
            {
                return NotFound();
            }

            _context.Destinos.Remove(Destino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinoExists(int id)
        {
            return _context.Destinos.Any(e => e.Id == id);
        }
    }
}
