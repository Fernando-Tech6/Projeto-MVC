using System.Collections.Generic;
using System.Threading.Tasks;
using GftImoveis.Models;

namespace GftImoveis.Repositories
{
    public interface IEnderecoRepository
    {
         Task<List<Endereco>> ListaAsync();
         Task<Endereco> CreateAsync(Endereco endereco);
         Task<Endereco> GetAsync(int? id);
         Task<Endereco> UpdateAsync(Endereco endereco);
         Task<Endereco> DeleteAsync(Endereco endereco );
         Task<Endereco> SearchAsync(int? id);
         bool Exists(int id);

    }
}