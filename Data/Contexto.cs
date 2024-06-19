using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsuariosModel> Usuario { get; set; }
        public DbSet<PessoasModel> Pessoa { get; set; }
        public DbSet<ObservacoesModel> Observacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new PessoasMap());
            modelBuilder.ApplyConfiguration(new ObservacoesMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
