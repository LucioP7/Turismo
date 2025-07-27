using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TurismoServices.Interfaces;
using TurismoServices.Models;
using TursimomServices.Interfaces;

namespace TurismoServices.Services
{
    public class ItinerarioService : GenericService<Itinerario>, IItinerarioService
    {
        public async Task<List<Itinerario>?> GetAllAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Itinerario>>(content, options); ;
        }

        public async Task<List<Itinerario>?> GetAllDeletedAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }

            // Deserializamos los itinerarios
            var itineraries = JsonSerializer.Deserialize<List<Itinerario>>(content, options);

            // Filtramos los itinerarios eliminados (Eliminado = true)
            return itineraries?.Where(i => i.Eliminado).ToList();
        }

    }
}
