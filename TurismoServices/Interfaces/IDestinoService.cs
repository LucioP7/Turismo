using TurismoServices.Models;

namespace TurismoServices.Interfaces
{
    public interface IDestinoService : IGenericService<Destino>
    {
        public Task<List<Destino>> GetAllAsync(string? filtro);
        public Task<List<Destino>?> GetAllDeletedAsync(string? filtro);

    }
}
