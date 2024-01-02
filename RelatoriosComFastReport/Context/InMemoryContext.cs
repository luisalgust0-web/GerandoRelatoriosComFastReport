using Microsoft.EntityFrameworkCore;
using RelatoriosComFastReport.Models;
using RelatoriosComFastReport.Repository;

namespace RelatoriosComFastReport.Context
{
    public class InMemoryContext : DbContext
    {

        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options) { }

        public InMemoryContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData
                (
                    new User[]
                    {
                      new User(1, "Thiago", "Silva", new DateTime(), "61934568764"),
                      new User(2, "Roberto", "Barross", new DateTime(), "61984768764"),
                      new User(3, "Carlos", "Freita", new DateTime(), "61934575844"),
                      new User(4, "Sanssungo", "Lg", new DateTime(), "61934561209")
                    }
                );

            modelBuilder.Entity<Trip>().HasData
                (
                    new Trip[]
                    {
                      new Trip("buzios", new DateTime(), new DateTime(), 1, 1),
                      new Trip("fortaleza", new DateTime(), new DateTime(), 2, 2),
                      new Trip("guaruja", new DateTime(), new DateTime(), 2, 3),
                      new Trip("salvador", new DateTime(), new DateTime(), 2, 4),
                      new Trip("mogi das cruzes", new DateTime(), new DateTime(), 2, 5),
                      new Trip("bauru", new DateTime(), new DateTime(), 3, 6),
                      new Trip("capao", new DateTime(), new DateTime(), 3, 7),
                      new Trip("ceilandia", new DateTime(), new DateTime(), 3, 8),
                      new Trip("valparaiso", new DateTime(), new DateTime(), 4, 9),
                      new Trip("brasilia", new DateTime(), new DateTime(), 4, 10)
                    }
                );
        }
    }
}
