using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ngVega.Models;

namespace ngVega.Persistence
{
    public class VehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id)
        {
            return await context.Vehicles
                .Include(v => v.Features)
                    // ThenInclude is a nested include, so we're getting the Feature of the VehicleFeature of the Vehicle here
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}