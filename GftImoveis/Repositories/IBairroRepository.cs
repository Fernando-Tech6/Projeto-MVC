using System.Collections.Generic;
using System.Threading.Tasks;
using GftImoveis.Models;

namespace GftImoveis.Repositories
{
    public interface IBairroRepository
    {
        Task<List<Bairro>> ListaAsync();
         Task<Bairro> CreateAsync(Bairro bairro);
         Task<Bairro> GetAsync(int? id);
         Task<Bairro> UpdateAsync(Bairro bairro);
         Task<Bairro> DeleteAsync(Bairro bairro);
         Task<Bairro> SearchAsync(int? id);
         bool Exists(int id);
    }
}