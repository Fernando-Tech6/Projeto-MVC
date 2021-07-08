using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;
        }

        public async Task<Categoria> DeleteAsync(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public bool Exists(int id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }

        public async Task<Categoria> GetAsync(int? id)
        {
             return await _context.Categorias
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
        }

        public async Task<List<Categoria>> ListaAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> SearchAsync(int? id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _context.Update(categoria);
                    await _context.SaveChangesAsync();
                    return categoria;
        }
    }
}