using TurismoServices.Interfaces;
using TurismoServices.Models;
using System.Text.Json;

namespace TurismoServices.Services
{
    public class ClienteService : GenericService<Cliente>, IClienteService
    {
        public async Task<List<Cliente>?> GetAllAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Cliente>>(content, options);
        }

        public async Task<List<Cliente>?> GetAllDeletedAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }

            //Deserializamos los clientes
            var clients = JsonSerializer.Deserialize<List<Cliente>>(content, options);

            //Filtramos los clientes eliminados (Eliminado = true)
            return clients?.Where(c => c.Eliminado).ToList();
        }
    }
}
