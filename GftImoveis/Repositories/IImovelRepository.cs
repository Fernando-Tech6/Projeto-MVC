using System.Collections.Generic;
using System.Threading.Tasks;
using GftImoveis.Models;

namespace GftImoveis.Repositories
{
    public interface IImovelRepository
    {
        Task<List<Imovel>> ListaAsync();
         Task<Imovel> CreateAsync(Imovel imovel);
         Task<Imovel> GetAsync(int? id);
         Task<Imovel> UpdateAsync(Imovel imovel);
         Task<Imovel> DeleteAsync(Imovel imovel );
         Task<Imovel> SearchAsync(int? id);
         bool Exists(int id);
    }
}