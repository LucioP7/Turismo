using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoServices.Interfaces;
using TurismoServices.Models;

namespace TursimomServices.Interfaces
{
    public interface IItinerarioService : IGenericService<Itinerario>
    {
        public Task<List<Itinerario>?> GetAllAsync(string? filtro);
        public Task<List<Itinerario>?> GetAllDeletedAsync(string? filtro);
    }


}
