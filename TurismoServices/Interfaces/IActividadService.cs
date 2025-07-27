using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoServices.Models;

namespace TurismoServices.Interfaces
{
    public interface IActividadService : IGenericService<Actividad>
    {
        public Task<List<Actividad>?> GetAllAsync(string? filtro);
        public Task<List<Actividad>?> GetAllDeletedAsync(string? filtro);

    }
}
