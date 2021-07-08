using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Repositories
{
    public class BairroRepository : IBairroRepository
    {

        private readonly ApplicationDbContext _context;

        public BairroRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Bairro> CreateAsync(Bairro bairro)
        {
            _context.Add(bairro);
           await _context.SaveChangesAsync();
           return bairro;
        }

        public async Task<Bairro> DeleteAsync(Bairro bairro)
        {
             _context.Bairros.Remove(bairro);
            await _context.SaveChangesAsync();
            return bairro;
        }

        public bool Exists(int id)
        {
            return _context.Bairros.Any(e => e.BairroId == id);
        }

        public async Task<Bairro> GetAsync(int? id)
        {
            return await _context.Bairros
                .Include(b => b.MunicipioB)
                .FirstOrDefaultAsync(m => m.BairroId == id);

        }

        public async Task<List<Bairro>> ListaAsync()
        {
            var applicationDbContext = _context.Bairros.Include(b => b.MunicipioB);
           return await applicationDbContext.ToListAsync();
        }

        public async Task<Bairro> SearchAsync(int? id)
        {
            return await _context.Bairros.FindAsync(id);
        }

        public async Task<Bairro> UpdateAsync(Bairro bairro)
        {
             _context.Update(bairro);
             await _context.SaveChangesAsync();
             return bairro;
        }
    }
}