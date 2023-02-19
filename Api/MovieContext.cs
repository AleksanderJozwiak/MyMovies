using Microsoft.EntityFrameworkCore;

namespace MojeFilmy
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        
        }
        public DbSet<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int? id { get; set; }
        public string title { get; set; } = "";
        public string? director { get; set; }
        public int year { get; set; }
        public float? rate { get; set; }

    }
}
