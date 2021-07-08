using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Repositories
{
    public class NegocioRepository : INegocioRepository
    {
        private readonly ApplicationDbContext _context;

        public NegocioRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Negocio> CreateAsync(Negocio negocio)
        {
            _context.Add(negocio);
                await _context.SaveChangesAsync();
                return negocio;
        }

        public async Task<Negocio> DeleteAsync(Negocio negocio)
        {
            _context.Negocios.Remove(negocio);
            await _context.SaveChangesAsync();
            return negocio;
        }

        public bool Exists(int id)
        {
            return _context.Negocios.Any(e => e.NegocioId == id);
        }

        public async Task<Negocio> GetAsync(int? id)
        {
           return await _context.Negocios
                .FirstOrDefaultAsync(m => m.NegocioId == id);
        }

        public async Task<List<Negocio>> ListaAsync()
        {
            return await _context.Negocios.ToListAsync();
        }

        public async Task<Negocio> SearchAsync(int? id)
        {
            return await _context.Negocios.FindAsync(id);
        }

        public async Task<Negocio> UpdateAsync(Negocio negocio)
        {
            _context.Update(negocio);
            await _context.SaveChangesAsync();
            return negocio;
        }
    }
}