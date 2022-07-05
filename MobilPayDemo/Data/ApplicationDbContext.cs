using Microsoft.EntityFrameworkCore;
using MobilPayDemo.Entities;

namespace MobilPayDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasKey(k => k.Id);
            modelBuilder.Entity<Card>().Property(k => k.CardNumber).HasMaxLength(20).IsRequired(true);

            modelBuilder.ApplyConfiguration(new CardToUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = "Host=localhost;Port=5432;Username=postgres;Password=alijonov;Database=MobilPayDemoDb;";

            optionsBuilder.UseNpgsql(path);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardToUser> CardToUsers { get; set; }
    }
}
