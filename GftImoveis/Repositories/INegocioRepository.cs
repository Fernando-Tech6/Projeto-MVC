using System.Collections.Generic;
using System.Threading.Tasks;
using GftImoveis.Models;

namespace GftImoveis.Repositories
{
    public interface INegocioRepository
    {
        Task<List<Negocio>> ListaAsync();
         Task<Negocio> CreateAsync(Negocio negocio);
         Task<Negocio> GetAsync(int? id);
         Task<Negocio> UpdateAsync(Negocio negocio);
         Task<Negocio> DeleteAsync(Negocio negocio);
         Task<Negocio> SearchAsync(int? id);
         bool Exists(int id);
    }
}