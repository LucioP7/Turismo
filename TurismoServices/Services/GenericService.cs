using System.Net.Http.Json;
using System.Text.Json;
using TurismoServices.Class;
using TurismoServices.Interfaces;

namespace TurismoServices.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
        // El error principal es que la interfaz IGenericService<T> define el método GetAllDeletedAsync(string? filtro),
        // pero la clase GenericService<T> solo implementa GetAllDeletedAsync() sin parámetro.
        // Debes agregar la implementación correcta con el parámetro 'filtro' para cumplir con la interfaz.
        // Además, hay problemas de posible acceso a null en UpdateAsync al acceder a la propiedad "Id" de entity sin validación.
        // Soy GitHub Copilot, un asistente de programación de IA. ¿En qué puedo ayudarte con el desarrollo de software?
    {
        protected readonly HttpClient client;
        protected readonly JsonSerializerOptions options;
        protected readonly string _endpoint;

        public GenericService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            string urlApi = Properties.Resources.UrlApi;
            if (Properties.Resources.Remoto == "false")
                urlApi = Properties.Resources.UrlApiLocal;

            _endpoint = urlApi + ApiEndpoints.GetEndpoint(typeof(T).Name);
        }

        public async Task<List<T>?> GetAllAsync(string? filtro = "")
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<T>>(content, options); ;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{_endpoint}/{id}");
            var content = await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<T>(content, options);
        }

        public async Task<T?> AddAsync(T? entity)
        {
            var response = await client.PostAsJsonAsync(_endpoint, entity);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error API ({response.StatusCode}): {content}");
            }

            return JsonSerializer.Deserialize<T>(content, options);
        }


        public async Task UpdateAsync(T? entity)
        {
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);

            var response = await client.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response?.ToString());
            }
        }

        public async Task<List<T>?> GetAllDeletedAsync(string? filtro = "")
        {
            var response = await client.GetAsync($"{_endpoint}/Eliminado?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }

            return JsonSerializer.Deserialize<List<T>>(content, options);
        }


        public async Task DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.ToString());
            }
        }
    }
}
 

        
// Errores detectados:
// 1. La interfaz IGenericService<T> define el método GetAllDeletedAsync(string?), pero la clase GenericService<T> solo implementa GetAllDeletedAsync() sin parámetro.
// 2. En UpdateAsync, entity puede ser null, lo que provoca CS8602 al intentar acceder a GetType().
// 3. En UpdateAsync, GetProperty("Id") puede devolver null si la propiedad no existe, lo que también provoca CS8602 al llamar a GetValue().

// Soluciones sugeridas:
// 1. Implementar correctamente GetAllDeletedAsync(string? filtro).
// 2. Validar que entity y la propiedad "Id" no sean null antes de acceder a ellas.
