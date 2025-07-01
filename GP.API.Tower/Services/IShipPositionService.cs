using GP.API.Tower.Dao;
using GP.LIB.Messages.Implementation;


namespace GP.API.Tower.Services
{
    public interface IShipPositionService
    {
        Task<Result<ShipPositionUpdatedDao>> ConsumeShipPositionAsync(string mmsi, double lat, double lon, double speed, int heading);
    }
}