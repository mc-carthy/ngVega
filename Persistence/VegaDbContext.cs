using Microsoft.EntityFrameworkCore;
using ngVega.Models;

namespace ngVega.Persistence
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // We use the two properties of VehicleFeature to create a composite primary key to ensure there are no duplicate VehicleFeatures
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new {
                vf.VehicleId, vf.FeatureId
            });
        }
    }
}