using System.Collections.Generic;
using System.Threading.Tasks;
using GftImoveis.Models;

namespace GftImoveis.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ListaAsync();
         Task<Categoria> CreateAsync( Categoria categoria);
         Task<Categoria> GetAsync(int? id);
         Task<Categoria> UpdateAsync(Categoria categoria );
         Task<Categoria> DeleteAsync( Categoria categoria);
         Task<Categoria> SearchAsync(int? id);
         bool Exists(int id);

    }
}