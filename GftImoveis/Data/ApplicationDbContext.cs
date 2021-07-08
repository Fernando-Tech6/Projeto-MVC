using System.Linq;
using GftImoveis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
            relationship.DeleteBehavior = DeleteBehavior.Restrict;             
            // Altera o modo de exclusão das tabelas para restrict. Posso realizar essa mesma mudança diretamente no migrations(mudando o cascade para restrict ou null)
            
            
            base.OnModelCreating(modelBuilder);
            

        }

    }
}
