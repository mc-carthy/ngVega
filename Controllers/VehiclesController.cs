using Microsoft.AspNetCore.Mvc;
using ngVega.Models;

namespace ngVega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        // This use of a Domain class as a parameter is temporary until we implement the API Resource
        // The [FromBody] attribute tells the method that the data for the properties are set in the body of the request
        [HttpPost()]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            return Ok(vehicle);
        }
    }
}