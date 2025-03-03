using Microsoft.EntityFrameworkCore;

namespace SuperHeros.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) { }

        public DbSet<SuperHeros> SuperHeros { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}