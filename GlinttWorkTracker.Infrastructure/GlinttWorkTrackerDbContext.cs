using GlinttWorkTracker.Domain.Models;
using GlinttWorkTracker.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace GlinttWorkTracker.Domain
{
    public class GlinttWorkTrackerDbContext : DbContext
    {
        public DbSet<Work> Works { get; set; }

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
            ConfigureEntity<Work>(modelBuilder);
            ConfigureEntity<Issue>(modelBuilder);
            ConfigureEntity<NuGetUpdates>(modelBuilder);
            ConfigureEntity<DBScripts>(modelBuilder);
            ConfigureEntity<DataBaseChanges>(modelBuilder);
            ConfigureEntity<CodeChanges>(modelBuilder);
        }

        private void ConfigureEntity<TEntity>(ModelBuilder modelBuilder) where TEntity : Entity
        {
            modelBuilder.Entity<TEntity>(entity =>
            {
                // Primary key
                entity.HasKey(e => e.Id);

                // Common properties
                entity.Property(e => e.Id).IsRequired();

                // Specific properties
                if (typeof(TEntity) == typeof(Work))
                {
                    entity.Property(e => ((Work)(object)e).GlinttApp).HasMaxLength(255).IsRequired();
                    entity.Property(e => ((Work)(object)e).Description).HasMaxLength(255);
                    entity.Property(e => ((Work)(object)e).Epic).HasMaxLength(255);
                    entity.Property(e => ((Work)(object)e).Date).IsRequired();

                    entity.HasOne(e => ((Work)(object)e).Issue).WithOne().IsRequired().HasForeignKey<Work>(e => e.Id);

                    entity.HasMany(e => ((Work)(object)e).NuGetUpdates).WithOne().HasForeignKey(e => e.Id);
                    entity.HasMany(e => ((Work)(object)e).DBScripts).WithOne().HasForeignKey(e => e.Id);
                    entity.HasMany(e => ((Work)(object)e).DataBaseChanges).WithOne().HasForeignKey(e => e.Id);
                    entity.HasMany(e => ((Work)(object)e).CodeChanges).WithOne().HasForeignKey(e => e.Id);
                }
                else if (typeof(TEntity) == typeof(Issue))
                {
                    entity.Property(e => ((Issue)(object)e).Type).IsRequired();
                }
                else if (typeof(TEntity) == typeof(NuGetUpdates))
                {
                    entity.Property(e => ((NuGetUpdates)(object)e).NuGet).HasMaxLength(255).IsRequired();
                    entity.Property(e => ((NuGetUpdates)(object)e).Where).HasMaxLength(255);
                }
                else if (typeof(TEntity) == typeof(DBScripts))
                {
                    entity.Property(e => ((DBScripts)(object)e).Description).HasMaxLength(255);
                }
                else if (typeof(TEntity) == typeof(DataBaseChanges))
                {
                    entity.Property(e => ((DataBaseChanges)(object)e).Package).HasMaxLength(255);
                    entity.Property(e => ((DataBaseChanges)(object)e).Method).HasMaxLength(255);
                }
                else if (typeof(TEntity) == typeof(CodeChanges))
                {
                    entity.Property(e => ((CodeChanges)(object)e).GlinttApp).HasMaxLength(255).IsRequired();
                    entity.Property(e => ((CodeChanges)(object)e).Project).HasMaxLength(255);
                    entity.Property(e => ((CodeChanges)(object)e).AuxProject).HasMaxLength(255);
                    entity.Property(e => ((CodeChanges)(object)e).File).HasMaxLength(255);
                }
            });
        }


    }

}
