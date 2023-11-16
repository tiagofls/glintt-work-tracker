using GlinttWorkTracker.Domain.Models;
using GlinttWorkTracker.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlinttWorkTracker.Domain
{
    public class GlinttWorkTrackerDbContext : DbContext
    {
        public DbSet<Work> Works { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<CodeChanges> CodeChanges { get; set; }
        public DbSet<DataBaseChanges> DataBaseChanges { get; set; }
        public DbSet<DBScripts> DBScripts { get; set; }
        public DbSet<NuGetUpdates> NuGetUpdates { get; set; }

        public GlinttWorkTrackerDbContext()
        {

        }

        public GlinttWorkTrackerDbContext(DbContextOptions<GlinttWorkTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=glintt-work-tracker.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issues");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("Works");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GlinttApp).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Epic).IsRequired();
                entity.Property(e => e.Date).IsRequired();
            });

            // Configurações comuns para as tabelas CodeChanges, DataBaseChanges, DBScripts e NuGetUpdates
            Action<EntityTypeBuilder<TEntity>> configureEntities<TEntity>(Action<EntityTypeBuilder<TEntity>> entityConfig) where TEntity : Entity
            {
                return entityConfig;
            }

            // Usage

            modelBuilder.Entity<CodeChanges>(configureEntities<CodeChanges>(entity =>
            {
                entity.ToTable("CodeChanges");
                // Add other configurations as needed
            }));

            modelBuilder.Entity<DataBaseChanges>(configureEntities<DataBaseChanges>(entity =>
            {
                entity.ToTable("DataBaseChanges");
                // Add other configurations as needed
            }));

            modelBuilder.Entity<DBScripts>(configureEntities<DBScripts>(entity =>
            {
                entity.ToTable("DBScripts");
                // Add other configurations as needed
            }));

            modelBuilder.Entity<NuGetUpdates>(configureEntities<NuGetUpdates>(entity =>
            {
                entity.ToTable("NuGetUpdates");
                // Add other configurations as needed
            }));


        }
    }
}
