using Microsoft.EntityFrameworkCore;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}