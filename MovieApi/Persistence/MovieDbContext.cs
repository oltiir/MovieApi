using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Persistence
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies => Set<Movie>();
    }
}