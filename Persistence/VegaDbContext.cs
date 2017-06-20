using Microsoft.EntityFrameworkCore;
using ngVega.Models;

namespace ngVega.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }
        // We don't need to explicitly import the Model class because it is implicitly discovered as it is linked to Makes
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}