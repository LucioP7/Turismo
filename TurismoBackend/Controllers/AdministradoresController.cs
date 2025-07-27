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
    public class AdministradoresController : ControllerBase
    {
        private readonly TurismoContext _context;

        public AdministradoresController(TurismoContext context)
        {
            _context = context;
        }

        // GET: api/Administradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
            return await _context.Administradores.ToListAsync();
        }

        // GET: api/Administradors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var Administrador = await _context.Administradores.FindAsync(id);

            if (Administrador == null)
            {
                return NotFound();
            }

            return Administrador;
        }

        // PUT: api/Administradors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador Administrador)
        {
            if (id != Administrador.Id)
            {
                return BadRequest();
            }

            _context.Entry(Administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administradors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador Administrador)
        {
            _context.Administradores.Add(Administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = Administrador.Id }, Administrador);
        }

        // DELETE: api/Administradors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var Administrador = await _context.Administradores.FindAsync(id);
            if (Administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(Administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
