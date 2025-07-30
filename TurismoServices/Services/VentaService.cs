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
            // Debes tener un endpoint en tu API que devuelva las ventas con detalles
            var response = await client.GetAsync($"{_endpoint}/registrosventas");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(content);

            return JsonSerializer.Deserialize<List<Venta>>(content, options);
        }

        public async Task<Venta> AddVentaAsync(Venta venta, List<RegistroVenta> registros)
        {
            venta.Registros = registros;
            var response = await client.PostAsJsonAsync(_endpoint, venta);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error API ({response.StatusCode}): {content}");

            return JsonSerializer.Deserialize<Venta>(content, options);
        }
    }
}
