using Microsoft.EntityFrameworkCore;
using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Context
{
    public class InMemoryContext : DbContext
    {

        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options) { }

        public InMemoryContext() {}

        public DbSet<User> Users { get; set; }
        public DbSet<Trips> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
