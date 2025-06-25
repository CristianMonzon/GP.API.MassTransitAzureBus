
using GP.MSG.MassTransitAzureBus;

namespace GP.API.Ship.Services
{
    public interface IShipService
    {
        Task UpdatePositionAsync(string mmsi, double lat, double lon, double speed, int heading);
    }
}