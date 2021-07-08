using System.Collections.Generic;
using System.Threading.Tasks;
using GftImoveis.Models;

namespace GftImoveis.Repositories
{
    public interface IQuartoRepository
    {
         Task<List<Quarto>> ListaAsync();
         Task<Quarto> CreateAsync(Quarto quarto);
         Task<Quarto> GetAsync(int? id);
         Task<Quarto> UpdateAsync(Quarto quarto);
         Task<Quarto> DeleteAsync(Quarto quarto);
         Task<Quarto> SearchAsync(int? id);
         bool Exists(int id);


    }
}