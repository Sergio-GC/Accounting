using Accounting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Accounting
{
    public class AccountingContext : DbContext
    {
        public DbSet<Kid> Kids { get; set; }
        public DbSet<CalendarEntry> CalendarEntries { get; set; }

        // Deliberatedly empty constructor
        public AccountingContext(){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kid>()
                .HasMany(k => k.Siblings)
                .WithMany(k => k.SiblingOf)
                .UsingEntity(j => j.ToTable("KidSiblings"));

            modelBuilder.Entity<CalendarEntry>()
                .HasMany(k => k.Kids)
                .WithMany(k => k.CalendarEntries)
                .UsingEntity(j => j.ToTable("CalendarEntryKids"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.UseLazyLoadingProxies();
            //builder.UseMySQL(config.GetConnectionString("DefaultDb"));
            builder.UseMySql(config.GetConnectionString("DefaultDb"), new MySqlServerVersion(new Version()));
        }
    }
}
