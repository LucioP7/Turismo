using System.Net.Http.Json;
using System.Text.Json;
using TurismoServices.Interfaces;
using TurismoServices.Models;

namespace TurismoServices.Services
{
    public class VentaService : GenericService<Venta>, IVentaService
    {
        public VentaService() : base() { }

        public async Task<List<Venta>> GetAllWithDetailsAsync()
        {
            // Cambiado: usa el endpoint principal que ya incluye detalles
            var response = await client.GetAsync($"{_endpoint}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error al obtener ventas: {content}");

            return JsonSerializer.Deserialize<List<Venta>>(content, options)
                ?? new List<Venta>();
        }

        public async Task<Venta> AddVentaAsync(Venta venta, List<DetalleVenta> registros)
        {
            venta.DetallesVenta = registros;

            var response = await client.PostAsJsonAsync(_endpoint, venta);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error API ({response.StatusCode}): {content}");

            return JsonSerializer.Deserialize<Venta>(content, options)!;
        }
    }
}
