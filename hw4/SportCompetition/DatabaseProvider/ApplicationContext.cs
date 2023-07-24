using Microsoft.EntityFrameworkCore;
using DatabaseProvider.Configurations;

namespace DatabaseProvider
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoachConfiguration());
            modelBuilder.ApplyConfiguration(new CompetitionConfiguration());
            modelBuilder.ApplyConfiguration(new SportTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SportsmanConfiguration());
            modelBuilder.ApplyConfiguration(new PerformanceConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                return;
            }

            object value = optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}