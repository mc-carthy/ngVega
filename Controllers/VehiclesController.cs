using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ngVega.Controllers.Resources;
using ngVega.Models;

namespace ngVega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        public VehiclesController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        // This use of a Domain class as a parameter is temporary until we implement the API Resource
        // The [FromBody] attribute tells the method that the data for the properties are set in the body of the request
        [HttpPost()]
        public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            return Ok(vehicle);
        }
    }
}