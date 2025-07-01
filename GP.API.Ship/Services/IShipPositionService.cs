using GP.API.Ship.Dao;
using GP.LIB.Messages.Implementation;


namespace GP.API.Ship.Services
{
    public interface IShipPositionService
    {
        Task<Result<ShipPositionDao>> RegisterShipPositionAsync(ShipPositionDao shipPositionDao);
    }
}