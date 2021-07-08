using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
           private readonly ApplicationDbContext _context;

        public MunicipioRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Municipio> CreateAsync(Municipio municipio)
        {
                _context.Add(municipio);
                await _context.SaveChangesAsync();
                return municipio;
        }

        public async Task<Municipio> DeleteAsync(Municipio municipio)
        {
             _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();
            return municipio;
        }

        public bool Exists(int id)
        {
            return _context.Municipios.Any(e => e.MunicipioId == id);
        }

        public async Task<Municipio> GetAsync(int? id)
        {
                return  await _context.Municipios
                .Include(m => m.EnderecoM)
                .FirstOrDefaultAsync(m => m.MunicipioId == id);
        }

        public async Task<List<Municipio>> ListaAsync()
        {
            var applicationDbContext = _context.Municipios.Include(m => m.EnderecoM);
            return await applicationDbContext.ToListAsync();
        }

        public async Task<Municipio> SearchAsync(int? id)
        {
           return await _context.Municipios.FindAsync(id);
        }

        public async Task<Municipio> UpdateAsync(Municipio municipio)
        {
                  _context.Update(municipio);
                    await _context.SaveChangesAsync();
                    return municipio;
        }
    }
}
