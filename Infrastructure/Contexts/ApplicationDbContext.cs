using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Saloon> Saloons { get; set; }

        public DbSet<Projection> Projections { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Projections)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Saloon>()
                .HasMany(x => x.Projections)
                .WithOne(x => x.Saloon)
                .HasForeignKey(x => x.SaloonId);

            modelBuilder.Entity<Projection>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Projections);

            modelBuilder.Entity<Projection>()
                .HasOne(x => x.Saloon)
                .WithMany(x => x.Projections);
        }
    }
}
