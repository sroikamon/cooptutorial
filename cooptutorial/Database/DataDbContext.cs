using Microsoft.EntityFrameworkCore; // Inport EF
using cooptutorial.Models;

namespace cooptutorial.Database
{
    public class DataDbContext : DbContext
    {
        // Constructure
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<manufacturers> manufacturers { get; set; }

        public DbSet<devices> devices { get; set; }

    }
}