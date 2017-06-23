using System.Threading.Tasks;
using ngVega.Models;

namespace ngVega.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);

    }
}