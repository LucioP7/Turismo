using TurismoServices.Models;

namespace TurismoServices.Interfaces
{
    public interface IClienteService : IGenericService<Cliente>
    {
        public Task<List<Cliente>> GetAllAsync(string? filtro);
        public Task<List<Cliente>?> GetAllDeletedAsync(string? filtro);

    }
}
