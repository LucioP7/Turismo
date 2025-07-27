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
    public class ItinerariosController : ControllerBase
    {
        private readonly TurismoContext _context;

        public ItinerariosController(TurismoContext context)
        {
            _context = context;
        }

        // GET: api/Itinerarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itinerario>>> GetItinerarios()
        {
            return await _context.Itinerarios.ToListAsync();
        }

        // GET: api/Itinerarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itinerario>> GetItinerarios(int id)
        {
            var Itinerarios = await _context.Itinerarios.FindAsync(id);

            if (Itinerarios == null)
            {
                return NotFound();
            }

            return Itinerarios;
        }

        // PUT: api/Itinerarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerarios(int id, Itinerario Itinerarios)
        {
            if (id != Itinerarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(Itinerarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerariosExists(id))
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

        // POST: api/Itinerarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itinerario>> PostItinerarios(Itinerario Itinerarios)
        {
            _context.Itinerarios.Add(Itinerarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerarios", new { id = Itinerarios.Id }, Itinerarios);
        }

        // DELETE: api/Itinerarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerarios(int id)
        {
            var Itinerarios = await _context.Itinerarios.FindAsync(id);
            if (Itinerarios == null)
            {
                return NotFound();
            }

            _context.Itinerarios.Remove(Itinerarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItinerariosExists(int id)
        {
            return _context.Itinerarios.Any(e => e.Id == id);
        }
    }
}
