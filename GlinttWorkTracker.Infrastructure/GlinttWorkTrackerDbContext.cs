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
        }
    }

}
