using System.Text.Json;
using TurismoServices.Interfaces;
using TurismoServices.Models;

namespace TurismoServices.Services
{
    public class DestinoService : GenericService<Destino>, IDestinoService
    {
        public async Task<List<Destino>?> GetAllAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Destino>>(content, options);
        }

        public async Task<List<Destino>?> GetAllDeletedAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }

            //Deserializamos los destinos
            var destinations = JsonSerializer.Deserialize<List<Destino>>(content, options);

            //Filtramos los destinos eliminados (Eliminado = true)
            return destinations?.Where(d => d.Eliminado).ToList();
        }
    }
}
