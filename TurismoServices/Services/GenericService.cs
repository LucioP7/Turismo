using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TurismoServices.Class;
using TurismoServices.Interfaces;

namespace TurismoServices.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly HttpClient client;
        protected readonly JsonSerializerOptions options;
        protected readonly string _endpoint;

        public GenericService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            string urlApi = Properties.Resources.UrlApi;
            if (Properties.Resources.Remoto == "false")
                urlApi = Properties.Resources.UrlApiLocal;

            _endpoint = urlApi.TrimEnd('/') + "/" + ApiEndpoints.GetEndpoint(typeof(T).Name.ToLower());
        }

        public async Task<List<T>?> GetAllAsync(string? filtro = "")
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(content);

            return JsonSerializer.Deserialize<List<T>>(content, options);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{_endpoint}/{id}");
            var content = await response.Content.ReadAsStreamAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error al obtener ID {id}: {response.StatusCode}");

            return JsonSerializer.Deserialize<T>(content, options);
        }

        public async Task<T?> AddAsync(T? entity)
        {
            var response = await client.PostAsJsonAsync(_endpoint, entity);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error al agregar: {content}");

            return JsonSerializer.Deserialize<T>(content, options);
        }

        public async Task UpdateAsync(T? entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var propertyInfo = entity.GetType().GetProperty("Id");
            if (propertyInfo == null)
                throw new InvalidOperationException("Entidad no tiene propiedad 'Id'.");

            var idValue = propertyInfo.GetValue(entity);
            if (idValue == null)
                throw new InvalidOperationException("No se puede obtener el valor del Id.");

            var response = await client.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error al actualizar: {response.StatusCode}");
        }

        public async Task<List<T>?> GetAllDeletedAsync(string? filtro = "")
        {
            var response = await client.GetAsync($"{_endpoint}/Eliminado?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(content);

            return JsonSerializer.Deserialize<List<T>>(content, options);
        }

        public async Task DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error al eliminar ID {id}: {response.StatusCode}");
        }
    }
}


//using System.Net.Http.Json;
//using System.Text.Json;
//using TurismoServices.Class;
//using TurismoServices.Interfaces;

//namespace TurismoServices.Services
//{
//    public class GenericService<T> : IGenericService<T> where T : class
//    {
//        protected readonly HttpClient client;
//        protected readonly JsonSerializerOptions options;
//        protected readonly string _endpoint;

//        public GenericService()
//        {
//            client = new HttpClient();
//            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

//            string urlApi = Properties.Resources.UrlApi;
//            if (Properties.Resources.Remoto == "false")
//                urlApi = Properties.Resources.UrlApiLocal;

//            _endpoint = urlApi + ApiEndpoints.GetEndpoint(typeof(T).Name);
//        }

//        public async Task<List<T>?> GetAllAsync(string? filtro = "")
//        {
//            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
//            var content = await response.Content.ReadAsStringAsync();
//            if (!response.IsSuccessStatusCode)
//            {
//                throw new ApplicationException(content?.ToString());
//            }
//            return JsonSerializer.Deserialize<List<T>>(content, options); ;
//        }

//        public async Task<T?> GetByIdAsync(int id)
//        {
//            var response = await client.GetAsync($"{_endpoint}/{id}");
//            var content = await response.Content.ReadAsStreamAsync();
//            if (!response.IsSuccessStatusCode)
//            {
//                throw new ApplicationException(content?.ToString());
//            }
//            return JsonSerializer.Deserialize<T>(content, options);
//        }

//        public async Task<T?> AddAsync(T? entity)
//        {
//            var response = await client.PostAsJsonAsync(_endpoint, entity);
//            var content = await response.Content.ReadAsStringAsync();

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new ApplicationException($"Error API ({response.StatusCode}): {content}");
//            }

//            return JsonSerializer.Deserialize<T>(content, options);
//        }


//        public async Task UpdateAsync(T? entity)
//        {
//            if (entity == null)
//                throw new ArgumentNullException(nameof(entity));

//            var propertyInfo = entity.GetType().GetProperty("Id");
//            if (propertyInfo == null)
//                throw new InvalidOperationException("Entidad no tiene propiedad 'Id'.");

//            var idValue = propertyInfo.GetValue(entity);

//            var response = await client.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
//            if (!response.IsSuccessStatusCode)
//            {
//                throw new ApplicationException(response?.ToString());
//            }
//        }

//        public async Task<List<T>?> GetAllDeletedAsync(string? filtro = "")
//        {
//            var response = await client.GetAsync($"{_endpoint}/Eliminado?filtro={filtro}");
//            var content = await response.Content.ReadAsStringAsync();

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new ApplicationException(content?.ToString());
//            }

//            return JsonSerializer.Deserialize<List<T>>(content, options);
//        }


//        public async Task DeleteAsync(int id)
//        {
//            var response = await client.DeleteAsync($"{_endpoint}/{id}");
//            if (!response.IsSuccessStatusCode)
//            {
//                throw new ApplicationException(response.ToString());
//            }
//        }
//    }
//}
