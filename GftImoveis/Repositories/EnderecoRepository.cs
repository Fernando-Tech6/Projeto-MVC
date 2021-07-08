using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;

        public EnderecoRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Endereco> CreateAsync(Endereco endereco)
        {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return endereco;
        }

        public async Task<Endereco> DeleteAsync(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public bool Exists(int id)
        {
            return _context.Enderecos.Any(e => e.EnderecoId == id);
        }

        public async Task<Endereco> GetAsync(int? id)
        {
               return  await _context.Enderecos
                .FirstOrDefaultAsync(m => m.EnderecoId == id);
        }

        public async Task<List<Endereco>> ListaAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> SearchAsync(int? id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<Endereco> UpdateAsync(Endereco endereco)
        {
             _context.Update(endereco);
             await _context.SaveChangesAsync();
             return endereco;
        }
    }
}