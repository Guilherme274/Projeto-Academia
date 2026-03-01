using Microsoft.EntityFrameworkCore;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Peito"},
                new Categoria { Id = 2, Nome = "Braço"},
                new Categoria { Id = 3, Nome = "Perna"},
                new Categoria { Id = 4, Nome = "Costas"},
                new Categoria { Id = 5, Nome = "Ombro"}
            );
        }

        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}