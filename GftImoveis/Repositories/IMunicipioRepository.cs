using System.Collections.Generic;
using System.Threading.Tasks;
using GftImoveis.Models;

namespace GftImoveis.Repositories
{
    public interface IMunicipioRepository
    {
         Task<List<Municipio>> ListaAsync();
         Task<Municipio> CreateAsync(Municipio municipio);
         Task<Municipio> GetAsync(int? id);
         Task<Municipio> UpdateAsync(Municipio municipio );
         Task<Municipio> DeleteAsync(Municipio municipio);
         Task<Municipio> SearchAsync(int? id);
         bool Exists(int id);
    }
}