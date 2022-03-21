using System;
using CA2MoviesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CA2MoviesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieComment> MovieComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(i => i.Thumbnail)
                .HasDefaultValue("default.png");
        }
    }
}
