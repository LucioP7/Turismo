using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurismoServices.Models;
using TurismoBackend.DataContext;
using System.Text.Json.Serialization;

namespace TurismoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly TurismoContext _context;

        public VentasController(TurismoContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Itinerario).ThenInclude(i => i.Destino)
                .Include(v => v.Actividad)
                .Include(v => v.DetallesVenta)
                    .ThenInclude(dv => dv.Destino)
                .Include(v => v.DetallesVenta)
                    .ThenInclude(dv => dv.Actividad)
                .Include(v => v.DetallesVenta)
                    .ThenInclude(dv => dv.Itinerario)
                .ToListAsync();
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Itinerario).ThenInclude(i => i.Destino)
                .Include(v => v.Actividad)
                .Include(v => v.DetallesVenta)
                    .ThenInclude(dv => dv.Destino)
                .Include(v => v.DetallesVenta)
                    .ThenInclude(dv => dv.Actividad)
                .Include(v => v.DetallesVenta)
                    .ThenInclude(dv => dv.Itinerario)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
                return NotFound();

            return venta;
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
        }

        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.Id)
                return BadRequest();

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ventas.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
                return NotFound();

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Ventas/Filtrar?IdCliente=1&destinoId=2
        [HttpGet("Filtrar")]
        public async Task<ActionResult<IEnumerable<Venta>>> FiltrarVentas([FromQuery] int? IdCliente, [FromQuery] int? destinoId)
        {
            var query = _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Itinerario).ThenInclude(i => i.Destino)
                .Include(v => v.Actividad)
                .Include(v => v.DetallesVenta)
                    .ThenInclude(dv => dv.Destino)
                .AsQueryable();

            if (IdCliente.HasValue)
                query = query.Where(v => v.IdCliente == IdCliente.Value);

            if (destinoId.HasValue)
                query = query.Where(v =>
                    v.Itinerario.IdDestino == destinoId.Value ||
                    v.DetallesVenta.Any(dv => dv.IdDestino == destinoId.Value));

            return await query.ToListAsync();
        }
    }
}
