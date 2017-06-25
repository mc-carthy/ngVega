using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ngVega.Core;
using ngVega.Core.Models;
using ngVega.Models;

namespace ngVega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await context.Vehicles.FindAsync(id);
            }

            return await context.Vehicles
                .Include(v => v.Features)
                    // ThenInclude is a nested include, so we're getting the Feature of the VehicleFeature of the Vehicle here
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(VehicleQuery queryObject)
        {
            var query = context.Vehicles
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .AsQueryable();

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, Object>>>()
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["contactName"] = v => v.ContactName,
                ["id"] = v => v.Id
            };

            query = ApplyOrdering(queryObject, query, columnsMap);

            return await query.ToListAsync();
        }

        private IQueryable<Vehicle> ApplyOrdering(VehicleQuery queryObject, IQueryable<Vehicle> query, Dictionary<string, Expression<Func<Vehicle, Object>>> columnsMap)
        {
            if (queryObject.IsSortAscending)
            {
                return query.OrderBy(columnsMap[queryObject.SortBy]);
            }
            else
            {
                return query.OrderByDescending(columnsMap[queryObject.SortBy]);
            }
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            context.Remove(vehicle);
        }
    }
}