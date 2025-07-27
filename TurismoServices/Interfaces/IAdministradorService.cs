using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoServices.Models;

namespace TurismoServices.Interfaces
{
    public interface IAdministradorService : IGenericService<Administrador>
    {
        public Task<List<Administrador>?> GetAllAsync(string? filtro);
        public Task<List<Administrador>?> GetAllDeletedAsync(string? filtro);

    }
}
