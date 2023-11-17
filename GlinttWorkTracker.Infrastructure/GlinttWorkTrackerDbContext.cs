using GlinttWorkTracker.Domain.Models;
using GlinttWorkTracker.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=glintt-work-tracker.db");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issues");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Issue>().HasData(
                new Issue { Id = 1, Type = "Story" },
                new Issue { Id = 2, Type = "Defect" },
                new Issue { Id = 3, Type = "Bug" }
            );


            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("Works");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GlinttApp).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Epic).IsRequired();
                entity.Property(e => e.Date).IsRequired();
            });

            Action<EntityTypeBuilder<TEntity>> configureEntities<TEntity>(Action<EntityTypeBuilder<TEntity>> entityConfig) where TEntity : Entity
            {
                return entityConfig;
            }


            modelBuilder.Entity<CodeChanges>(configureEntities<CodeChanges>(entity =>
            {
                entity.ToTable("CodeChanges");
            }));

            modelBuilder.Entity<DataBaseChanges>(configureEntities<DataBaseChanges>(entity =>
            {
                entity.ToTable("DataBaseChanges");
            }));

            modelBuilder.Entity<DBScripts>(configureEntities<DBScripts>(entity =>
            {
                entity.ToTable("DBScripts");
            }));

            modelBuilder.Entity<NuGetUpdates>(configureEntities<NuGetUpdates>(entity =>
            {
                entity.ToTable("NuGetUpdates");
            }));


        }
    }
}
