using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Repositories
{
    public class QuartoRepository : IQuartoRepository
    {
     private readonly ApplicationDbContext _context;


        public QuartoRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Quarto> CreateAsync(Quarto quarto)
        {
             _context.Add(quarto);
                await _context.SaveChangesAsync();
                return quarto;
        }

        public async Task<Quarto> DeleteAsync(Quarto quarto)
        {
            _context.Quartos.Remove(quarto);
            await _context.SaveChangesAsync();
            return quarto;  // Testar para ver se não precisa retornar o proprio remove
        }

        public async Task<Quarto> GetAsync(int? id)
        {
            return await _context.Quartos.AsNoTracking()
                .FirstOrDefaultAsync(m => m.QuartoId == id);
        }

        public async Task<List<Quarto>> ListaAsync()
        {
            return await _context.Quartos.ToListAsync();
        }

        public async Task<Quarto> UpdateAsync(Quarto quarto)
        {
             _context.Update(quarto);
           await _context.SaveChangesAsync();
           return quarto;
        }

        public async Task<Quarto> SearchAsync(int? id)
        {
           return await _context.Quartos.FindAsync(id);
        }

        public bool Exists(int id)
        {  // Uma expressão para confirmar se o id é o mesmo.
            return _context.Quartos.Any(e => e.QuartoId == id);
        }
    }
}