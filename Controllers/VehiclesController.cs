using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ngVega.Controllers.Resources;
using ngVega.Models;
using ngVega.Persistence;

namespace ngVega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(
            IMapper mapper,
            VegaDbContext context
        )
        {
            this.context = context;
            this.mapper = mapper;
        }
        // This use of a Domain class as a parameter is temporary until we implement the API Resource
        // The [FromBody] attribute tells the method that the data for the properties are set in the body of the request
        [HttpPost()]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // This is required for API validation which will be unnecessary as we're calling our 
            // API populated by the form which gets data from our database.
            // If a malicious user tries to tamper with it, they will get a 500 error with no detail.
            /*
            var model = await context.Models.FindAsync(vehicleResource.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }
             */

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
    }
}