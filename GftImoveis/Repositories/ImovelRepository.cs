using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Repositories
{

    public class ImovelRepository : IImovelRepository
    {
        private readonly ApplicationDbContext _context;

        public ImovelRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Imovel> CreateAsync(Imovel imovel)
        {
            _context.Add(imovel);
            await _context.SaveChangesAsync();
            return imovel;
        }

        public async Task<Imovel> DeleteAsync(Imovel imovel)
        {
           _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();
            return imovel;
        }

        public bool Exists(int id)
        {
            return _context.Imoveis.Any(e => e.ImovelId == id);
        }

        public async Task<Imovel> GetAsync(int? id)
        {
           
           return  await _context.Imoveis
                .Include(i => i.BairroIm)
                .Include(i => i.CategoriaIm)
                .Include(i => i.EnderecoIm)
                .Include(i => i.MunicipioIm)
                .Include(i => i.NegocioIm)
                .Include(i => i.QuantosIm)
                .FirstOrDefaultAsync(m => m.ImovelId == id);

        }

        public Task<List<Imovel>> ListaAsync()
        {   //Não será criado pois o index contém um sistema de busca
            throw new System.NotImplementedException();
        }

        public async Task<Imovel> SearchAsync(int? id)
        {
            return await _context.Imoveis.FindAsync(id);
        }

        public async Task<Imovel> UpdateAsync(Imovel imovel)
        {
            _context.Update(imovel);
            await _context.SaveChangesAsync();
            return imovel;
        }
    }
}