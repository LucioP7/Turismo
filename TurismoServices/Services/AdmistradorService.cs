using System.Text.Json;
using TurismoServices.Interfaces;
using TurismoServices.Models;

namespace TurismoServices.Services
{
    public class AdmistradorService : GenericService<Administrador>, IAdministradorService
    {
        public async Task<List<Administrador>?> GetAllAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Administrador>>(content, options); ;
        }

        public async Task<List<Administrador>?> GetAllDeletedAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }

            //Deserializamos las actividades
            var administrators = JsonSerializer.Deserialize<List<Administrador>>(content, options);

            //Filtramos las actividades eliminadas (Eliminado = true)
            return administrators?.Where(a => a.Eliminado).ToList();
        }
    }
}
