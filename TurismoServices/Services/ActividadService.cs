using System.Text.Json;
using TurismoServices.Interfaces;
using TurismoServices.Models;

namespace TurismoServices.Services
{
    public class ActividadService : GenericService<Actividad>, IActividadService
    {
        public async Task<List<Actividad>?> GetAllAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Actividad>>(content, options); ;
        }

        public async Task<List<Actividad>?> GetAllDeletedAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }

            //Deserializamos las actividades
            var activities = JsonSerializer.Deserialize<List<Actividad>>(content, options);

            //Filtramos las actividades eliminadas (Eliminado = true)
            return activities?.Where(a => a.Eliminado).ToList();
        }
    }
}
