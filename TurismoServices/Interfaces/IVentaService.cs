using TurismoServices.Models;

namespace TurismoServices.Interfaces
{
    public interface IVentaService : IGenericService<Venta>
    {
        Task<List<Venta>> GetAllWithDetailsAsync();
        Task<Venta> AddVentaAsync(Venta venta, List<RegistroVenta> registros);
    }
}
